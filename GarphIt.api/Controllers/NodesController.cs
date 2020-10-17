using GarphIt.api.Models;
using GraphIt.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GarphIt.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodesController : ControllerBase
    {
        private readonly INodeRepository nodeRepository;

        public NodesController(INodeRepository nodeRepository)
        {
            this.nodeRepository = nodeRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetNodes()
        {
            try
            {
                return Ok(await nodeRepository.GetNodes());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Node>> GetNode(int id)
        {
            try
            {
                var result = await nodeRepository.GetNode(id);

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
        public async Task<ActionResult<Node>> CreateNode([FromBody] Node node)
        {
            try
            {
                if (node == null)
                    return BadRequest();

                var createdNode = await nodeRepository.AddNode(node);

                return CreatedAtAction(nameof(GetNode),
                    new { id = createdNode.NodeId }, createdNode);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new Node record");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Node>> UpdateNode(Node node)
        {
            try
            {
                var nodeToUpdate = await nodeRepository.GetNode(node.NodeId);

                if (nodeToUpdate == null)
                    return NotFound($"Node with Id = {node.NodeId} not found");

                return await nodeRepository.UpdateNode(node);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Node>> DeleteNode(int id)
        {
            try
            {
                var nodeToDelete = await nodeRepository.GetNode(id);

                if (nodeToDelete == null)
                {
                    return NotFound($"Node with Id = {id} not found");
                }

                return await nodeRepository.DeleteNode(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
