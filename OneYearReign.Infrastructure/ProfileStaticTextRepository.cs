using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using OneYearReign.Core.Interfaces;
using OneYearReign.Core.Models;

namespace OneYearReign.Infrastructure
{
    public class ProfileStaticTextRepository : IProfileRepository
    {

        
        public Profile GetProfile()
        {
            return new Profile()
                       {
                           Description = "One Year Reign is an alternative rock band from New Lenox, IL. A band that is constantly influenced by life and the social interactions that we all go through.",
                           SocialNetworks = GetSocialNetworks(),
                           LatestSingle = GetLatestSingle()
                       };
        }

        private Album GetLatestSingle()
        {
            return new Album()
                       {
                           Name = "Stay Silent",
                           Image = new Image()
                                       {
                                           Link = "http://staysilentradioedit.viinyl.com/",
                                           Text = "Stay Silent Single, One Year Reign",
                                           Source = @"http://a5.mzstatic.com/us/r30/Music/v4/ef/99/b7/ef99b727-e783-768d-b25c-e03dd6b7b58e/887516217838.170x170-75.jpg"
                                       }
                           
                       };
        }

        private IList<SocialNetwork> GetSocialNetworks()
        {
            var networks = new List<SocialNetwork>()
                               {
                                    new SocialNetwork()
                                        {
                                            Name = "Tumblr",
                                            Url = @"http://oneyearreign.tumblr.com"
                                        },
                                   new SocialNetwork()
                                       {
                                           Name = "Youtube",
                                           Url = @"http://www.youtube.com/user/oneyearreignn"
                                       },
                                    new SocialNetwork()
                                        {
                                            Name = "Twitter",
                                            Url = @"http://twitter.com/oneyearreign"
                                        },
                                   new SocialNetwork()
                                       {
                                           Name = "Facebook",
                                           Url = @"http://www.facebook.com/oneyearreign"
                                       }
                               };
            return networks;
        }

    
    }
}
