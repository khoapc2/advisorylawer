using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests;
using AdvisoryLawyer.Business.Requests.DocumentRequest;
using AdvisoryLawyer.Business.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvisoryLawyer.API.Controllers
{
    [Route("api/v1/documents")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentService _service;
        public DocumentsController(IDocumentService service)
        {
            _service = service;
        }

        //GET api/documents
        [HttpGet]
        public ActionResult<IEnumerable<DocumentModel>> GetAllDocuments([FromQuery] DocumentRequest filter, DocumentSortBy sort_by,
            OrderBy order_by, int page_index = 1, int page_size = 1)
        {
            return Ok(_service.GetAllDocuments(filter, sort_by, order_by, page_index, page_size));
        }

        //GET api/documents/{id}
        [HttpGet("{id}", Name = "GetDocumentById")]
        public async Task<ActionResult<DocumentModel>> GetDocumentById(int id)
        {
            var documentModel = await _service.GetDocumentById(id);
            if (documentModel == null)
            {
                return BadRequest();
            }
            return Ok(documentModel);
        }

        //POST api/documents
        [HttpPost]
        public async Task<ActionResult<DocumentModel>> CreateDocument(DocumentRequest documentRequest)
        {
            var documentModel = await _service.CreateDocument(documentRequest);
            if (documentModel != null)
            {
                return CreatedAtRoute(nameof(GetDocumentById)
                    , new { Id = documentModel.Id }, documentModel);
            }
            return BadRequest();
        }

        //PUT api/documents/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<DocumentModel>> UpdateDocument(int id, DocumentRequest documentRequest)
        {
            var documentModel = await _service.UpdateDocument(id, documentRequest);
            if (documentModel != null)
            {
                return Ok(documentModel);
            }
            return BadRequest();
        }

        //DELETE api/documents/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDocument(int id)
        {
            bool deleteStatus = await _service.DeleteDocument(id);
            if (deleteStatus)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}

