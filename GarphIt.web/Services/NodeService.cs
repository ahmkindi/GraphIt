using GraphIt.models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GraphIt.web.Services
{
    public class NodeService : INodeService
    {
        private readonly HttpClient httpClient;

        public NodeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<Node>> GetNodes()
        {
            return await httpClient.GetJsonAsync<Node[]>("api/nodes");
        }
    }
}
