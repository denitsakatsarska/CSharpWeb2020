﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Transactions;

namespace Git.Models
{
    public class Repository
    {
        public Repository()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Commits = new HashSet<Commit>();
        }


        public string Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Name { get; set; }


        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public bool IsPublic { get; set; }
        public string OwnerId { get; set; }

        public User Owner { get; set; }

        //може и да трябва да се смени
        public ICollection<Commit> Commits { get; set; }
    }
}
