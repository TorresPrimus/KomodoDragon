using DeveloperRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTeamRepo
{
    public class DevTeamContent
    {
        public string TeamName { get; set; }

        public int TeamID { get; set; }

        public List<DevContent> ListOfDevs { get; set; }

        public DevTeamContent() { }

        public DevTeamContent(string teamName, int teamID, List<DevContent> listOfDevs)
        {
            TeamName = teamName;
            TeamID = teamID;
            ListOfDevs = listOfDevs;
        }
    }
}
