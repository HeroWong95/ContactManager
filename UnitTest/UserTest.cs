using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void TestPost()
        {
            HttpClient client = new HttpClient();

            var response = client.PostAsync("http://localhost:63466/api/User", new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("UserName", "a"),
                new KeyValuePair<string, string>("Password", "b")
            })).Result;
            Assert.AreEqual(response.StatusCode, HttpStatusCode.Unauthorized);

            var response2 = client.PostAsync("http://localhost:63466/api/User", new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("UserName", "a"),
                new KeyValuePair<string, string>("Password", "a")
            })).Result;
            Assert.AreEqual(response2.StatusCode, HttpStatusCode.OK);
        }
    }
}
