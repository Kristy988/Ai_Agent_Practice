using Ai_Agent_練習.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ai_Agent_練習
{
    internal class AIResult
    {
        AIResponse res { get; set; }
        public bool CanExcuteTool = true;
        public string ResponseText;
        public AIResult(AIResponse res)
        {
            this.res = res;
            if (res.candidates[0].content.parts[0].text != null)
            {
                CanExcuteTool = false;
                ResponseText = res.candidates[0].content.parts[0].text;

            }

        }

        public void RunTool()
        {
            if (CanExcuteTool)
            {
                Type type = Type.GetType("Ai_Agent_練習." + res.candidates[0].content.parts[0].functionCall.name); //反射找到類別
                ATools theTool = (ATools)Activator.CreateInstance(type);
                theTool.Apply(res.candidates[0].content.parts[0].functionCall.args);
            }
        }
    }
}
