using AdvisoryLawyer.Business.Enum;
using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests;
using AdvisoryLawyer.Business.Requests.DocumentRequest;
using AdvisoryLawyer.Business.ViewModel;
using AdvisoryLawyer.Data.IRepositories;
using AdvisoryLawyer.Data.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using PagedList;
using Reso.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Services
{
    public class DocumentService : IDocumentService
    {
        private IGenericRepository<Document> _genericRepository;
        private IMapper _mapper;
        private readonly IDocumentCaseService _documentCaseSeService;
        public DocumentService(IGenericRepository<Document> genericRepository, IMapper mapper, 
            IDocumentCaseService documentCaseSeService)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _documentCaseSeService = documentCaseSeService;
        }

        public async Task<DocumentModel> CreateDocument(DocumentRequest documentRequest)
        {
            var document = _mapper.Map<Document>(documentRequest);
            await _genericRepository.InsertAsync(document);
            await _genericRepository.SaveAsync();

            return _mapper.Map<DocumentModel>(document);
        }

        public async Task<bool> DeleteDocument(int id)
        {
            var document = await _genericRepository.FindAsync(x => x.Id == id &&
            x.Status == (int)DocumentStatus.Active);
            if (document != null)
            {
                await _genericRepository.DeleteAsync(id);
                await _genericRepository.SaveAsync();
                return true;
            }
            return false;
        }

        public IPagedList<DocumentModel> GetAllDocuments(DocumentRequest filter,
            DocumentSortBy sortBy, OrderBy order, int pageIndex, int pageSize)
        {
            var listDocuments = _genericRepository.FindBy(x => x.Status == (int)DocumentStatus.Active);
            var listDocumentsModel = (listDocuments.ProjectTo<DocumentModel>
                (_mapper.ConfigurationProvider)).DynamicFilter(_mapper.Map<DocumentModel>(filter));
            switch (sortBy.ToString())
            {
                case "Name":
                    if ("Asc".Equals(order.ToString()))
                    {
                        listDocumentsModel = listDocumentsModel.OrderBy(x => x.Name);
                    }
                    else
                    {
                        listDocumentsModel = listDocumentsModel.OrderByDescending(x => x.Name);
                    }
                    break;
                case "Description":
                    if ("Asc".Equals(order.ToString()))
                    {
                        listDocumentsModel = listDocumentsModel.OrderBy(x => x.Description);
                    }
                    else
                    {
                        listDocumentsModel = listDocumentsModel.OrderByDescending(x => x.Description);
                    }
                    break;
            }
            return PagedListExtensions.ToPagedList(listDocumentsModel, pageIndex, pageSize);
        }

        public async Task<DocumentModel> GetDocumentById(int id)
        {
            var document = await _genericRepository.FindAsync(x => x.Id == id &&
            x.Status == (int)DocumentStatus.Active);
            if (document != null)
            {
                return _mapper.Map<DocumentModel>(document);
            }
            return null;
        }

        public async Task<DocumentModel> UpdateDocument(DocumentUpdate documentUpdate)
        {
            var document = await _genericRepository.FindAsync(x => x.Id == documentUpdate.Id &&
            x.Status == (int)DocumentStatus.Active);
            if (document != null)
            {
                document = _mapper.Map(documentUpdate, document);
                await _genericRepository.SaveAsync();
                return _mapper.Map<DocumentModel>(document);
            }
            return null;
        }

        public async Task<DocumentCaseUpdate> UpdateDocumentCase(DocumentCaseUpdate request)
        {
            var category = await _genericRepository.FindAsync(x => x.Id == request.DocumentId &&
           x.Status == (int)DocumentCaseStatus.Active);
            if (category != null)
            {
                await _documentCaseSeService.UpdateDocumentCase(request.DocumentId, request.CustomerCaseIds);
                return request;
            }
            return null;
        }
    }
}
