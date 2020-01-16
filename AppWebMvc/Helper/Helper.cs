using System;
using System.Net.Http;

namespace AppWebMvc.Helper
{
    public class StudentApi
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:44379/");

            return client;
        }
    }
}
