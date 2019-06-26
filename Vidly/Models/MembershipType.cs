﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public string NameofSubscription  { get; set; }
        public short SignupFees { get; set; }
        public byte DurationInMonths { get; set; }
        public byte Discount { get; set; }
    }
}