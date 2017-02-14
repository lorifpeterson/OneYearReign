using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OneYearReign.Core.Interfaces;
using OneYearReign.Core.Models;
using OneYearReign.Core.Services;
using OneYearReign.Web.Controllers;
using OneYearReign.Web.ViewModels;

namespace OneYearReign.Web.Test.Unit.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {
        private Mock<IProfileService> _mockProfileService;
        private Mock<INewsService> _mockNewsService;
        private HomeController _controller;

        [TestInitialize]
        public void Setup()
        {
            _mockProfileService = new Mock<IProfileService>();
            _mockNewsService = new Mock<INewsService>();

            _controller = new HomeController(_mockProfileService.Object, _mockNewsService.Object);
        }
        [TestMethod]
        public void Index_ReturnsProfileDescription()
        {
            var expected = new Profile()
                               {
                                   Description = "My Band's description.",
                               };

            _mockProfileService.Setup(x => x.GetBandProfile()).Returns(expected);
            var result = _controller.Index() as ViewResult;
            var data = (HomePageViewModel)result.ViewData.Model;

            Assert.AreEqual(expected.Description, data.Description);
        }

        [TestMethod]
        public void Index_ReturnsProfileSocialNetworks()
        {
            var expected = new Profile()
            {
                SocialNetworks = new List<SocialNetwork>()
                                                       {
                                                           new SocialNetwork()
                                                               {
                                                                   Name = "twitter",
                                                                   Url = "http://mytwitter.com"
                                                               }
                                                       }
            };

            _mockProfileService.Setup(x => x.GetBandProfile()).Returns(expected);
            var result = _controller.Index() as ViewResult;
            var data = (HomePageViewModel)result.ViewData.Model;

            Assert.AreEqual(expected.SocialNetworks.First().Name, data.SocialNetworks.First().Name);
            Assert.AreEqual(expected.SocialNetworks.First().Url, data.SocialNetworks.First().Url);
        }

        [TestMethod]
        public void Index_ReturnsProfileLatestSingle()
        {
            var expected = new Album()
                                   {
                                       Name = "name",
                                       Image = new Image()
                                                   {
                                                       Link = "my link",
                                                       Text = "my text",
                                                       Source = "my source"
                                                   },
                                       PublishDate = new DateTime(2013, 01, 05),
                                   };

            _mockProfileService.Setup(x => x.GetBandProfile()).Returns(new Profile() { LatestSingle = expected });
            var result = _controller.Index() as ViewResult;

            var data = (HomePageViewModel)result.ViewData.Model;

            Assert.AreEqual(expected.Name, data.LatestSingle.Name);
            Assert.AreEqual(expected.PublishDate, data.LatestSingle.PublishDate);
            Assert.AreEqual(expected.Image.Link, data.LatestSingle.Image.Link);
            Assert.AreEqual(expected.Image.Text, data.LatestSingle.Image.Text);
            Assert.AreEqual(expected.Image.Source, data.LatestSingle.Image.Source);
        }

        [TestMethod]
        public void News_CanGetNewsMessage()
        {
            var expected = new NewsItem()
                    {
                        CreatedDate = new DateTime(2013, 02, 24),
                        Message = "This is my awesome news article! http://mywebsite.com",
                    };

            _mockProfileService.Setup(x => x.GetBandProfile()).Returns(new Profile());
            _mockNewsService.Setup(x => x.GetLatestNews(It.IsAny<int>())).Returns(new List<NewsItem>() { expected });

            var result = _controller.News() as ViewResult;

            var data = (NewsItemsViewModel)result.ViewData.Model;

            var actual = data.News.First();

            Assert.AreEqual(expected.CreatedDate, actual.CreatedDate);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void News_CanGetNewsImage()
        {
            var expected = new NewsItem()
            {
                Image = new Image() { Text = "image text", Source = "image link" }
            };

            _mockProfileService.Setup(x => x.GetBandProfile()).Returns(new Profile());
            _mockNewsService.Setup(x => x.GetLatestNews(It.IsAny<int>())).Returns(new List<NewsItem>() { expected });

            var result = _controller.News() as ViewResult;

            var data = (NewsItemsViewModel)result.ViewData.Model;

            var actual = data.News.First();
            Assert.AreEqual(expected.Image.Text, actual.Image.Text);
            Assert.AreEqual(expected.Image.Source, actual.Image.Source);
        }

        [TestMethod]
        public void News_CanGetNewsVideo()
        {
            var expected = new NewsItem()
            {
                Video = new Video() { Source = "http://source.mp4"}
            };

            _mockProfileService.Setup(x => x.GetBandProfile()).Returns(new Profile());
            _mockNewsService.Setup(x => x.GetLatestNews(It.IsAny<int>())).Returns(new List<NewsItem>() { expected });

            var result = _controller.News() as ViewResult;

            var data = (NewsItemsViewModel)result.ViewData.Model;

            var actual = data.News.First();

            Assert.AreEqual(expected.Video.Source, actual.Video.Source);
            Assert.AreEqual(expected.Video.Type, actual.Video.Type);
        }

    }
}
