using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OneYearReign.Core.Models;
using OneYearReign.Core.Services;
using OneYearReign.Web.Controllers;
using OneYearReign.Web.ViewModels;

namespace OneYearReign.Web.Test.Unit.Controllers
{
    [TestClass]
    public class BandControllerTests
    {
        private Mock<IProfileService> _mockProfileService;

        private BandController _controller;

        [TestInitialize]
        public void Init()
        {
            _mockProfileService = new Mock<IProfileService>();

            _controller = new BandController(_mockProfileService.Object);
        }
        
        [TestMethod]
        public void About_ReturnsBandMembers()
        {
            var expected = new List<Member>()
                               {
                                   new Member() { Name = "Ken" },
                                   new Member() { Name = "Karen"}
                               };

            _mockProfileService.Setup(x => x.GetMembers()).Returns(expected);

            var result = _controller.About() as ViewResult;
            var vm = (AboutViewModel)result.ViewData.Model;

            Assert.AreEqual(2, vm.Members.Count());
            Assert.AreEqual(expected.First().Name, vm.Members.First().Name);
            Assert.AreEqual(expected.Last().Name, vm.Members.Last().Name);
        }
    }

}
