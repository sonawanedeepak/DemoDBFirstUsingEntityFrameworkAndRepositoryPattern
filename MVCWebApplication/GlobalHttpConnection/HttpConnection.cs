using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace MVCWebApplication.GlobalHttpConnection
{
    public static class HttpConnection
    {
        public static HttpClient webAPIClient = new HttpClient();
        static HttpConnection()
        {
            webAPIClient.BaseAddress = new Uri("http://localhost:1051/api/");
            webAPIClient.DefaultRequestHeaders.Clear();
            webAPIClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}