using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternAI_HeckathonProject.Models
{
    public class CvData
    {
    
        // This class represents what our app knows about a student's CV
            public string RawText { get; set; }

            // List of skills the AI figured out from that text, e.g. ["Python", "SQL"]
            public List<string> ExtractedSkills { get; set; }

            // Just the name of the file the student uploaded,
            // e.g. "john_smith_resume.pdf" - useful for displaying on screen
            public string FileName { get; set; }
        
    }
}
