using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Domain.Table
{
    public class tblUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int ContryCodeId { get; set; }
        [ForeignKey("ContryCodeId")]
        public tblDropdown? tblDropdown { get; set; }

    }
}
