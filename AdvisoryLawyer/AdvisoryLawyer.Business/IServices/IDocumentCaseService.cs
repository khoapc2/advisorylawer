using AdvisoryLawyer.Business.Requests.DocumentCaseRequest;
using AdvisoryLawyer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.IServices
{
    public interface IDocumentCaseService
    {
        Task CreateDocumentCase(DocumentCaseRequest documentCaseRequest);
        Task UpdateDocumentCase(DocumentCaseUpdate documentCaseUpdate);
        Task DeleteDocumentCase(int id);

        Task<bool> CreateDocumentCase(int customerCaseId, List<int> documentCaseIds);
        Task<bool> CreateDocumentCase(List<int> customerCaseIds, int documentCaseId);
        Task<bool> UpdateCaseDocument(int customerCaseId, List<int> documentCaseIds);
        Task<bool> DeleteDocumentCaseByLong(int customerCaseId);
        Task<DocumentCase> GetDocumentCase(int customerCaseId);
        Task<bool> UpdateDocumentCase(int documentCaseId, List<int> customerCaseIds);
    }
}
