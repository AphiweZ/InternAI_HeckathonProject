using System;
using System.Collections.Generic;
using System.Linq;
using InternAI_HeckathonProject.Models;

namespace InternAI_HeckathonProject.Services
{
    // This INTERFACE is a "promise" - it says: anything that claims to be
    // an AgentService MUST have a method called AnalyzeAndMatch that takes
    // a CV and a list of internships, and returns a ranked list.
    //
    // Your partner's REAL AI class will also implement this same interface.
    // That's what lets you swap the fake one for the real one later,
    // with barely any code changes on your side.
    public interface IAgentService
    {
        List<RankedInternship> AnalyzeAndMatch(CvData cv, List<Internship> internships);
    }

    // This is the FAKE version of the AI - it doesn't actually think,
    // it just returns random scores so you have SOMETHING to display
    // and test your app with, right now.
    //
    // IMPORTANT: delete/replace this class later once your partner's
    // real AI logic is ready - just swap it in, same method signature.
    public class AgentServiceStub : IAgentService
    {
        public List<RankedInternship> AnalyzeAndMatch(CvData cv, List<Internship> internships)
        {
            Random rnd = new Random();

            // For each internship in the list, wrap it in a RankedInternship
            // with a random match score and some fake matched/missing skills.
            List<RankedInternship> results = internships
                .Select(i => new RankedInternship
                {
                    Internship = i,
                    MatchScore = Math.Round(rnd.NextDouble(), 2), // random number 0.00 - 1.00
                    MatchedSkills = i.RequiredSkills.Take(2).ToList(),   // pretend first 2 skills matched
                    MissingSkills = i.RequiredSkills.Skip(2).ToList(),  // pretend the rest are missing
                    CoverLetter = "[Placeholder cover letter for " + i.Title + " at " + i.Company + "]"
                })
                .OrderByDescending(r => r.MatchScore) // sort best matches first
                .ToList();

            return results;
        }
    }
}