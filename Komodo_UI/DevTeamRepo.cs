using Komodo_POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Repo
    // Used to build methods
{
    public class DevTeamRepo           
    {
        private List<DevTeamPOCO> _listDevTeam = new List<DevTeamPOCO>();
        private DevTeamPOCO _devTeam = new DevTeamPOCO();

       //Create - add method
       public bool AddDevTeam(DevTeamPOCO member) 
        {
            // Make initial count variable
            int initialCount = _listDevTeam.Count;

            // Add team member
            _listDevTeam.Add(member);

            //check to see if initial count < list count
            if (initialCount < _listDevTeam.Count)
            {
                return true;
            }          
            
                return false;            
        }
        
        //Read - return list
        public List<DevTeamPOCO> GetDevTeamList()
        {
            return _listDevTeam;
        }

        
        //Update - used to make changes
        public bool UpdateMember(int id, DevTeamPOCO newMember)
        {
            // Find member content
            DevTeamPOCO member = GetMemberById(id);

            //update member content
            if(member == null)
            {
                return false;
            }
            else
            {
                member.TeamMemberName = newMember.TeamMemberName;
                member.TeamName = newMember.TeamName;
                member.TeamId = newMember.TeamId;
                return true;
            }
        }
                  

        //Delete - used to remove 
        public bool RemoveMember(int id)
        {
            // Verify member id
            DevTeamPOCO member = GetMemberById(id);
            
            if (member == null)
            {
                return false;
            }

            // Make initial count variable
            int initialCount = _listDevTeam.Count;

            // Delete Team member from list
            _listDevTeam.Remove(member);            
            
            // Check to see if initial count , list count
            if(initialCount > _listDevTeam.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

       
       //Build helper method
       private DevTeamPOCO GetMemberById (int id)
        {
            foreach (DevTeamPOCO member in _listDevTeam)
            {
                if (member.TeamId == id)
                {
                    return member;
                }              
            }
            return null;
        }

    }
}
