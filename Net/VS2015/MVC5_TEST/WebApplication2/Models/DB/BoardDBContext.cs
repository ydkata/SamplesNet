using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.DB
{
    /// <summary>
    /// DB接続管理クラス
    /// </summary>
    public class BoardDBContext : DbContext
    {
        /// <summary>
        /// BaseのConstractorを呼ぶ
        /// </summary>
        public BoardDBContext() : base( "DefaultConnection" )
        {
        }

        public virtual DbSet<BoardInfoEnitity> Boards { get; set; }
    }
}