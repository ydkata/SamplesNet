using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Models.DB;
using WebApplication2.Service.DB;
using Moq;
using WebApplication2.Models;

namespace WebApplication2.Service.Tests
{
    [TestClass()]
    public class BoardServiceTests
    {
        [TestMethod()]
        /// <summary>
        /// データ取得のテスト。
        /// Repository部分はMockでテストするよ。
        /// </summary>
        public void GetOneTest()
        {
            var condition = new BoardInfoMdl() { Id = "TST001", Title = "", Body = "" };

            // Repository部分はMock化し、Servie部分のみテストする。
            // Dummy Entityの作成
            var resEntity = new BoardInfoEnitity() {Id = "TST001", Title = "AABBCC", Body = "aaabbbccc"};
            // DummyRepositoryの作成
            var mockRep = new Mock<IRepository<BoardInfoEnitity>>();
            mockRep.Setup(p  => p.GetOne("TST001")).Returns(resEntity) ;    // "TST001"がセットされたら、resEntityを返す。

            // Test
            BoardService srv = new BoardService(mockRep.Object);
            var resMdl = srv.Get(condition);

            // Check Result
            Assert.AreEqual("TST001", resMdl.Id);
            Assert.AreEqual("AABBCC", resMdl.Title);
            Assert.AreEqual("aaabbbccc", resMdl.Body);
        }

        [TestMethod()]
        /// <summary>
        /// データ取得のテスト。
        /// Repository部分はMockでテストするよ。
        /// </summary>
        public void AddTest()
        {
            var condition = new BoardCreateInfoMdl() { Title = "XXXX1", Body = "XXXX2" };

            // Repository部分はMock化し、Servie部分のみテストする。
            // Dummy Entityの作成
            var addEntity = new BoardInfoEnitity() { Id = String.Empty, Title = "XXXX1", Body = "XXXX2" };
            // DummyRepositoryの作成
            var mockRep = new Mock<IRepository<BoardInfoEnitity>>();
            // Add Methodの引数のIdがNullのとき、"DummyID"を返す。
            mockRep.Setup(p => p.Add(It.Is<BoardInfoEnitity>(m => String.IsNullOrEmpty(m.Id)))).Returns("DummyID");

            // Test
            BoardService srv = new BoardService(mockRep.Object);
            string resId = srv.Create(condition);

            // Check Result
            Assert.AreEqual("DummyID", resId);
        }
    }
}