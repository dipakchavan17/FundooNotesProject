using CommonLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businesslayer.Interface
{
    public interface IUserBL
    {
        public UserEntity Registration(UserRegistration user);
        public string login(UserLogin userLogin);
        public string ForgetPassword(String email);
        public bool ResetPassword(string email, string password, string confirmpassword);
    }
}
