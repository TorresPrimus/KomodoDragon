using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperRepo
{
    public class DevRepo
    {
        private List<DevContent> _listOfDevelopers = new List<DevContent>();

        //Create
        public void AddDevToList(DevContent content)
        {
            _listOfDevelopers.Add(content);
        }

        //Read
        public List<DevContent> GetDevList()
        {
            return _listOfDevelopers;
        }

        //Update
        public bool UpdateDevContent(int originalID, DevContent newID)
        {
            //Find content
            DevContent oldID = GetDevContentByID(originalID);

            //Update content
            if (oldID != null)
            {
                oldID.IdentificationNumber = newID.IdentificationNumber;
                oldID.FullName = newID.FullName;
                oldID.AccessPlural = newID.AccessPlural;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveDevFromList(int identificationNumber)
        {
            DevContent content = GetDevContentByID(identificationNumber);

            if (content == null)
            {
                return false;
            }

            int initialCount = _listOfDevelopers.Count;
            _listOfDevelopers.Remove(content);

            if (initialCount > _listOfDevelopers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        //helper method
        public DevContent GetDevContentByID(int identificationNumber)
        {
            foreach(DevContent content in _listOfDevelopers)
            {
                if(content.IdentificationNumber == identificationNumber)
                {
                    return content;
                }
            }

            return null;
        }
    }
}
