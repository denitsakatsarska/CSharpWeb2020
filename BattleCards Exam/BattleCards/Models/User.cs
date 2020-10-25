﻿using SIS.MvcFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BattleCards.Models
{
    public class User : IdentityUser<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Cards = new HashSet<UserCard>();
        }

        public virtual ICollection<UserCard> Cards { get; set; }
    }
}