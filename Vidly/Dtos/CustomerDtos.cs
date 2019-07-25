using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDtos
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
     
      //  [Ismember18YearsOld]~
        public DateTime? DateOfBirth { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipTypeDtos MembershipType { get; set; }

        public Byte MembershipTypeId { get; set; }
    }
}