using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternAI_HeckathonProject.Models
{
    public class RankedInternship
    {
        public Internship Internship { get; set; }

        // A score like 0.85 meaning "85% match" for this student
        public double MatchScore { get; set; }

        // Which of the student's skills matched what's required
        public List<string> MatchedSkills { get; set; }

        // Which required skills the student is missing
        public List<string> MissingSkills { get; set; }

        // A generated cover letter specific to this internship
        // (placeholder text for now, until real AI generates it)
        public string CoverLetter { get; set; }
    }
}