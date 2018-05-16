using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using WebApplication2.Models;
using WebApplication2.Models.DB;
using WebApplication2.Service.DB;

namespace WebApplication2.Service
{

    /// <summary>
    /// Board操作に関するビジネスロジックを記載する。
    /// ServiceIF
    /// </summary>
    public interface IBoardService {
        decimal Create(BoardCreateInfoMdl pMdl);
        BoardInfoMdl Get(BoardInfoMdl pMdl);
    }



    /// <summary>
    /// ビジネスロジッククClass
    /// Repositoryを操作してDataを取得したりします。
    /// </summary>
    public class BoardService : IBoardService, IDisposable
    {
        // The Repository access BoardInfo-Table 
        private IRepository<BoardInfoEnitity> rep = null;

        public BoardService ()
        {

        }

        public BoardService(IRepository<BoardInfoEnitity> rep)
        {
            this.rep = rep;
            Debug.WriteLine("Log# BoardService instance was created.");
        }

        /// <summary>
        /// ボードを作成する。
        /// </summary>
        /// <param name="mdl"></param>
        public decimal Create(BoardCreateInfoMdl pMdl)
        {
            BoardInfoEnitity mdl = new BoardInfoEnitity();
            mdl.Title = pMdl.Title;
            mdl.Body = pMdl.Body;
            return rep.Add(mdl);
        }

        /// <summary>
        /// ボードを作成する。
        /// </summary>
        /// <param name="mdl"></param>
        public BoardInfoMdl Get(BoardInfoMdl pMdl)
        {
            BoardInfoEnitity resEnt = rep.GetOne(pMdl.Id);
            BoardInfoMdl resMdl = new BoardInfoMdl();
            resMdl.Id = resEnt.Id;
            resMdl.Title = resEnt.Title;
            resMdl.Body = resEnt.Body;
            return resMdl;
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}