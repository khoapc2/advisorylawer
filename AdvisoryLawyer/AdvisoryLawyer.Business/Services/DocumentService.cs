using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests.DocumentRequest;
using AdvisoryLawyer.Business.ViewModel;
using AdvisoryLawyer.Data.IRepositories;
using AdvisoryLawyer.Data.Models;
using AutoMapper;
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

        public DocumentService(IGenericRepository<Document> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
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
            var document = await _genericRepository.GetByIDAsync(id);
            if (document != null)
            {
                await _genericRepository.DeleteAsync(id);
                await _genericRepository.SaveAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<DocumentModel>> GetAllDocuments()
        {
            var documents = await _genericRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DocumentModel>>(documents);
        }

        public async Task<DocumentModel> GetDocumentById(int id)
        {
            var document = await _genericRepository.GetByIDAsync(id);
            if (document != null)
            {
                return _mapper.Map<DocumentModel>(document);
            }
            return null;
        }

        public async Task<DocumentModel> UpdateDocument(int id, DocumentRequest documentRequest)
        {
            var document = await _genericRepository.GetByIDAsync(id);
            if (document != null)
            {
                document = _mapper.Map(documentRequest, document);
                await _genericRepository.SaveAsync();
                return _mapper.Map<DocumentModel>(document);
            }
            return null;
        }
    }
}
