﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2.Models
{
    public class Member
    {
        public int Id { get; set; }
        public int MemberNr { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}