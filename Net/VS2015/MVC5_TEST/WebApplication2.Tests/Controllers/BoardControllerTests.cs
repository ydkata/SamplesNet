using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication2.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Service;
using Moq;

namespace WebApplication2.Controllers.Tests
{
    [TestClass()]
    public class BoardControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            // Dummy Serviceの作成
            var mocSrv = new Mock<IBoardService>();
            var controller = new BoardController(mocSrv.Object);
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        [HttpPost]
        public void CreateTest()
        {
            // Dummy Serviceの作成
            var mocSrv = new Mock<IBoardService>();
            // 引数がBoardCreateInfoMdl型であれば、"Success"を返す。
            mocSrv.Setup(p => p.Create(It.IsAny<BoardCreateInfoMdl>())).Returns("Success");
            var controller = new BoardController(mocSrv.Object);

            var mdl = new BoardCreateInfoMdl(){ Title = "タイトル", Body = "本文" };
            var result = controller.Create(mdl) as ViewResult;
          ///  Assert.IsNotNull(result);

            // Createが呼ばれたかチェック
            mocSrv.Verify(m => m.Create(It.IsAny<BoardCreateInfoMdl>()), Times.Once);

        }
    }
}