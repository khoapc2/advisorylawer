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
    }
}
