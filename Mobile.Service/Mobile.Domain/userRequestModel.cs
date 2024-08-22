using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Domain
{
    public class userRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int CountryCodeId { get; set; }
    }
    public class UserResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int CountryCodeId { get; set; }
        public string Value { get; set; }

    }

    public class DropDownResponseModel
    {
        public int Id { get; set; }
        public string DropdownFor { get; set; }
        public string Value { get; set; }
    }
}
