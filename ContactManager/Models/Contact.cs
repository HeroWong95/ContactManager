using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactManager.Models
{
    /// <summary>
    /// 联系人实体
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// 联系人id
        /// </summary>
        public int ContactId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        //[Display(Name = "姓名")]
        [StringLength(16,ErrorMessage ="长度在2-16之间",MinimumLength =2)]
        public string Name { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Required]
        //[Display(Name = "地址")]
        [StringLength(16, ErrorMessage = "长度在2-16之间", MinimumLength = 2)]
        public string Address { get; set; }

        /// <summary>
        /// 别称
        /// </summary>
        [Required]
        //[Display(Name = "别称")]
        [StringLength(16, ErrorMessage = "长度在2-16之间", MinimumLength = 2)]
        public string NickName { get; set; }
    }
}