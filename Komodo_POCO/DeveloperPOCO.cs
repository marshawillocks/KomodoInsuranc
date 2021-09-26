using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_POCO
{
    public class DeveloperPOCO   //This is the object
    {
        //Create Properties - need ID, name, and if they have pluralsight access
        public string Name { get; set; }
        public int Id { get; set; }
        public bool HavePluralSightAccess { get; set; }

        //Make empty constructor- dont forget (){}
        public DeveloperPOCO() {}

        //Fill in constructor- dont forget (){}
        public DeveloperPOCO(string name, int id, bool havePluralSightAcess)
        {
            Name = name;
            Id = id;
            HavePluralSightAccess = havePluralSightAcess;
        }        
    }
}
