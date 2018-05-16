using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.DB
{
    /// <summary>
    /// Board情報保持Entity
    /// </summary>
    public class BoardInfoEnitity
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Body text
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Boardに登録されたMessageのリスト
        /// </summary>
        public ICollection<PostsMsgEntity> Messages { get; set; }
    }
}