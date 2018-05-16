using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication2.Models.DB;

namespace WebApplication2.Service.DB
{
    /// <summary>
    /// DB層へのビジネスロジックを記載する。
    /// Repository共通IF
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        T GetOne(decimal id);

        IEnumerable<T> GetAll();

        /// <summary>
        /// 登録できた場合、BoardのIDを返却します。
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        decimal Add(T item);

        void Update(T item);

        void Delete(T item);
    }

    /// <summary>
    /// Board情報アクセス用Class
    /// </summary>
    public class BoardRepository : IRepository<BoardInfoEnitity>
    {

        private BoardDBContext dbContext = null;     // DBに接続しないのでとくに使っていない

        public BoardRepository() : this(null)
        {
           // this(null);         // C#ではこの書き方はできない。
        }
        public BoardRepository(BoardDBContext context)
        {
            // DBContextがnullの場合、New Incetanceを設定する。
            this.dbContext = context ?? new BoardDBContext();
        }

        public decimal Add(BoardInfoEnitity item)
        {
            // IDの採番処理が必要
            long id = this.dbContext.GetBoardID();
            item.Id = id;
            // TODO DBContextを使って作れる？
            this.dbContext.Boards.Add(item);
            int res = this.dbContext.SaveChanges();

            // エラー判定すること

            return item.Id;
        }

        public void Delete(BoardInfoEnitity item)
        {
            // TODO 特に処理なし
        }

        public IEnumerable<BoardInfoEnitity> GetAll()
        {
            // DBは使わないので固定値を返却する。
            IEnumerable <BoardInfoEnitity> res  = new List<BoardInfoEnitity>(){
                   new BoardInfoEnitity()  { Id = 2, Title = "Test", Body = "これはてすと" }
                ,      new BoardInfoEnitity()  { Id = 3, Title = "Test2", Body = "これはてすと２" }
            };
      
            return res;
        }

        public BoardInfoEnitity GetOne(decimal id)
        {
            return new BoardInfoEnitity() { Id =1, Title = "1つ", Body = "1Messageです" };
        }

        public void Update(BoardInfoEnitity item)
        {
            throw new NotImplementedException();
        }

    }
}