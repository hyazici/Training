using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerManagementApp.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Lütfen doğru Email adresi giriniz")]
        public string EmailAddress { get; set; }

        [Required]
        public string HomeAddress { get; set; }

        [Required]
        public string WorkAddress { get; set; }
    }
}