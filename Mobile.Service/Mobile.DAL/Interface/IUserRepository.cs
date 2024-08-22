using Mobile.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.DAL.Interface
{
    public interface IUserRepository
    {
        public int Registration(userRequestModel userRequest);
        public List<UserResponseModel>ViewList();
        public UserResponseModel GetUserDetails(int userId);
        public int UpdateProfile(userRequestModel userRequest);

    }
}
