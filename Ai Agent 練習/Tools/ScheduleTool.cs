using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ai_Agent_練習.Tools
{
    internal class ScheduleTool : ATools
    {
        public override void Apply(AIResponse.Args args)
        {

            Console.WriteLine("您的行程如下");
            Console.WriteLine($" {String.Join("和", args.attendees)} 的{args.topic}的行程，將在{args.date_schedule}  {args.time_schedule}開始");

        }
    }
}
