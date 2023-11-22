using GoogleFirebase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleFirebase.Interface
{
    public interface IOrder
    {
        public Task<List<Order>> GetAllOrders();
        public void AddOrder(Order order);
        public void UpdateOrder(Order order);
        public void DeleteOrder(string orderId);
    }
}
