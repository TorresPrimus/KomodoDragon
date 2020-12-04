using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTeamRepo
{
    public class DevTeamRepo
    {
        private List<DevTeamContent> _listOfDevTeams = new List<DevTeamContent>();

        //Create
        public void AddNewTeam(DevTeamContent content)
        {
            _listOfDevTeams.Add(content);
        }

        //Read
        public List<DevTeamContent> GetDevTeamList()
        {
            return _listOfDevTeams;
        }

        //Update
        public bool UpdateTeam(int originalTeamData, DevTeamContent newTeamData)
        {
            //Find content
            DevTeamContent oldTeamData = GetDevTeamByID(originalTeamData);

            //Update content
            if (oldTeamData != null)
            {
                oldTeamData.TeamID = newTeamData.TeamID;
                oldTeamData.TeamName = newTeamData.TeamName;
                oldTeamData.ListOfDevs = newTeamData.ListOfDevs;
                return true;
            }
            else
            {
                return false;
            }
        }
        //public bool RemoveFromTeam()
        //{
        //    return false;
        //}
        //Delete
        public bool RemoveDevTeam(int identificationNumber)
        {
            DevTeamContent content = GetDevTeamByID(identificationNumber);

            if (content == null)
            {
                return false;
            }

            int initialCount = _listOfDevTeams.Count;
            _listOfDevTeams.Remove(content);

            if (initialCount > _listOfDevTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper Method
        public DevTeamContent GetDevTeamByID(int teamID)
        {
            foreach (DevTeamContent content in _listOfDevTeams)
            {
                if (content.TeamID == teamID)
                {
                    return content;
                }
            }

            return null;
        }
    }
}
