using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ai_Agent_練習.AIRequest;

namespace Ai_Agent_練習.Tools.Schedule
{
    internal class ScheduleParameter : AParameters
    {
        public override object properties => new
        {
            attendees = new PropertyDetail()
            {
                type = "array",
                description = "列出所有參與的人員，其中必須包含我自己:Kristy",
                items = new ItemType() { type = "string" }
            },
            date_Schedule = new PropertyDetail()
            {
                type = "string",
                description = "行程的日期，如2025-01-01"
            },
            time_Schedule = new PropertyDetail()
            {
                type = "string",
                description = "行程的時間，如23:59"
            },
            topic = new PropertyDetail()
            {
                type = "string",
                description = "該行程的目的或主題"
            }
        };

        public override string[] required => new string[] { "attendees", "date_Schedule", "time_Schedule", "topic" };

    }
}
