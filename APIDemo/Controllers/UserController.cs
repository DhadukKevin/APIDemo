using APIDemo.BAL;
using APIDemo.DAL;
using APIDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace APIDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        #region GetAll
        [HttpGet]
        public IActionResult Get()
        {
            User_BALBase userBALBase = new User_BALBase();
            List<UserModel> userList = userBALBase.API_SELECT_ALL_USER();
            // Make the Response in Key Value Pair
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (userList.Count > 0 && userList != null)
            {
                response.Add("status", true);
                response.Add("message", "Data Found");
                response.Add("data", userList);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        #endregion

        #region GetByID
        [HttpGet("{UserID}")]
        public IActionResult Get(int UserID)
        {
            User_BALBase userBALBase = new User_BALBase();
            UserModel userModel = userBALBase.API_SELECT_BY_PK_USER(UserID);
            // Make the Response in Key Value Pair
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (userModel.UserID != 0)
            {
                response.Add("status", true);
                response.Add("message", "Data Found");
                response.Add("data", userModel);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        #endregion


        #region DELETE

        [HttpDelete("{UserID}")]
        public IActionResult Delete(int UserID)
        {
            User_BALBase userBALBase = new User_BALBase();
            var user = userBALBase.API_DELETE_USER(UserID);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();

            if (user != 0)
            {
                response.Add("status", true);
                response.Add("message", "Data Found");
                response.Add("data", user);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found");
                response.Add("data", null);
                return NotFound(response);
            }

        }
        #endregion


        #region Insert
        [HttpPost]
        public IActionResult post([FromBody] UserModel model)
        {
            if(model == null)
            {
                return NotFound();
            }
            UserModel modelUser = new UserModel();
            modelUser.Name = model.Name;
            modelUser.Email = model.Email;
            modelUser.Contact = model.Contact;
            User_BALBase userBALBase = new User_BALBase();
            userBALBase.API_INSERT_USER(modelUser);
            return CreatedAtAction(nameof(Get), new { id = model.UserID }, model);   
        }
        #endregion


        #region Update

        [HttpPut("{UserID}")]
        public IActionResult put(int UserID,USerPostModel model)
        {
            User_BALBase userBALBase = new User_BALBase();
            var user = userBALBase.API_UPDATE_USER(model,UserID);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();

            if (user != 0)
            {
                response.Add("status", true);
                response.Add("message", "Data Found");
                response.Add("data", user);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        #endregion


        #region Filter by Name and Email

        [HttpGet("{Name},{Email}")]
        public IActionResult filter(UserFilterModel model)
        {
            User_BALBase userBALBase = new User_BALBase();
            List<UserModel> userList = userBALBase.API_SELECT_FILTER(model);
            // Make the Response in Key Value Pair
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (userList.Count > 0 && userList != null)
            {
                response.Add("status", true);
                response.Add("message", "Data Found");
                response.Add("data", userList);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        #endregion
    }
}
