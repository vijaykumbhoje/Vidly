using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
       
        [Display(Name="Date of Birth")]
        [Ismember18YearsOld]
        public DateTime? DateOfBirth { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        [Display(Name ="Membership Type")]
        public MembershipType MembershipType { get; set; }

       
        public Byte MembershipTypeId { get; set; }
    }
}