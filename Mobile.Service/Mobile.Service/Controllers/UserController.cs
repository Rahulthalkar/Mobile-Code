using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mobile.BLL;
using Mobile.DAL.Interface;
using Mobile.Domain;

namespace Mobile.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(IUserRepository userRespository,IDropDownRepository dropDownRepository, IConfiguration configuration)
        {
            _userService = new UserService(userRespository, dropDownRepository, configuration); 
        }
        [Route("Register")]
        [HttpPost]
        [ProducesResponseType(typeof(APIResult<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(APIResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Register(userRequestModel userRequest)
        {
            
            if (ModelState.IsValid)
            {
                var responseOfRegistration = _userService.Register(userRequest);
                if (responseOfRegistration.IsSuccess)
                {
                    
                    return Ok(responseOfRegistration);
                }
                else
                {
                   
                    return BadRequest(responseOfRegistration);
                }
            }
            else
            {
                var message = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return BadRequest("Model is Invalid. Validation Errors: " + message);
            }
        }
        [Route("UpdateProfile")]
        [HttpPost]
        [ProducesResponseType(typeof(APIResult<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(APIResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateProfile(userRequestModel userRequest)
        {

            if (ModelState.IsValid)
            {
                if (userRequest.Id==0)
                {
                    return BadRequest();
                }
                var response = _userService.UpdateProfile(userRequest);
                if (response.IsSuccess)
                {

                    return Ok(response);
                }
                else
                {

                    return BadRequest(response);
                }
            }
            else
            {
                var message = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return BadRequest("Model is Invalid. Validation Errors: " + message);
            }
        }
        [Route("ViewList")]
        [HttpPost]
        [ProducesResponseType(typeof(APIResult<List<UserResponseModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResult<List<UserResponseModel>>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ViewList()
        {
            var responseOfUserlist = _userService.ViewList();
            if (responseOfUserlist.IsSuccess)
            {
                return Ok(responseOfUserlist);
            }
            else
            {
                return BadRequest(responseOfUserlist);
            }
        }
        [Route("GetDropDown")]
        [HttpPost]
        [ProducesResponseType(typeof(APIResult<List<DropDownResponseModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResult<List<DropDownResponseModel>>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetDropDown(string dropdownFor)
        {
            if (dropdownFor == null)
            {
                return BadRequest(dropdownFor);
            }
            var responseOfDropDown = _userService.GetDropDown(dropdownFor);
            if (responseOfDropDown.IsSuccess)
            {
                return Ok(responseOfDropDown);
            }
            else
            {
                return BadRequest(responseOfDropDown);
            }
        }
        [Route("GetUserDetails")]
        [HttpPost]
        [ProducesResponseType(typeof(APIResult<UserResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(APIResult<UserResponseModel>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUserDetails(int userId)
        {
            if(userId == null)
            {
                return BadRequest(userId);
            }
            var responseOfUser = _userService.GetUserDetails(userId);
            if (responseOfUser.IsSuccess)
            {
                return Ok(responseOfUser);
            }
            else
            {
                return BadRequest(responseOfUser);
            }
        }

    }
}
