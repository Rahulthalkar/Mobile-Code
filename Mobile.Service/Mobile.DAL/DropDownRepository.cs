using Microsoft.Extensions.Configuration;
using Mobile.DAL.Interface;
using Mobile.DB;
using Mobile.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.DAL
{
    public class DropDownRepository : IDropDownRepository
    {
        private readonly string connectionString;
        private readonly IConfiguration _configuration;
        public DropDownRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = Convert.ToString(configuration.GetSection("ConnectionStrings:MB").Value);
        }
        public List<DropDownResponseModel> GetDropDown(string dropdownFor)
        {
            using (var dbContext = new DBEntities(connectionString))
            {
                var userModels = (from db in dbContext.Dropdowns
                                  where db.DropdownFor == dropdownFor
                                  select new DropDownResponseModel
                                  {
                                      Id = db.Id,
                                      DropdownFor = db.DropdownFor,
                                      Value = db.Value,
                                  }).ToList();
                return userModels;
            }
        }
    }
}
