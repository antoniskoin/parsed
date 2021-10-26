using System;
using iText.Kernel.Pdf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace parsed.Controllers
{
    public class MetadataController : Controller
    {
        [HttpPost("/metadata")]
        public IActionResult Post(IFormFile document)
        {
            try
            {
                var pdfReader = new PdfReader(document.OpenReadStream());
                var pdfDoc = new PdfDocument(pdfReader);
                var pdfInfo = pdfDoc.GetDocumentInfo();

                var metadata = new {
                    author = pdfInfo.GetAuthor(),
                    creator = pdfInfo.GetCreator(),
                    keywords = pdfInfo.GetKeywords(),
                    producer = pdfInfo.GetProducer(),
                    subject = pdfInfo.GetSubject(),
                    title = pdfInfo.GetTitle(),
                    trapped = pdfInfo.GetTrapped()
                };

                return Json(metadata);
            }
            catch (Exception error)
            {
                return BadRequest(new {error.Message});
            }
        }
    }
}