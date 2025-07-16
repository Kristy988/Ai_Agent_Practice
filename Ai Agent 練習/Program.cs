using Ai_Agent_練習.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static Ai_Agent_練習.AIRequest;

namespace Ai_Agent_練習
{

    internal class Program
    {
        static async Task Main(string[] args)
        {

            AIRequest aIRequest = new AIRequest()
            {
                tools = new List<AIRequest.Tool>
                {
                    {
                        new AIRequest.Tool()
                        {
                            functionDeclarations = new List<Functiondeclaration>
                            {
                                new Functiondeclaration()
                                {
                                    name = "Tools.LightTool",
                                    description = "該函數主要用來設定燈光強度與色溫，使用者會告知你想要的情境模式，你需要針對使用者的意圖與行為模式，去推斷並主動傳入推薦的指定參數內容進行呼叫",
                                    parameters = new Parameters()
                                    {
                                        type = "object",
                                        properties = new Properties()
                                        {
                                            brightness = new Brightness()
                                            {
                                                type = "integer",
                                                description ="燈光強度0-100，0表示熄滅，100表示全亮"
                                            },
                                            color_temp = new Color_Temp()
                                            {
                                                type = "string",
                                                @enum =new string[]{"日光", "冷光", "暖光" },
                                                description = "燈光有三種固定的色溫：日光、冷光、暖光.類型。你會需要根據使用者給的意圖或是情境自行帶入或者決定。例如:電影模式採用冷光，浪漫模式採用暖光，依次列推。"
                                            }
                                        }
                                    }
                                },
                                new Functiondeclaration()
                                {
                                     name = "Tools.ScheduleTool",
                                     description = "該函數主要用來安排一個行程，使用者會告知你主題、時間、日期和與會人員，你需要針對使用者給的資訊，主動紀錄該行程，如果沒有與會人員的話，請直接填入Kristy作為與會人員，若沒有提供時間，則紀錄為全天，主題和日期為必填",
                                     parameters = new Parameters()
                                     {
                                         type = "object",
                                         properties = new Properties()
                                         {
                                             attendees = new Attendees()
                                             {
                                                 type = "array",
                                                 description ="列出所有參與的人員，其中必須包含我自己:Kristy"
                                             },
                                             date_Schedule = new Date_Schedule()
                                             {
                                                 type = "string",
                                                 description = "行程的日期，如2025-01-01"
                                             },
                                             time_Schedule = new Time_Schedule()
                                             {
                                                 type = "string",
                                                 description = "行程的時間，如23:59"
                                             },
                                             topic = new Topic()
                                             {
                                                 type = "string",
                                                 description = "該行程的目的或主題"
                                             }
                                         }
                                     }
                                }
                            }
                        }
                    }

                },
                contents = new List<Content>
                {
                    new Content()
                    {
                        role = "model",
                        parts = new List<Part>()
                        {
                            new Part()
                            {
                                text = "作為一個AI助理管家，你會需要根據你現有的工具協助使用者解決問題，請注意你只能回答有關你工具內容的問題並幫他們執行，以外的內容都不允許回答。"
                            }
                        }
                    }
                }

            };

            Console.WriteLine("我是AI助理，請問需要什麼幫助嗎?");
            while (true)
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent");
                request.Headers.Add("x-goog-api-key", ConfigurationManager.AppSettings["apiKey"]);


                //使用者輸入
                string userInput = Console.ReadLine();
                aIRequest.contents.Add(new Content() { role = "user", parts = new List<Part>() { new Part() { text = userInput } } });

                //model回答
                var content = new StringContent(JsonConvert.SerializeObject(aIRequest));
                request.Content = content;
                var response = await client.SendAsync(request);
                string responseText = await response.Content.ReadAsStringAsync();
                AIResponse res = JsonConvert.DeserializeObject<AIResponse>(responseText);

                if (res.candidates[0].content.parts[0].text != null)
                {
                    Console.WriteLine(res.candidates[0].content.parts[0].text);
                    aIRequest.contents.Add(new Content() { role = "model", parts = new List<Part>() { new Part() { text = res.candidates[0].content.parts[0].text } } });

                }
                else
                {
                    Type type = Type.GetType("Ai_Agent_練習." + res.candidates[0].content.parts[0].functionCall.name); //找到類別
                    ATools theTool = (ATools)Activator.CreateInstance(type);
                    theTool.Apply(res.candidates[0].content.parts[0].functionCall.args);
                    aIRequest.contents.Add(new Content() { role = "model", parts = new List<Part>() { new Part() { text = "好的，已經按照您的要求完成指示，請問接下來還有甚麼需要幫忙的嗎?" } } });

                }

            }





            Console.ReadKey();
        }
    }
}
