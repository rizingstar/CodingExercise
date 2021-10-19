using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderApi.Model
{
    public class OrderRepository
    {
        List<Order> _orders = new List<Order>();
        public OrderRepository()
        {
            if (!_orders.Any())
                InitializeData();
        }

        public IEnumerable<Order> All
        {
            get { return _orders; }
        }

        public Order Find(int id)
        {
            return _orders.Find(x => x.Id == id);
        }

        public void Insert(Order Order)
        {
            _orders.Add(new Order() { OrderNumber = null, Status = "Pending", Total = null});
        }

        public void Update(int Id, string Status)
        {
            Find(Id).Status = Status;
        }

        public void Delete(int id)
        {
            _orders.Remove(Find(id));
        }

        private void InitializeData()
        {
            _orders.Add(new Order() { CreatedDate = DateTimeOffset.Now, CustomerId = 1, OrderNumber = 1, Status = "Pending" }) ;
        }
    }
}
