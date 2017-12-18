using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SciBuy.Infrastructure.Abstract;
using System.Collections;
using SciBuy.Models;
using System.Collections.Generic;
using SciBuy.Controllers;

namespace SciBuy.Tests.Controllers
{
    [TestClass]
    public class ArticleControllerTest
    {
        [TestMethod]
        public void ListCorrect()
        {
            Mock<IRepository> mock = new Mock<IRepository>();
            List<Article> list = new List<Article>()
            {
                new Article()
                {
                    PageId=1,
                    Title="test",
                    Content="",
                    Author=null
                }
            };
            mock.Setup(m => m.Articles).Returns(list);

            ArticleController controller = new ArticleController(mock.Object);

            List<Article> ret = (List<Article>)controller.List().Model;

            Assert.AreEqual(1, ret.Count);
        }
    }
}
