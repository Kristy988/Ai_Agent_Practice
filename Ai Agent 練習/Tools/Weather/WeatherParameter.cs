using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ai_Agent_練習.AIRequest;

namespace Ai_Agent_練習.Tools.Weather
{
    internal class WeatherParameter : AParameters
    {
        public override object properties => new
        {
            location = new PropertyDetail()
            {
                type = "string",
                description = "取得詢問氣溫的縣市地名"
            }
        };

        public override string[] required => new string[] { "location" };
    }
}
