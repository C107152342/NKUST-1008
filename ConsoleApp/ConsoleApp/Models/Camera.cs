using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    public class Camera
    {
        internal string condom;//原為測照方向

        public string 編號 { get; set; }
        public string 行政區 { get; set; }
        public string 藥局名稱 { get; set; }
        public string 地址 { get; set; }
        public string 電話 { get; set; }
        public string 平價保險套來源 { get; set; }


        public Dictionary<string, string> Datas { get; set; }


        public Camera()
        {

            this.Datas = new Dictionary<string, string>();
        }
    }
}
