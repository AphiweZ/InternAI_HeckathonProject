using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using InternAI_HeckathonProject.Models;

namespace InternAI_HeckathonProject.Controllers
{
    // This controller manages the student's application tracker -
    // adding internships to track, and updating their status.
    public class TrackerController : Controller
    {
        // "static" here is important: it means this list is SHARED
        // across every request to the app, and stays alive as long
        // as the app keeps running (it resets only when you restart).
        // This is a simple stand-in for a real database.
        private static List<Application> _applications = new List<Application>();

        // Runs when the student visits /Tracker or /Tracker/Index.
        // Shows the current list of tracked applications.
        public ActionResult Index()
        {
            return View(_applications);
        }

        // Runs when the student clicks "Track this internship" -
        // adds a new entry to the tracker list.
        // [HttpPost] means this only responds to form submissions,
        // not just visiting a URL directly in the browser.
        [HttpPost]
        public ActionResult Add(int internshipId, string title, string company, System.DateTime deadline)
        {
            // Check if this internship is already being tracked -
            // if so, don't add a duplicate, just go back to the tracker.
            bool alreadyTracked = _applications.Any(a => a.InternshipId == internshipId);

            if (!alreadyTracked)
            {
                _applications.Add(new Application
                {
                    Id = _applications.Count + 1,
                    InternshipId = internshipId,
                    InternshipTitle = title,
                    Company = company,
                    Deadline = deadline,
                    Status = "Not Applied"
                });
            }

            return RedirectToAction("Index");
        }

        // Runs when the student updates an application's status
        // (e.g. changes it from "Not Applied" to "Applied").
        [HttpPost]
        public ActionResult UpdateStatus(int id, string status)
        {
            // Find the one application in our list whose Id matches.
            // FirstOrDefault returns null if nothing matches, instead
            // of crashing - which is why we check "if (app != null)" below.
            Application app = _applications.FirstOrDefault(a => a.Id == id);

            if (app != null)
            {
                app.Status = status;
            }

            return RedirectToAction("Index");
        }
    }
}