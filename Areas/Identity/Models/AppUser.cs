using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace test3.Areas.Identity.Models
{
    public class AppUser:IdentityUser
    {
        [Key]
        [Required(ErrorMessage = "M Number is required")]
        [RegularExpression(@"\d{8}")]
        [Display(Name = "M Number")]
        public int MNumber { get; set; }

        public string Name { get; set; }
        public string E_mail { get; set; }
        [Display(Name = "Personal LinkedIn Url")]
        public string LinkedIn { get; set; }
        public string Resume { get; set; }
        public byte[] Photo { get; set; }

    }
}
