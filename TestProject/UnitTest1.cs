using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MovieService.Areas.Identity.Data;
using MovieService.Controllers;
using MovieService.Models;
using MovieService.Repositories;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var error = new ErrorViewModel();

            error.RequestId = "123";
            Assert.True(error.ShowRequestId);

            error.RequestId = "";
            Assert.False(error.ShowRequestId);

            error.RequestId = null;
            Assert.False(error.ShowRequestId);
        }
        [Fact]
        public void Test2()
        {
            var mock = new Mock<ILogger<HomeController>>();
            var controller = new HomeController(mock.Object);
            Assert.IsType<ViewResult>(controller.Index());
        }
        private List<Watchlist> Watchlists()
        {
            return new List<Watchlist> { 
                new Watchlist { ID = 1, UserID="1", MovieID=1 }, 
                new Watchlist { ID = 2, UserID="1", MovieID=2} };
        }
    }
}
