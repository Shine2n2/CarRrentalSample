using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalsApp_WEB.Models
{
    public class HttpCommandHandler : IHttpCommandHandler, IDisposable
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _client = new HttpClient();
        

        public HttpCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _client.BaseAddress = new Uri(_configuration.GetSection("BaseAddress").Value);
            
        }

        #region Api Request handlers
        public async Task<TRes> PostRequest<TRes, TReq>(TReq requestModel, string requestUrl)
            where TRes : class
            where TReq : class
        {
            return await PostRequestAsync<TReq, TRes>(requestUrl, requestModel);
        }

        public async Task<TRes> UpdateRequest<TRes, TReq>(TReq requestModel, string requestUrl)
            where TRes : class
            where TReq : class
        {
            return await UpdateRequestAsync<TReq, TRes>(requestModel, requestUrl);
        }

        public async Task<TRes> GetRequest<TRes>(string requestUrl)
           where TRes : class
        {
            return await GetRequestAsync<TRes>(requestUrl);
        }

        public async Task<TRes> DeleteRequest<TRes>(Guid id)
          where TRes : class
        {
            return await DeleteRequestAsync<TRes>(id);
        }
        #endregion

        #region Implementatioin details
        private async Task<TRes> GetRequestAsync<TRes>(string requestUrl) where TRes : class
        {
            var client = CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            return await GetResponseResultAsync<TRes>(client, request);
        }

        private async Task<TRes> DeleteRequestAsync<TRes>(Guid id) where TRes : class
        {
            var client = CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Delete, id.ToString());
            return await GetResponseResultAsync<TRes>(client, request);
        }

        private async Task<TRes> UpdateRequestAsync<TReq, TRes>(TReq requestModel, string requestUrl) where TRes : class where TReq : class
        {
            var caller = CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Put, requestUrl)
            {
                Content = new StringContent(JsonConvert.SerializeObject(requestModel), Encoding.UTF8, "application/json")
            };
            return await GetResponseResultAsync<TRes>(caller, request);
        }

        private async Task<TRes> PostRequestAsync<TReq, TRes>(string requestUrl, TReq requestModel)
            where TReq : class
            where TRes : class
        {
            var caller = CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, requestUrl)
            {
                Content = new StringContent(JsonConvert.SerializeObject(requestModel), Encoding.UTF8, "application/json")
            };
            return await GetResponseResultAsync<TRes>(caller, request);
        }

        private async Task<TRes> GetResponseResultAsync<TRes>(HttpClient clientCaller, HttpRequestMessage request) where TRes : class
        {
            var response = await clientCaller.SendAsync(request);
            if (!response.IsSuccessStatusCode) throw new ArgumentException(response.ReasonPhrase);
            var responseString = await response.Content.ReadAsStringAsync();
            //Dispose();
            var result = JsonConvert.DeserializeObject<TRes>(responseString);
            return result;
        }

        public async Task<TRes> UploadFileAsync<TReq, TRes>(string requestUrl, TReq file) where TReq : IFormFile where TRes : class
        {
            var client = CreateClient();
            var form = new MultipartFormDataContent();
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var fileContent = new ByteArrayContent(memoryStream.ToArray());
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                form.Add(fileContent, nameof(file), file.FileName);
            }
            var request = new HttpRequestMessage(HttpMethod.Patch, requestUrl) { Content = form };
            return await GetResponseResultAsync<TRes>(client, request);
        }


        private HttpClient CreateClient()
        {
            
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return _client;
        }

        public void Dispose()
        {
            _client.Dispose();
        }

        #endregion
    }
}