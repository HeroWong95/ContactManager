using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactManager.Models
{
    public class Contact
    {
        public int ContactId { get; set; }

        [Required]
        //[Display(Name = "姓名")]
        [StringLength(16,ErrorMessage ="长度在2-16之间",MinimumLength =2)]
        public string Name { get; set; }

        [Required]
        //[Display(Name = "地址")]
        [StringLength(16, ErrorMessage = "长度在2-16之间", MinimumLength = 2)]
        public string Address { get; set; }

        [Required]
        //[Display(Name = "别称")]
        [StringLength(16, ErrorMessage = "长度在2-16之间", MinimumLength = 2)]
        public string NickName { get; set; }
    }
}