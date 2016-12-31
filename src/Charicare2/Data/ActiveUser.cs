using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charicare2.Models;


namespace Charicare2.Data
{
    public class ActiveUser
    {
        // Make the class a singleton to maintain state across all uses
        private static ActiveUser _instance;

        public static ActiveUser Instance
        {
            get
            {
                // First time an instance of this class is requested
                if (_instance == null)
                {
                    _instance = new ActiveUser();
                }
                return _instance;
            }
        }

        public int DonateTypeId { get; set; }

        // To track the currently active customer - selected by user
        public Customer Customer { get; set; }
    }
}


    
