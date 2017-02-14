using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OneYearReign.Core.Interfaces;
using OneYearReign.Core.Models;
using OneYearReign.Core.Services;

namespace OneYearReign.Core.Test.Unit
{
    [TestClass]
    public class ProfileServiceTests
    {
        Mock<IProfileRepository> _mockRepository;
        Mock<IMemberRepository> _mockMemberRepository;

        private ProfileService _profileService;

        [TestInitialize]
        public void Setup()
        {
            _mockRepository =  new Mock<IProfileRepository>();
            _mockMemberRepository = new Mock<IMemberRepository>();

            _profileService = new ProfileService(_mockRepository.Object, _mockMemberRepository.Object);
        }

        [TestMethod]
        public void CanGetWelcomeContent()
        {
            var expected = "My Description";
            _mockRepository.Setup(x => x.GetProfile()).Returns(new Profile() {Description = expected});

            var profileService = _profileService;
            var result = profileService.GetBandProfile();
            
            Assert.AreEqual(expected, result.Description);
        }

        [TestMethod]
        public void CanGetSocialNetworks()
        {
            var expected = new List<SocialNetwork>()
                               {
                                   new SocialNetwork()
                                       {
                                           Name = "facebook",
                                           Url = @"http:\\facebook\myurl"
                                       }
                               };

            _mockRepository.Setup(x => x.GetProfile()).Returns(new Profile() {SocialNetworks =  expected });

            var result = _profileService.GetBandProfile().SocialNetworks;
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void CanGetLatestAlbum()
        {
            var expected = new Album()
                               {
                                   Name = "My album name",
                                   Image = new Image() { Link = @"http:\\my.link.com", Text = "alt text", Source = @"http:\\my picture" },
                                   PublishDate = new DateTime(2013, 01, 01)
                               };

            _mockRepository.Setup(x => x.GetProfile()).Returns(new Profile() {LatestSingle = expected});

            var result = _profileService.GetBandProfile().LatestSingle;
            
            Assert.AreEqual(expected.Name, result.Name);
            Assert.AreEqual(expected.PublishDate, result.PublishDate);
            Assert.AreEqual(expected.Image.Link, result.Image.Link);
            Assert.AreEqual(expected.Image.Text, result.Image.Text);
            Assert.AreEqual(expected.Image.Source, result.Image.Source);
        }
    }
}
