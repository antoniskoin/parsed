using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using parsed.Models;

namespace parsed.Controllers
{
    [Route("[controller]")]
    public class ExtractController : Controller
    {
        [HttpPost("/extract")]
        public async Task<IActionResult> Post(IFormFile document)
        {
            if (document.Length <= 0)
                return BadRequest(new {FileIsEmpty = "File is empty."}); // Check if file is empty or not

            try
            {
                var result = await Task.Run(() => ExtractText(document.OpenReadStream()));
                
                if (result.ErrorMessage != string.Empty)
                    return BadRequest(new {Message = result.ErrorMessage});
                
                var results = new {
                    parsedText = result.ParsedText,
                    numberOfPages = result.NumberOfPages,
                    numberOfWords = result.NumberOfWords
                };

                return Json(results);
            }
            catch (Exception error)
            {
                return BadRequest(new {error.Message});
            }
        }

        private static ExtractionModel ExtractText(Stream stream)
        {
            var pdfReader = new PdfReader(stream);
            var pdfDoc = new PdfDocument(pdfReader);
            var stringBuilder = new StringBuilder();
            ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
            var totalPages = pdfDoc.GetNumberOfPages();
            for (var page = 1; page <= totalPages; page++)
            {
                var extractedText = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(page), strategy);
                stringBuilder.Append(extractedText + Environment.NewLine);
            }

            pdfDoc.Close();
            pdfReader.Close();
            return new ExtractionModel(string.Empty, stringBuilder.ToString(), totalPages, 
                stringBuilder.Length);
        }
    }
}