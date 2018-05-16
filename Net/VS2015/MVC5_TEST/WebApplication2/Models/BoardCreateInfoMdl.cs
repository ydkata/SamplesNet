using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    /// <summary>
    /// Board作成情報保持Model
    /// </summary>
    public class BoardCreateInfoMdl
    {
        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Body text
        /// </summary>
        public string Body { get; set; }

    }
}