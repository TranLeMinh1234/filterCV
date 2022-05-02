using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filterCV.Controllers
{
    public class FilterCv : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult testApi()
        {
            return new JsonResult(new { data = "asdasd" });
        }

        [HttpPost("FilterCv/execute")]
        public JsonResult filterCV(List<IFormFile> formFile)
        {
            PdfReader reader = new PdfReader(formFile[0].OpenReadStream());
            StringBuilder text = new StringBuilder();

            for (int i = 1; i <= reader.NumberOfPages; i++)
            {
                text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
            }

            return new JsonResult(new { data = text.ToString() });
        }

        [HttpPost("abc")]
        public JsonResult testApi(List<IFormFile> formFile)
        {
            return new JsonResult(new { data = "ASasjBAJKSHjkashJKHSaskj"});
        }

    }
}
