using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.DB
{
    /// <summary>
    /// 投稿されたメッセージのEntity
    /// </summary>
    public class PostsMsgEntity
    {
        [Key]
        public int IdMsg { get; set; }

        [Required]
        public string Text { get; set; }
    }
}