using AppModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppInterface
{
    public class TokenService : ITokenService
    {

        protected HttpClient client;
        protected string baseUrl;
        //constructor
        public TokenService(HttpClient hClient, string url)
        {
            client = hClient;
            baseUrl = url;
        }

        public async Task<Token> GetToken()
        {
            var postContent = GetTokenPostCallContents();
            HttpResponseMessage response = await client.PostAsync(baseUrl, postContent);
            if (response.StatusCode.Equals(HttpStatusCode.Unauthorized))
            {
                throw new UnauthorizedAccessException("No access to the API");
            }

            var content = await response.Content.ReadAsStringAsync();
            Token tok = JsonConvert.DeserializeObject<Token>(content);
            return tok;
        }

        private HttpContent GetTokenPostCallContents()
        {
            var values = new Dictionary<string, string>
        {
           { "grant_type", "client_credentials" },
           { "client_id", "5614fb86-504d-481a-89d8-53737331d05c" },
            { "client_secret", "+mUUK0OuiMdfSaUI/fXkY2qyxcGREAXHFOBImLEZ5fM=" }
        };
            var content = new FormUrlEncodedContent(values);
            return content;
        }

    }
}