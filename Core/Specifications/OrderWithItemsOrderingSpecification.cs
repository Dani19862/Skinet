using System.Linq.Expressions;
using Core.Entities.OrderAggregate;

namespace Core.Specifications
{
    public class OrderWithItemsOrderingSpecification : BaseSpcification<Order>
    {
        public OrderWithItemsOrderingSpecification(string email) : base (o=> o.BuyerEmail ==  email)
        {
            AddInclude(o=> o.OrderItems);
            AddInclude(o=> o.DeliveryMethod);
            AddOrderByDescending(o=> o.OrderDate);
        }

        public OrderWithItemsOrderingSpecification(int id, string email) 
            : base(o=> o.Id == id && o.BuyerEmail == email)
        {
            AddInclude(o => o.OrderItems);
            AddInclude(o => o.DeliveryMethod);
        }
    }
}