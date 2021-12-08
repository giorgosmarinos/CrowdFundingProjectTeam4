using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundableMvc.Models
{
    public class Funding
    {
        public List<Funding> Project { get; set; }
        public List<int> ProjectIds { get; set; }
    }

    public class FundingPackage
    {
        public int Funding { get; set; }
        public string Text { get; set; }
    }
}
