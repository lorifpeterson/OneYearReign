using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Facebook;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OneYearReign.Infrastructure.Tests.Integration
{
    [TestClass]
    public class FacebookTests
    {
        private const string AccessToken = "229476660510789|twqbYmKET7G3dD3W3VkNiEb-KLs";

        [TestMethod]
        public void Get_WithoutUsingAccessToken_ReturnsPublicData()
        {
            var client = new FacebookClient();
            dynamic result = client.Get("oneyearreign");

            Assert.IsNotNull(result);
            Console.WriteLine(result.likes);
        }

        [TestMethod]
        public void Get_UsingClientCredentials_ReturnsApplicationToken()
        {
            var fb = new FacebookClient();

            dynamic result = fb.Get("oauth/access_token", new
            {
                client_id = "229476660510789",
                client_secret = "5351f7121b43055985786a73267d9a93",
                grant_type = "client_credentials"
            });            

            Assert.IsNotNull(result);
            Assert.AreEqual(result.access_token, AccessToken);
        }

        [TestMethod]
        public void Get_PostsWithLimit_ReturnsCorrectNumberOfPosts()
        {
            var expected = 5;
            var fb = new FacebookClient(AccessToken);
            
            dynamic result = fb.Get("oneyearreign/posts?limit=" + expected);

            Assert.AreEqual(expected, result.data.Count);
        }

        [TestMethod]
        public void Get_PostsWithField_ReturnsMessageField()
        {
            //oneyearreign?fields=posts.fields(message,link,picture,name,description,created_time,type,source)
            //fields=posts.limit(5).fields(message,link,picture,name,description,created_time,type,source)

            var fb = new FacebookClient(AccessToken);

            dynamic result = fb.Get("oneyearreign?fields=posts.limit(1).fields(message)");

            Console.WriteLine(result);
            Assert.IsNotNull(result.posts[0].message);
        }
    }
}
