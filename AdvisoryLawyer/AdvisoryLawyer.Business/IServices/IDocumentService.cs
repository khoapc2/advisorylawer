using AdvisoryLawyer.Business.Requests.DocumentRequest;
using AdvisoryLawyer.Business.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.IServices
{
    public interface IDocumentService
    {
        Task<IEnumerable<DocumentModel>> GetAllDocuments();
        Task<DocumentModel> GetDocumentById(int id);
        Task<DocumentModel> CreateDocument(DocumentRequest documentRequest);
        Task<DocumentModel> UpdateDocument(int id, DocumentRequest documentRequest);
        Task<bool> DeleteDocument(int id);
    }
}
