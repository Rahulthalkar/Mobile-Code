using Mobile.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.DAL.Interface
{
    public interface IDropDownRepository
    {
        public List<DropDownResponseModel> GetDropDown(string dropdownFor);
    }
}
