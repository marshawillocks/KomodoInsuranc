using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_POCO
{
    public class DevTeamPOCO // This is the object
    {
        //Create Properties - Team members, Team Names, Team ID
        public string TeamMemberName { get; set; }
        public string TeamName { get; set; }
        public int TeamId { get; set; }


        //Make empty constructor- dont forget (){}
        public DevTeamPOCO() { }


        //Fill in constructor- dont forget (){}
        public DevTeamPOCO(string teamName, int teamId)
        {            
            TeamName = teamName;
            TeamId = teamId;
        }
    }
}
