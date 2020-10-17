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

        public async Task<Node> GetNode(int id)
        {
            return await httpClient.GetJsonAsync<Node>($"api/nodes/{id}");
        }

        public async Task<Node> UpdateNode(Node updatedNode)
        {
            return await httpClient.PutJsonAsync<Node>("api/nodes", updatedNode);
        }

        public async Task<Node> AddNode(Node newNode)
        {
            return await httpClient.PostJsonAsync<Node>("api/nodes", newNode);
        }

        public async Task DeleteNode(int id)
        {
            await httpClient.DeleteAsync($"api/nodes/{id}");
        }
    }
}
