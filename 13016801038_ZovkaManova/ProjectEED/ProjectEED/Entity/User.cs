﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEED.Entity
{
 public class User
    {
        public int ID { get; set; }

        public int RoleID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public override string ToString()
        {
            return Firstname +" "+Lastname + " ("+Email+")";
        }
    }
}
