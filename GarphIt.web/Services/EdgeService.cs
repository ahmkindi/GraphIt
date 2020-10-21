using GraphIt.models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GraphIt.web.Services
{
    public class EdgeService : IEdgeService
    {
        private readonly HttpClient httpClient;

        public EdgeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<Edge>> GetEdges()
        {
            return await httpClient.GetJsonAsync<Edge[]>("api/edges");
        }

        public async Task<Edge> GetEdge(int id)
        {
            return await httpClient.GetJsonAsync<Edge>($"api/edges/{id}");
        }

        public async Task<Edge> UpdateEdge(Edge updatedEdge)
        {
            return await httpClient.PutJsonAsync<Edge>("api/edges", updatedEdge);
        }

        public async Task<Edge> AddEdge(Edge newEdge)
        {
            return await httpClient.PostJsonAsync<Edge>("api/edges", newEdge);
        }

        public async Task DeleteEdge(int id)
        {
            await httpClient.DeleteAsync($"api/edges/{id}");
        }
    }
}
