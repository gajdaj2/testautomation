using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Szkolenie.models;

namespace Szkolenie.test.rest
{

    [TestFixture]
    public class RestSharpTests
    {

        [Test]
        public void TestSimpleGET()
        {
            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("/posts/", Method.GET);
            var content = client.Execute(request).Content;
            Console.WriteLine(content);
        }

        [Test]
        public void TestSimpleGETJSONObj()
        {
            var deserial = new RestSharp.Serialization.Json.JsonSerializer();
            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("/posts/{postid}", Method.GET);
            request.AddUrlSegment("postid", 1);
            var content = client.Execute(request);
            var json = deserial.Deserialize<Dictionary<string, string>>(content);
            var result = json["author"];
            Assert.AreEqual(result, "typicode");
        }


        [Test]
        public void TestSimpleGETJSONObj2()
        {
            var deserial = new JsonDeserializer();
            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("/posts/{postid}", Method.GET);
            request.AddUrlSegment("postid", 1);
            var response = client.Execute(request);
            JObject JSONObj = JObject.Parse(response.Content);
            Console.WriteLine(JSONObj["author"]);
            Assert.That(JSONObj["author"].ToString(), Is.EqualTo("typicode"), "Autor nie ten sam");
        }


        [Test]
        public void TestSimpleGETPOCO()
        {
            var deserial = new JsonDeserializer();
            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("/posts/{postid}", Method.GET);
            request.AddUrlSegment("postid", 1);
            var content = client.Execute(request).Content;
            var post = JsonConvert.DeserializeObject<Post>(content);
            Assert.AreEqual(post.author, "typicode");
        }

        [Test]
        public void TestSimplePost()
        {
            var employee = new
            {
                first_name = "Ann",
                last_name = "Smith",
                email = "ann@codingthesmartway.com"
            };

            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("/employees/", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(employee);
            var content = client.Execute(request).Content;
            var data = JsonConvert.DeserializeObject<Employee>(content);
            Assert.AreEqual(data.first_name, "Ann");
        }
        [Test]
        public void TestSimplePost2()
        {
            var employee = new
            {
                first_name = "Ann",
                last_name = "Smith",
                email = "ann@codingthesmartway.com"
            };

            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("/employees/", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(employee);
            var content = client.Execute(request).Content;
            var data = JsonConvert.DeserializeObject<Employee>(content);
            Assert.AreEqual(data.first_name, "Ann");
        }









    }
}
