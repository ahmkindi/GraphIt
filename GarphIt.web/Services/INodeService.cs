using GraphIt.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphIt.web.Services
{
    public interface INodeService
    {
        Task<IEnumerable<Node>> GetNodes();
    }
}
