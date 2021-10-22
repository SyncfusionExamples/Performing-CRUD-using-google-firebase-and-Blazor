using FirestoreBlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirestoreBlazorApp.Interface
{
    public interface IOrder
    {
        public Task<List<Order>> GetAllOrders();
        public void AddOrder(Order order);
        public void UpdateOrder(Order order);
        public void DeleteOrder(string orderId);
    }
}
