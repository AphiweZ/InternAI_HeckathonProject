using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using InternAI_HeckathonProject.Models;
using InternAI_HeckathonProject.Services;

namespace InternAI_HeckathonProject.Controllers
{
    public class UploadController : Controller
    {
        // Shows the empty upload form when the student first visits /Upload
        public ActionResult Index()
        {
            return View();
        }

        // Runs when the student submits the upload form with a file attached.
        // HttpPostedFileBase represents the uploaded file itself.
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase cvFile)
        {
            // Safety check: if nothing was actually uploaded, just show
            // the empty form again instead of crashing.
            if (cvFile == null || cvFile.ContentLength == 0)
            {
                ViewBag.Error = "Please choose a file first.";
                return View();
            }

            // ---- FAKE CV READING (stand-in for your partner's real AI) ----
            // In reality, someone would need to open the file and extract
            // real text + skills from it. We don't have that yet, so we
            // fake a CvData object with made-up extracted skills.
            CvData fakeCvData = new CvData
            {
                FileName = cvFile.FileName,
                RawText = "(pretend this is the text extracted from the CV)",
                ExtractedSkills = new List<string> { "C#", "SQL", "Python" }
            };

            // Load the real internship list (this part IS real, from Step 11)
            InternshipDataService dataService = new InternshipDataService();
            List<Internship> internships = dataService.GetAll();

            // Call the stub "AI" to get back a ranked list.
            // Later, swap AgentServiceStub for your partner's real class -
            // this line is the ONLY thing that needs to change.
            IAgentService agentService = new AgentServiceStub();
            List<RankedInternship> results = agentService.AnalyzeAndMatch(fakeCvData, internships);

            // Hand the ranked results to a separate results page.
            return View("Results", results);
        }
    }
}