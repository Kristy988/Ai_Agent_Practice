using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ai_Agent_練習.AIRequest;

namespace Ai_Agent_練習.Tools.Light
{
    internal class LightParameter : AParameters
    {
        public override object properties => new
        {
            brightness = new PropertyDetail()
            {
                type = "integer",
                description = "燈光強度0-100，0表示熄滅，100表示全亮"
            },
            color_temp = new PropertyDetail()
            {
                type = "string",
                @enum = new string[] { "日光", "冷光", "暖光" },
                description = "燈光有三種固定的色溫：日光、冷光、暖光.類型。你會需要根據使用者給的意圖或是情境自行帶入或者決定。例如:電影模式採用冷光，浪漫模式採用暖光，依次列推。"
            }
        };

        public override string[] required => new string[] { "brightness", "color_temp" };
    }
}
