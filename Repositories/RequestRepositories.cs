using ReactInventorySystem.Data;
using ReactInventorySystem.Models;
using ReactInventorySystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactInventorySystem.Repositories
{
    public class RequestRepositories : IRequest
    {
        private readonly ApplicationDbContext context;
        public RequestRepositories(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Create(Request request)
        {
            context.Set<Request>().Add(request);
            context.SaveChanges();
        }

        public void Delete(int? id)
        {
            var entity=context.Set<Request>().Find(id);
            context.Set<Request>().Remove(entity);
            context.SaveChanges();
        }

        public Request GetRequest(int? id)=>context.Set<Request>().FirstOrDefault(x => x.id == id);

        

        public IEnumerable<Request> GetRequests()=>context.Set<Request>().ToList();

        public void handleRequest(Request request)
        {
            var entity = context.Set<Product>().FirstOrDefault(x => x.Id == request.ProductId);
            int entityAmount = entity.AmountInStock;
            int Amt = request.AmountRequested;
            //string message=;
            if (entityAmount < Amt)
            {
                throw new Exception();
            }
            entity.AmountInStock = entity.AmountInStock - Amt;
            request.isAccept = true;
            context.Set<Product>().Update(entity);
            context.Set<Request>().Update(request);
            context.SaveChanges();
        }
    }
}
