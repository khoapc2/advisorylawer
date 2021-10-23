using AdvisoryLawyer.Business.Enum;
using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests.DocumentCaseRequest;
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
    public class DocumentCaseService : IDocumentCaseService
    {
        private IGenericRepository<DocumentCase> _genericRepository;
        private IMapper _mapper;

        public DocumentCaseService(IGenericRepository<DocumentCase> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task CreateDocumentCase(DocumentCaseRequest documentCaseRequest)
        {
            var documentCase = _mapper.Map<DocumentCase>(documentCaseRequest);
            await _genericRepository.InsertAsync(documentCase);
            await _genericRepository.SaveAsync();
        }

        public async Task DeleteDocumentCase(int id)
        {
            var documentCase = await _genericRepository.FindAsync(x => x.Id == id &&
            x.Status == (int)DocumentCaseStatus.Active);
            if (documentCase != null)
            {
                await _genericRepository.DeleteAsync(id);
                await _genericRepository.SaveAsync();
            }
        }

        public async Task UpdateDocumentCase(DocumentCaseUpdate documentCaseUpdate)
        {
            var documentCase = await _genericRepository.FindAsync(x => x.Id == documentCaseUpdate.Id &&
            x.Status == (int)DocumentCaseStatus.Active);
            if (documentCase != null)
            {
                await _genericRepository.UpdateAsync(documentCase);
            }
        }

        public async Task<bool> CreateDocumentCase(int customerCaseId, List<int> DocumentIds)
        {
            foreach (var DocumentCaseId in DocumentIds)
            {
                var CategoryDocumentCase = new DocumentCase()
                {
                    CustomerCaseId = customerCaseId,
                    DocumentId = DocumentCaseId,
                    Status = (int)DocumentCaseStatus.Active
                };
                await _genericRepository.InsertAsync(CategoryDocumentCase);
            }
            await _genericRepository.SaveAsync();
            return true;
        }

        public async Task<bool> CreateDocumentCase(List<int> categoryIds, int DocumentCase)
        {
            foreach (var categoryId in categoryIds)
            {
                var CategoryDocumentCase = new DocumentCase()
                {
                    CustomerCaseId = categoryId,
                    DocumentId = DocumentCase,
                    Status = (int)DocumentCaseStatus.Active
                };
                await _genericRepository.InsertAsync(CategoryDocumentCase);
            }
            await _genericRepository.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteCategory(int categoryId)
        {
            var listCategoryoffice = (List<DocumentCase>)await _genericRepository.FindByAsync(x => x.CustomerCaseId == categoryId);
            foreach (var categoryOffice in listCategoryoffice)
            {
                categoryOffice.Status = (int)DocumentCaseStatus.InActive;
                await _genericRepository.UpdateAsync(categoryOffice);
            }
            await _genericRepository.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteDocumentCaseByLong(int DocumentCaseId)
        {
            var listCategoryoffice = (List<DocumentCase>)await _genericRepository.FindByAsync(x => x.DocumentId == DocumentCaseId);
            foreach (var categoryOffice in listCategoryoffice)
            {
                categoryOffice.Status = (int)DocumentCaseStatus.InActive;
                await _genericRepository.UpdateAsync(categoryOffice);
            }
            await _genericRepository.SaveAsync();
            return true;
        }

        public async Task<bool> UpdateCaseDocument(int categoryId, List<int> DocumentCaseIds)
        {
            await DeleteCategory(categoryId);
            await CreateDocumentCase(categoryId, DocumentCaseIds);
            return true;
        }

        public async Task<DocumentCase> GetDocumentCase(int categoryId)
        {
            return await _genericRepository.FindAsync(x => x.CustomerCaseId == categoryId & x.Status == (int)DocumentCaseStatus.Active);
        }

        public async Task<bool> UpdateDocumentCase(int DocumentCase, List<int> categoryIds)
        {
            await DeleteDocumentCase(DocumentCase);
            await CreateDocumentCase(categoryIds, DocumentCase);
            return true;
        }

     

     
    }
}
