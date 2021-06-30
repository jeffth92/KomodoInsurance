using Developer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeam
{
    public class DevTeam
    {
        public List<Developer.Developer> Members = new List<Developer.Developer>();

        public string TeamName { get; set; }

        public int TeamID { get; set; }

        public DevTeam() { }

        public DevTeam(List<Developer.Developer> members, string teamName, int teamID)
        {
            Members = members;
            TeamName = teamName;
            TeamID = teamID;
        }
    }
}
