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
    class Student
    {
        public String Name { get; set; }
        public int Number { get; set; }
    }


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
                                    name = "set_light_values",
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

            Console.WriteLine("我是AI燈光調整助理，請問需要什麼幫助嗎?");
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
                }
                else
                {
                    Console.WriteLine("色溫" + res.candidates[0].content.parts[0].functionCall.args.color_temp);
                    Console.WriteLine("亮度" + res.candidates[0].content.parts[0].functionCall.args.brightness);
                    break;
                }
            }





            Console.ReadKey();
        }
    }
}
