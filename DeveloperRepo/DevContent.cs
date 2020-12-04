using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperRepo
{
    public class DevContent
    {
        //POCO Plain Old CSharp 
        public string FullName { get; set; }

        public int IdentificationNumber { get; set; }

        public bool AccessPlural { get; set; }

        public DevContent() { }

        public DevContent(string fullName, int identificationNumber, bool accessplural)
        {
            FullName = fullName;
            IdentificationNumber = identificationNumber;
            AccessPlural = accessplural;
        }

    }
}
