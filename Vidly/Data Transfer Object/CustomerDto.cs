using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.Data_Transfer_Object
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribeToMovie { get; set; }          
        public short MemberShipTypeId { get; set; }      
        [Min18YearsIfAMember]
        public DateTime? DOB { get; set; }
    }
}