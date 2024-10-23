using System;
using System.Collections.Generic;
using System.Linq;
using OrdersService.Models;

namespace OrdersService.Metods
{
    internal class OrderFilter
    {
        public List<DeliveryOrder> FilterOrders(List<DeliveryOrder> orders, string district, DateTime firstDeliveryTime)
        {
            if (orders == null || orders.Count == 0)
            {
                Console.WriteLine("Нет заказов для фильтрации.");
                return new List<DeliveryOrder>();
            }

         
            var filteredOrders = orders.Where(o =>
                o.District.Equals(district, StringComparison.OrdinalIgnoreCase) &&
                o.DeliveryTime >= firstDeliveryTime &&
                o.DeliveryTime <= firstDeliveryTime.AddMinutes(30)).ToList();

           
            Console.WriteLine($"Найдено отфильтрованных заказов: {filteredOrders.Count}");
            foreach (var order in filteredOrders)
            {
                Console.WriteLine($"OrderId: {order.OrderId}, Weight: {order.Weight}, District: {order.District}, DeliveryTime: {order.DeliveryTime}");
            }

            return filteredOrders;
        }
    }
}