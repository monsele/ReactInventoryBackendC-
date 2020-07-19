using ReactInventorySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactInventorySystem.Services
{
    public interface IRequest
    {
        IEnumerable<Request> GetRequests();
        Request GetRequest(int? id);
        void Create(Request request);
        void Delete(int? id);
        void handleRequest(Request request);
        
    }
}
