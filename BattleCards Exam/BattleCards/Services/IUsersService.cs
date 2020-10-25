﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.Services
{
    public interface IUsersService
    {
        string GetUserId(string username, string password);

        string Create(string username, string email, string password);
        
        bool IsUsernameAvailable(string username);
        
        bool IsEmailAvailable(string email);
    }
}
