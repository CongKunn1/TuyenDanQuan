using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Model
{
    public class Unit : BaseEntity
    {

        public string Code { get; set; }

        public string UnitName { get; set; }

        public string UnitType { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

    }

}