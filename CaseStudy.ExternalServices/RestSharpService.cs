using CaseStudy.Core.Utils.Results;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.ExternalServices
{
    public class RestSharpService
    {
        public async Task<RestResponse<T>> Execute<T>(string url, Method method = Method.Get, CancellationToken cancellationToken = default)
        {
            var client = new RestSharp.RestClient(url);
            var request = new RestRequest(url, method);
            var response = await client.ExecuteAsync<T>(request);
            return response;
        }
        public async Task<RestResponse<T>> ExecuteWithParameter<T>(string url, object parameters, Method method = Method.Get, CancellationToken cancellationToken = default)
        {
            var client = new RestSharp.RestClient(url);
            var request = new RestRequest(url, method);
            if (parameters != null)
            {
                request.AddObject(parameters);
            }
            var response = await client.ExecuteAsync<T>(request);
            return response;
        }
    }
}
