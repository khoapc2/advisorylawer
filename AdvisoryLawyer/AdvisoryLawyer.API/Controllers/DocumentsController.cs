using AdvisoryLawyer.Business.IServices;
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
        public async Task<ActionResult<IEnumerable<DocumentModel>>> GetAllDocuments()
        {
            return Ok(await _service.GetAllDocuments());
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

