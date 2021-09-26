
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
        IEnumerable<DocumentModel> GetAllDocuments();
        DocumentModel GetDocumentById(int id);
        DocumentModel CreateDocument(DocumentRequest documentRequest);
        DocumentModel UpdateDocument(int id, DocumentRequest documentRequest);
        bool DeleteDocument(int id);
    }
}
