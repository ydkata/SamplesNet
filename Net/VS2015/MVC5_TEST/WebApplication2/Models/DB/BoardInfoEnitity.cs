using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.DB
{
    /// <summary>
    /// Board情報保持Entity
    /// </summary>
    [Table("BOARDINFO")]
    public class BoardInfoEnitity
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [Column("ID")]
        public decimal Id { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [Column("TITLE")]
        public string Title { get; set; }

        /// <summary>
        /// Body text
        /// </summary>
        [Column("BODY")]
        public string Body { get; set; }

        /// <summary>
        /// Boardに登録されたMessageのリスト
        /// </summary>
        [Column("MESSAGES")]
        public ICollection<PostsMsgEntity> Messages { get; set; }
    }
}