using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.DB
{
    /// <summary>
    /// 投稿されたメッセージのEntity
    /// </summary>
    [Table("POSTSMSG")]
    public class PostsMsgEntity
    {
        [Key]
        [Column("IDMSG")]
        public decimal IdMsg { get; set; }

        [Required]
        [Column("TITLE")]
        public string Title { get; set; }

        [Required]
        [Column("TEXT")]
        public string Text { get; set; }
    }
}