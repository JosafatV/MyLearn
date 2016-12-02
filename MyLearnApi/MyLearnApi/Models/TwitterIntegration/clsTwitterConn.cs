using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tweetinvi;

namespace MyLearnApi.Models.TwitterIntegration
{
    /// <summary>
    /// clase que se conecta con tiwtter
    /// </summary>
    public class clsTwitterConn
    {
        private string consumerKey { get; set; }
        private string consumenSecret { get; set; }
        private string userAccessToken { get; set; }
        private string userAccessSecret { get; set; }

       

        public string twitt(string twitt)
        {
            Auth.SetUserCredentials(consumerKey, consumenSecret,
                userAccessToken, userAccessSecret);
            var user = Tweetinvi.User.GetAuthenticatedUser();
            //sends tweet
            var tweet = Tweet.PublishTweet(twitt);

            return twitt;

        }

        /// <summary>
        /// Setters
        /// </summary>
        /// <param name="key"></param>
        public void setConsumerKey(string key)
        {
            this.consumerKey = key;
        }
        public void setConsumerSecret(string secret)
        {
            this.consumenSecret = secret;
        }
        public void setUserAccessToken(string token)
        {
            this.userAccessToken = token;
        }
        public void setUserAccessSecret(string secret)
        {
            this.userAccessSecret = secret;
        }
    }
}