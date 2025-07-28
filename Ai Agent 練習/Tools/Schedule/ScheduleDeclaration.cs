using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ai_Agent_練習.AIRequest;

namespace Ai_Agent_練習.Tools.Schedule
{
    internal class ScheduleDeclaration : AFunctiondeclaration

    {
        public override string name => "Tools.Schedule.ScheduleTool";

        public override string description => "該函數主要用來安排一個行程，使用者會告知你主題、時間、日期和與會人員，你需要針對使用者給的資訊，主動紀錄該行程，如果沒有與會人員的話，請直接填入Kristy作為與會人員，若沒有提供時間，則紀錄為全天，主題和日期為必填";

        public override AParameters parameters => new ScheduleParameter();
    }
}
