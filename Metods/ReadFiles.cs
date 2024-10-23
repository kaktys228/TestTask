using OrdersService.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace OrdersService.Metods
{
    internal class ReadFiles
    {
        public List<DeliveryOrder> ReadOrders(string filePath)
        {
            var orders = new List<DeliveryOrder>();

            try
            {
                var lines = File.ReadAllLines(filePath);

                foreach (var line in lines)
                {           
                    var parts = line.Split(';'); 
               
                    var orderIdPart = parts[0].Trim();
                    var weightPart = parts[1].Trim(); 
                    var districtPart = parts[2].Trim();
                    var deliveryTimePart = parts[3].Trim();
                    if (!double.TryParse(weightPart,  out double weight) || weight <= 0)
                    {
                        Console.WriteLine($"Ошибка: Вес должен быть положительным числом. Строка: '{line}'");
                        continue; 
                    }
                    if (string.IsNullOrWhiteSpace(orderIdPart))
                    {
                        throw new ArgumentException("ID заказа не может быть пустым.");
                    }
                    if (string.IsNullOrWhiteSpace(districtPart))
                    {
                        throw new ArgumentException("Район доставки не может быть пустым.");
                    }
                    try
                    {                      
                         orders.Add(new DeliveryOrder
                         {
                                    OrderId = orderIdPart,
                                    Weight = weight,
                                    District = districtPart,
                                    DeliveryTime = DateTime.Parse( deliveryTimePart)
                         });;                   
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка при добавлении заказа {orderIdPart}: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            }

            return orders;
        }
    }
}
