using OrdersService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersService.Metods
{
    internal class WriteFiles
    {
        public void WriteFile(List<DeliveryOrder> orders, string resultFilePath)
        {
            try
            {
                using (var writer = new StreamWriter(resultFilePath))
                {
                    foreach (var order in orders)
                    {
                        writer.WriteLine($"{order.OrderId}; {order.Weight}; {order.District}; {order.DeliveryTime}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при записи результата: {ex.Message}");
            }
        }
    }
}
