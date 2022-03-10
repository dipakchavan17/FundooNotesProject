﻿using Businesslayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businesslayer.Service
{
    public class UserBL : IUserBL
    {
        private readonly IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }
        public UserEntity Registration(UserRegistration user)
        {
            try
            {
                return userRL.Registration(user);

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}