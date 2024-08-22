using Microsoft.Extensions.Configuration;
using Mobile.DAL.Interface;
using Mobile.DB;
using Mobile.Domain;
using Mobile.Domain.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly string connectionString;
        private readonly IConfiguration _configuration;
        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = Convert.ToString(configuration.GetSection("ConnectionStrings:MB").Value);
        }

        public UserResponseModel GetUserDetails(int userId)
        {
            using (var dbcontext = new DBEntities(connectionString))
            {
                var list = (from user in dbcontext.Users
                            join drp in dbcontext.Dropdowns on user.ContryCodeId equals drp.Id 
                            where user.Id==userId
                            select new UserResponseModel
                            {
                                Id = user.Id,
                                Name = user.Name,
                                Phone = user.Phone,
                                CountryCodeId = user.ContryCodeId,
                                Value = drp.Value,
                            }).FirstOrDefault();
                return list;
            }
        }

        public int Registration(userRequestModel userRequest)
        {
            using (var dbContext = new DBEntities(connectionString))
            {
                
                var user = new tblUser
                {
                    Id = 0,
                    Name = userRequest.Name,
                    Phone = userRequest.Phone,
                    ContryCodeId = userRequest.CountryCodeId,
                    
                };
                dbContext.Users.Add(user);
                int retVal = dbContext.SaveChanges();

                return retVal;
            }
        }

        public int UpdateProfile(userRequestModel userRequest)
        {
            using (var dbContext = new DBEntities(connectionString))
            {

                var updateUser=(from usr in dbContext.Users
                                 where usr.Id==userRequest.Id select usr).FirstOrDefault();
               
                if (updateUser!=null)
                {
                    updateUser.Id = userRequest.Id;
                    updateUser.Name = userRequest.Name;
                    updateUser.Phone = userRequest.Phone;
                    updateUser.ContryCodeId = userRequest.CountryCodeId;
                }
                int retVal = dbContext.SaveChanges();

                return retVal;
            }

        }

        public List<UserResponseModel> ViewList()
        {
           using(var dbcontext=new DBEntities(connectionString))
            {
               var list=(from user in dbcontext.Users
                         join drp in dbcontext.Dropdowns on  user.ContryCodeId equals drp.Id
                          select new UserResponseModel
                          {
                              Id = user.Id,
                              Name = user.Name,
                              Phone = user.Phone,
                              CountryCodeId= user.ContryCodeId,
                              Value=drp.Value,
                          }).ToList();
                return list;
            }
        }
    }
}
