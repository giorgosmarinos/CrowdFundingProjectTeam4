using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using CrowdFundingProjectTeam4.Model;

namespace CrowdFundingProjectTeam4MVC.Models
{
    public class ProjectGenreViewModel

    {
        public List<Project> Projects { get; set; }
        public SelectList Genres { get; set; }
        public string ProjectGenre { get; set; }
        public string SearchString { get; set; }
    }
}

