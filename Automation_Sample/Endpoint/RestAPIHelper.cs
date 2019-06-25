using Automation_Sample.ParametersPost;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Sample.Endpoint
{
    public static class RestAPIHelper
    {
        public static RestClient client;
        public static RestRequest restRequest;
        public static string baseUrl = " http://localhost:3000/";

        // Get the url
        public static RestClient SetUrl(string endpoint)
        {

            return client = new RestClient(baseUrl);
        }

        // Create a Request
        public static RestRequest CreateRequest()
        {
            restRequest = new RestRequest("posts/{postid}", Method.GET);
            restRequest.AddUrlSegment("postid", 1);
            return restRequest;
        }
        // Get the  Response 
        public static IRestResponse GetResponse()
        {
            var content = client.Execute(restRequest).Content;
            Console.WriteLine(content);
            return client.Execute(restRequest);
        }

        // Create a post Request 
        public static RestRequest CreatePostRequest()
        {
            var userInfo = new PostsParameter();
            userInfo.id = "5";
            userInfo.title = "selnium book";
            userInfo.author = "sahoo1";
            var resource = "posts";
            restRequest = new RestRequest(resource, Method.POST);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddBody(userInfo);
            Console.WriteLine(restRequest);
            return restRequest;

        }

    }
}



