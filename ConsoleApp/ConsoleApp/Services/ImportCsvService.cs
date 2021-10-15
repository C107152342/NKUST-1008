//using ConsoleApp.Models;
//using ConsoleApp.Models;
using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    public class ImportCsvService
    {
        public List<Camera> LoadFormFile(string filePath)
        {
            List<Camera> result = new List<Camera>();
            string[] lines = System.IO.File.ReadAllLines(filePath);
            result = lines.ToList().Skip(1).Select(x => 
                {
                    var columns = x.Split(',');
                    var item = new Camera()
                    {
                        編號 = columns[0],
                        行政區 = columns[1],
                        藥局名稱 = columns[2],
                        地址 = columns[3],
                        電話 = columns[4],
                        平價保險套來源 = columns[5],
                    };
                    //item.Datas["平價保險套來源"] = columns[5];
                    return item;
                }).ToList();

            return result;
            ////return cameras.ToList();
            //////return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Activity>>(str);
        }
    }
}
