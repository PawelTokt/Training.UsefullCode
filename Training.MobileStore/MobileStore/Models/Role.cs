﻿using System.Collections.Generic;

namespace MobileStore.Models
{
    public class Role
    {
        public Role()
        {
            Users = new List<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}