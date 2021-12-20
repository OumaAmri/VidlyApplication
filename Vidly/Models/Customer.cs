﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribeToMovie { get; set; }

        public MemberShipType MemberShipType { get; set; }

        [Display(Name="Member ship type")]
        public short MemberShipTypeId { get; set; }
        
        [Display(Name="Date of birth")]
        public DateTime? DOB { get; set; }
    }
}