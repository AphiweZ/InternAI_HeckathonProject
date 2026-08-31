using InternAI_HeckathonProject.Models;
using Newtonsoft.Json;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternAI_HeckathonProject.Services
{
    public class InternshipDataService
    {
        public List<Internship> GetAll()
        {
            // Figure out the real file path on disk for internships.json.
            // Server.MapPath converts "~/App_Data/..." (a web-style path)
            // into an actual file system path like "C:\...\App_Data\internships.json"
            string path = HttpContext.Current.Server.MapPath("~/App_Data/internships.json");

            // Read the ENTIRE file into one big string of text
            string jsonText = File.ReadAllText(path);

            // This is the key line: Newtonsoft.Json reads that text
            // and converts it into a List<Internship> - matching each
            // JSON field (like "Title", "Company") to the properties
            // we defined in the Internship class.
            List<Internship> internships = JsonConvert.DeserializeObject<List<Internship>>(jsonText);

            // Hand the finished list back to whoever called this method
            return internships;
        }
    }
}