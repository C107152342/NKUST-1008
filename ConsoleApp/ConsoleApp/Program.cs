using ConsoleApp.Units;
using System;
using System.Linq;
using ConsoleApp.Services;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string fullFileName=FilePath.GetFullPath("2020-06arti.csv");

            var csvService = new ConsoleApp.Services.ImportCsvService();
            DataService dataService = new DataService();

            var csvDatas=csvService.LoadFormFile(fullFileName);


            csvDatas.ForEach(i =>
            {
                dataService.Insert(i);
            });
            //dataService.GetCamera();
            var rows = dataService.GetCamera();


            Console.WriteLine(string.Format("分析完成,共有{0}筆資料", rows.Count));

            var groupDatas = csvDatas.GroupBy(x => x.行政區, y => y).ToList();
            rows.ForEach(x =>
            {
                Console.WriteLine($"編號:{x.編號}地點:{x.行政區}地址:{x.地址}藥局名稱:{x.藥局名稱}電話:{x.電話}平價保險套來源:{x.平價保險套來源}");
            });
            Console.ReadKey();
        }
    }
}
