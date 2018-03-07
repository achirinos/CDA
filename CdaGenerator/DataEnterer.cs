using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdaGenerator
{
    public class DataEnterer
    {
        public DateTime Date { get; set; }

        public string UserId { get; set; }

        public string UserFullName { get; set; }

        public DataEnterer()
        {
                
        }

        public DataEnterer(DateTime date, string userId, string userFullName)
        {
            Date = date;
            UserId = userId;
            UserFullName = userFullName;
        }
    }
}
