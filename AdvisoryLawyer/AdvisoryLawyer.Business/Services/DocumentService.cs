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

        public DocumentModel CreateDocument(DocumentRequest documentRequest)
        {
            var document = _mapper.Map<Document>(documentRequest);
            _genericRepository.Insert(document);
            _genericRepository.Save();

            return _mapper.Map<DocumentModel>(document);
        }

        public bool DeleteDocument(int id)
        {
            var document = _genericRepository.GetByID(id);
            if (document != null)
            {
                _genericRepository.Delete(id);
                _genericRepository.Save();
                return true;
            }
            return false;
        }

        public IEnumerable<DocumentModel> GetAllDocuments()
        {
            var documents = _genericRepository.GetAll();
            return _mapper.Map<IEnumerable<DocumentModel>>(documents);
        }

        public DocumentModel GetDocumentById(int id)
        {
            var document = _genericRepository.GetByID(id);
            if (document != null)
            {
                return _mapper.Map<DocumentModel>(document);
            }
            return null;
        }

        public DocumentModel UpdateDocument(int id, DocumentRequest documentRequest)
        {
            var document = _genericRepository.GetByID(id);
            if (document != null)
            {
                document = _mapper.Map(documentRequest, document);
                _genericRepository.Save();
                return _mapper.Map<DocumentModel>(document);
            }
            return null;
        }
    }
}
