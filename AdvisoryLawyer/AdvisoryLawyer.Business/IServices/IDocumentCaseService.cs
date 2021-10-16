using AdvisoryLawyer.Business.Requests.DocumentCaseRequest;
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
    }
}
