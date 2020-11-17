using GarphIt.api.Models;
using GraphIt.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GarphIt.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EdgesController : ControllerBase
    {
        private readonly IEdgeRepository edgeRepository;

        public EdgesController(IEdgeRepository edgeRepository)
        {
            this.edgeRepository = edgeRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetEdges()
        {
            try
            {
                return Ok(await edgeRepository.GetEdges());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Edge>> GetEdge(int id)
        {
            try
            {
                var result = await edgeRepository.GetEdge(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Edge>> CreateEdge([FromBody] Edge edge)
        {
            try
            {
                if (edge == null)
                    return BadRequest();

                var createdEdge = await edgeRepository.AddEdge(edge);

                return CreatedAtAction(nameof(GetEdge),
                    new { id = createdEdge.EdgeId }, createdEdge);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new Edge record");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Edge>> UpdateEdge(Edge edge)
        {
            try
            {
                var edgeToUpdate = await edgeRepository.GetEdge(edge.EdgeId);

                if (edgeToUpdate == null)
                    return NotFound($"Edge with Id = {edge.EdgeId} not found");

                return await edgeRepository.UpdateEdge(edge);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Edge>> DeleteEdge(int id)
        {
            try
            {
                var edgeToDelete = await edgeRepository.GetEdge(id);

                if (edgeToDelete == null)
                {
                    return NotFound($"Edge with Id = {id} not found");
                }

                return await edgeRepository.DeleteEdge(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
