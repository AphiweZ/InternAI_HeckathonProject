using System.Collections.Generic;
using System.Web.Mvc;
using InternAI_HeckathonProject.Models;
using InternAI_HeckathonProject.Services;

namespace InternAI_HeckathonProject.Controllers
{
    // This controller is responsible for showing internship listings.
    public class InternshipsController : Controller
    {
        // This is the "front door" action - when someone visits
        // /Internships or /Internships/Index, this method runs.
        public ActionResult Index()
        {
            // Create the service we built earlier, and use it to
            // load the list of internships from the JSON file.
            InternshipDataService service = new InternshipDataService();
            List<Internship> internships = service.GetAll();

            // Hand that list of internships to the View so it can
            // be displayed as HTML. "View(internships)" means:
            // "render the page for this action, and give it this data."
            return View(internships);
        }
    }
}