using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCRUDTest.Models
{
    public class Bug
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public int UserID { get; set; }
        public int StatusID { get; set; }
        public int TypeID { get; set; }
        public string Description { get; set; }
    }
}
