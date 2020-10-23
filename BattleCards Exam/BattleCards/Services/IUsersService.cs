using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.Services
{
    public interface IUsersService
    {
        string GetUserId(string username, string password);

        void Create(string username, string email, string password);
        
        bool IUsernameAvaialble(string username);
        
        bool IEmailAvaialble(string email);

    }
}
