using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternAI_HeckathonProject.Models
{
    public class Application
    {
        public int Id { get; set; }
        public int InternshipId { get; set; }
        public string InternshipTitle { get; set; }
        public string Company { get; set; }
        public DateTime Deadline { get; set; }
        public string Status { get; set; }
        public DateTime? AppliedOn { get; set; }
    }
}