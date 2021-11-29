using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingProjectTeam4.Model
{
    public class UserProject
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Project Project { get; set; }
    }
}
