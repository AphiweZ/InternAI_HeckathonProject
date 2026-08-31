using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternAI_HeckathonProject.Models
{
    public class Internship
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public List<string> RequiredSkills { get; set; }
        public string Description { get; set; }
        public DateTime ApplicationDeadline { get; set; }
        public string ApplyUrl { get; set; }
    }
}