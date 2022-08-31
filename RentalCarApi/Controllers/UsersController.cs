using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentalCarCore.Dtos.Request;
using RentalCarCore.Interfaces;
using RentalCarInfrastructure.ModelImage;
using RentalCarInfrastructure.Models;
using Serilog;

namespace RentalCarApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IImageService _imageService;
        private readonly UserManager<User> _userManager;
        public UsersController(IUserService userService, IImageService imageService, UserManager<User> userManager)
        {
            _userService = userService;
            _imageService = imageService;
            _userManager = userManager;
        }
       
        [HttpGet("Id/GetUserTrips")]
        public async Task<IActionResult> GetUserTrips(string Id)
        {
            try
            {
                var result = await _userService.GetTrips(Id);
                if (result.IsSuccessful)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
            catch (ArgumentException ex)
            {
                Log.Logger.Error(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured we are working on it");
            }
        }

        
        [HttpPatch("Id/UploadImage")]
        public async Task<IActionResult> UploadImage(string Id, [FromForm] AddImageDto imageDto)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(Id);
                
                if(user != null)
                {
                    var upload = await _imageService.UploadAsync(imageDto.Image);
                    var result = new ImageAddedDto()
                    {
                        PublicId = upload.PublicId,
                        Url = upload.Url.ToString()
                    };

                    user.Avatar = result.Url;
                    user.PublicId = upload.PublicId;
                    await _userManager.UpdateAsync(user);
                    return Ok(result);
                }
                return NotFound("User not found");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpPut]
        [Route("Id")]
        public async Task<IActionResult> UpdatePassword(string Id, UpdateUserDto updateUserdDto)
        {


            //var userId = HttpContext.User.FindFirst(user => user.Type == ClaimTypes.NameIdentifier).Value;

            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (ModelState.IsValid)
                {
                    var result = await _userService.UpdateUserDetails(Id, updateUserdDto);
                    return Ok(result);
                }

                return BadRequest(ModelState);

            }
            catch (ArgumentException ex)
            {
                Log.Logger.Error(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Try again after 5 minutes");
            }

        }

       
        [HttpGet("Id")]
        public async Task<IActionResult>GetUser(string Id)
        {
            try
            {
                return Ok(await _userService.GetUser(Id));
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);

            }
        }

        [Authorize(Policy = "RequireAdminOnly")]
        [HttpGet()]
       public async Task<IActionResult> GetAllUser(int pageSize, int pageNumber)
        {
            var response = await _userService.GetUsersAsync(pageSize, pageNumber);
            return StatusCode((int)response.ResponseCode, response);
        }

        [AllowAnonymous]
        [HttpGet("GetAllDealers")]
        public async Task<IActionResult> GetAllDealer(int pageSize, int pageNumber)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await _userService.GetAllDealersAsync(pageSize, pageNumber);
                    return StatusCode((int)res.ResponseCode, res);
                }
                return BadRequest(ModelState);

            }
            catch (ArgumentException ex)
            {
                Log.Logger.Error(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured, try again after some time");
            }
        }

        [Authorize(Policy = "RequireAdminOnly")]
        [HttpGet("GetAllTrips")]
        public async Task<IActionResult> GetAllTrips(int pageSize, int pageNumber)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await _userService.GetAllTripsAsync(pageSize, pageNumber);
                    return StatusCode((int)res.ResponseCode, res);
                }
                return BadRequest(ModelState);

            }
            catch (ArgumentException ex)
            {
                Log.Logger.Error(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured, try again later");
            }
        }

        [Authorize(Policy = "RequireDealerOnly")]
        [HttpPost("AddNewDealer")]
        public async Task<IActionResult> AddNewDealer(DealerRequestDTO requestDTO)
        {
            try
            {
                var result = await _userService.AddDealer(requestDTO);
                if (result.IsSuccessful)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
            catch (ArgumentException ex)
            {
                Log.Logger.Error(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured we are working on it");
            }
        }

        [Authorize(Policy = "RequireAdminOnly")]
        [HttpPatch("DeleteUser")]
       
        public async Task<IActionResult> DeleteAUser(string userId)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var deletedUser = await _userService.DeleteUser(userId);
            return StatusCode((int)deletedUser.ResponseCode, deletedUser);
        }

        [Authorize(Policy = "RequireDealerAndCustomer")]
        [HttpGet("GetAllUserTransactionDetails")]
        public async Task<IActionResult> GetAllUserTransactionDetails(string userId)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var transactionDetails = await _userService.GetAllTransactionByUser(userId);
            return StatusCode((int) transactionDetails.ResponseCode, transactionDetails);
        }
    }
}