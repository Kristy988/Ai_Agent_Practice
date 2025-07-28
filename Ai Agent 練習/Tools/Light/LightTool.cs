using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ai_Agent_練習.Tools
{
    internal class LightTool : ATools
    {
        public override void Apply(AIResponse.Args args)
        {
            Console.WriteLine("以下是幫你調節的燈光模式");
            Console.WriteLine("色溫" + args.color_temp);
            Console.WriteLine("亮度" + args.brightness);
        }
    }
}
