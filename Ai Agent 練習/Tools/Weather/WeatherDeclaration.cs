using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ai_Agent_練習.AIRequest;

namespace Ai_Agent_練習.Tools.Weather
{
    internal class WeatherDeclaration : AFunctiondeclaration
    {
        public override string name => "Tools.Weather.WeatherTool";

        public override string description => "該函數用來搜尋輸入的地名對應的氣溫狀況";

        public override AParameters parameters => new WeatherParameter();
    }
}
