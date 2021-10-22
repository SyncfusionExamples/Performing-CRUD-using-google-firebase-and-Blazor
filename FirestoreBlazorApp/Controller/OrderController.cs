using FirestoreBlazorApp.DataAccess;
using FirestoreBlazorApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirestoreBlazorApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        OrderDataAccessLayer objOrder = new OrderDataAccessLayer();

        [HttpGet]
        public async Task<object> Get()
        {
            var data = objOrder.GetAllOrders().Result.ToList();
            var queryString = Request.Query;
            if (queryString.Keys.Contains("$inlinecount"))
            {
                StringValues Skip;
                StringValues Take;
                int skip = (queryString.TryGetValue("$skip", out Skip)) ? Convert.ToInt32(Skip[0]) : 0;
                int top = (queryString.TryGetValue("$top", out Take)) ? Convert.ToInt32(Take[0]) : data.Count();
                var count = data.Count();
                return new { Items = data.Skip(skip).Take(top), Count = count };
            }
            else
            {
                return data;
            }
        }

        [HttpPost]
        public void Post([FromBody] Order order)
        {
            objOrder.AddOrder(order);
        }

        [HttpPut]
        public void Put([FromBody] Order order)
        {
            objOrder.UpdateOrder(order);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            objOrder.DeleteOrder(id);
        }
    }
}
