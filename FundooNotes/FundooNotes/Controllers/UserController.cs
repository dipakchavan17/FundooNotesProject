using Businesslayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FundooNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL userBL;
        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;

        }
        [HttpPost("Register")]
        public IActionResult Registration(UserRegistration user)
        {
            try
            {
                var result=userBL.Registration(user);
                if (result != null)
                    return this.Ok(new { success = true, message = "Registration successful", data = result });
                else
                    return this.BadRequest(new { success = false, message = "Registration unsuccessful" });


            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpPost("Login")]
        public IActionResult login(UserLogin userLogin)
        {
            try
            {
                var result = userBL.login(userLogin);
                if (result != null)
                    return this.Ok(new { success = true, message = "Login successful", data = result });
                else
                    return this.BadRequest(new { success = false, message = "Login unsuccessful" });


            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpPost("forgotPassword")]
        public IActionResult ForgetPassword(string email)
        {
            try
            {
                var result = userBL.ForgetPassword(email);
                if (result != null)
                    return this.Ok(new { success = true, message = "mail sent  successful" });
                else
                    return this.BadRequest(new { success = false, message = "enter valid email" });


            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpPut("ResetPassword")]
        public IActionResult ResetPassword(string password,string confirmpassword)
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email).Value.ToString();
                var user = userBL.ResetPassword(email, password, confirmpassword);
                if (!user)
                {
                    return this.BadRequest(new { success = false, message = "enter valid password" });

                }



                else
                {
                    return this.Ok(new { success = true, message = "reset password is successful" });
                }
            



            }
            catch (System.Exception)
            {

                throw;
            }
        }


    }
}
