using AdvisoryLawyer.Business.Requests;
using AdvisoryLawyer.Business.Requests.DocumentRequest;
using AdvisoryLawyer.Business.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.IServices
{
    public interface IDocumentService
    {
        IPagedList<DocumentModel> GetAllDocuments(DocumentRequest filter,
            DocumentSortBy sortBy, OrderBy order, int pageIndex, int pageSize);
        Task<DocumentModel> GetDocumentById(int id);
        Task<DocumentModel> CreateDocument(DocumentRequest documentRequest);
        Task<DocumentModel> UpdateDocument(DocumentUpdate documentUpdate);
        Task<bool> DeleteDocument(int id);
    }
}
