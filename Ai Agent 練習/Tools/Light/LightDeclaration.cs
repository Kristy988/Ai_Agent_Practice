using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ai_Agent_練習.AIRequest;

namespace Ai_Agent_練習.Tools.Light
{
    internal class LightDeclaration : AFunctiondeclaration
    {
        public override string name => "Tools.Light.LightTool";
        public override string description => "該函數主要用來設定燈光強度與色溫，使用者會告知你想要的情境模式，你需要針對使用者的意圖與行為模式，去推斷並主動傳入推薦的指定參數內容進行呼叫";
        public override AParameters parameters => new LightParameter();
    }
}
