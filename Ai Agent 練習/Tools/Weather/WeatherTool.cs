using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static Ai_Agent_練習.AIResponse;
using static Ai_Agent_練習.Tools.Weather.WeatherResponse;

namespace Ai_Agent_練習.Tools.Weather
{
    internal class WeatherTool : ATools
    {
        public override void Apply(AIResponse.Args args)
        {
            //建立 WebRequest 並指定目標的 uri
            WebRequest request = WebRequest.Create($"https://api.weatherapi.com/v1/current.json?key=7dc75394bb7f4e00840102028252307&q={args.location}&aqi=no&lang=zh_tw");

            request.Method = "GET";
            using (var httpResponse = (HttpWebResponse)request.GetResponse())
            //使用 GetResponseStream 方法從 server 回應中取得資料，stream 必需被關閉
            //使用 stream.close 就可以直接關閉 WebResponse 及 stream，但同時使用 using 或是關閉兩者並不會造成錯誤，養成習慣遇到其他情境時就比較不會出錯
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                WeatherResponse res = JsonConvert.DeserializeObject<WeatherResponse>(result);
                Console.WriteLine("您的搜尋結果如下");
                Console.WriteLine($"{args.location}的氣溫為{res.current.temp_c}");
            }

        }

    }
}
