using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
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

        /// <summary>
        /// 新規BoardIDを取得します。
        /// </summary>
        /// <returns></returns>
        public long GetBoardID()
        {
            var rawQuery = Database.SqlQuery<long>(@"SELECT NEXT VALUE FOR BOARD_ID;");
            var task = rawQuery.SingleAsync();
            var res = task.Result;
            Debug.WriteLine(String.Format("#Log 新規BoardID = {0}", res));
            return res;
        }

        /// <summary>
        /// 新規PostsIDを取得します。
        /// </summary>
        public long GetPostsID()
        {
            var rawQuery = Database.SqlQuery<long>(@"SELECT NEXT VALUE FOR POSTS_ID;");
            var task = rawQuery.SingleAsync();
            var res = task.Result;
            Debug.WriteLine(String.Format("#Log 新規PostsID = {0}", res));
            return res;
        }

    }
}