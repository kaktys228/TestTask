using Microsoft.Extensions.Configuration;
using OrdersService.Logi;
using OrdersService.Metods;
using OrdersService.Models;


namespace OrdersService 
{
    internal class Program
    {
        static void Main(string[] args)
        {
          

            string district = args[0];
            DateTime firstDeliveryTime = DateTime.Parse(args[1]);
            string logFilePath = args[2];
            string resultFilePath = args[3];
            string ordersFilePath = args[4];



            Logger logger = new Logger(logFilePath);
            logger.Log("Программа запущена");

            ReadFiles readFiles = new ReadFiles();
            var orders = readFiles.ReadOrders(ordersFilePath);

            OrderFilter filter = new OrderFilter();
            var filteredOrders = filter.FilterOrders(orders, district, firstDeliveryTime);

            WriteFiles resultWriter = new WriteFiles();
            resultWriter.WriteFile(filteredOrders, resultFilePath);

            logger.Log("Фильтрация завершена");
        }
    }
}