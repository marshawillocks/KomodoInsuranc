using Komodo_POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Repo  //where we build methods
{
     public class DeveloperRepo // Make this public
    {
        private List<DeveloperPOCO> _listOfDeveloper = new List<DeveloperPOCO>();

        
        //Create - Use .add method
        public bool AddDeveloper(DeveloperPOCO developer)
        {
            int initialCount = _listOfDeveloper.Count;  //inital count is how many items in the list before adding to it.
            _listOfDeveloper.Add(developer);

            if (initialCount < _listOfDeveloper.Count)
            {
                return true;
            }
            else
            {
                return false;
            }            
        }


        //Read - return list of developer
        public List<DeveloperPOCO> GetContentList()
        {
            return _listOfDeveloper;
        }
        
        
        
        //Update - Used to make changes
        public bool UpdateDeveloper(int id, DeveloperPOCO newDeveloper)
        {
            //find developer content
            DeveloperPOCO developer = GetDeveloperById(id);

            //update developer content
            if(developer == null)
            {
                return false;
            }
            else
            {
                developer.Name = newDeveloper.Name;
                developer.Id = newDeveloper.Id;
                developer.HavePluralSightAccess = newDeveloper.HavePluralSightAccess;
                return true;
            }
        }


        //Delete - Use .remove method
        public bool RemoveDeveloper(int id)
        {
            DeveloperPOCO developer = GetDeveloperById(id);

            if(developer == null)
            {
                return false;
            }

            int initialCount = _listOfDeveloper.Count;
            _listOfDeveloper.Remove(developer);

            if(initialCount > _listOfDeveloper.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Build helper method
        private DeveloperPOCO GetDeveloperById(int id)  //making sure we are changing the correct developer
        {
            foreach (DeveloperPOCO developer in _listOfDeveloper)
            {
                if(developer.Id == id)
                {
                    return developer;
                }
            }
            return null;
        }

    }
}
