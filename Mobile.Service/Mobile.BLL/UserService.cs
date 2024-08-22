using Microsoft.Extensions.Configuration;
using Mobile.DAL.Interface;
using Mobile.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.BLL
{
    public class UserService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly IDropDownRepository _dropDownRepository;
        public UserService(IUserRepository userRepository,IDropDownRepository dropDownRepository, IConfiguration configuration) 
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _dropDownRepository = dropDownRepository;
        }
        public APIResult<bool> Register(userRequestModel userRequest )
        {
            APIResult<bool> result = new APIResult<bool>();
            try
            {
                var retValue = _userRepository.Registration(userRequest);
                if (retValue == 0)
                {
                    result.Value = false;
                }
                else
                {
                    result.Value = true;
                }
                result.IsSuccess = true;
            }
            catch (Exception exception)
            {
                result.ExceptionInfo = exception.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        public APIResult<List<DropDownResponseModel>> GetDropDown(string dropdownFor)
        {
            APIResult<List<DropDownResponseModel>> result = new APIResult<List<DropDownResponseModel>>();
            try
            {
                result.Value = _dropDownRepository.GetDropDown(dropdownFor);
                result.IsSuccess = true;
            }
            catch (Exception exception)
            {
                result.ExceptionInfo = exception.Message;
                result.IsSuccess = false;
            }
            return result;
        }
        public APIResult<List<UserResponseModel>> ViewList()
        {
            APIResult<List<UserResponseModel>> result = new APIResult<List<UserResponseModel>>();
            try
            {
                result.Value =_userRepository.ViewList();
                result.IsSuccess = true;
                result.ExceptionInfo = "Fatch the data list";
            }
            catch (Exception exception)
            {
                result.ExceptionInfo = exception.Message;
                result.IsSuccess = false;
                result.ExceptionInfo = "Failed to fatch the data list";

            }
            return result;
        }
        public APIResult<UserResponseModel>GetUserDetails(int userId)
        {
            APIResult<UserResponseModel> result = new APIResult<UserResponseModel>();
            try
            {
                var userProfile = _userRepository.GetUserDetails(userId);
               
                    result.IsSuccess = true;
                    result.Value = userProfile;
                    return result;
            }
            catch (Exception exception)
            {
                result.IsSuccess = false;
                result.Value = null;
                result.ErrorMessageKey = "UnableToFetchUserData";
                result.ExceptionInfo = exception.Message;   
                return result;
            }

        }

        public APIResult<bool> UpdateProfile(userRequestModel userRequest)
        {
            APIResult<bool> result = new APIResult<bool>();
            try
            {
                var retValue = _userRepository.UpdateProfile(userRequest);
                if (retValue == 0)
                {
                    result.Value = false;
                    result.ErrorMessageKey = "invalidID";
                }
                else
                {
                    result.Value = true;
                    result.ExceptionInfo = "updatedSuccessfully";

                }
                result.IsSuccess = true;
            }
            catch (Exception exception)
            {
                result.ExceptionInfo = exception.Message;
                result.IsSuccess = false;
                result.ErrorMessageKey = "failedToUpdate";
            }
            return result;
        }
    }
}
