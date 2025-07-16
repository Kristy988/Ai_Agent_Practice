using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ai_Agent_練習
{
    internal class AIRequest
    {
        public List<Content> contents { get; set; }
        public List<Tool> tools { get; set; }

        public class Content
        {
            public string role { get; set; }
            public List<Part> parts { get; set; }
        }

        public class Part
        {
            public string text { get; set; }
        }

        public class Tool
        {
            public List<Functiondeclaration> functionDeclarations { get; set; }
        }

        public class Functiondeclaration
        {
            public string name { get; set; }
            public string description { get; set; }
            public Parameters parameters { get; set; }
        }

        public class Parameters
        {
            public string type { get; set; }
            public Properties properties { get; set; }
            public string[] required { get; set; }
        }

        public class Properties
        {
            public Brightness brightness { get; set; }
            public Color_Temp color_temp { get; set; }
            public Attendees attendees { get; set; }
            public Date_Schedule date_Schedule { get; set; }
            public Time_Schedule time_Schedule { get; set; }
            public Topic topic { get; set; }
        }

        public class Brightness
        {
            public string type { get; set; }
            public string description { get; set; }
        }

        public class Color_Temp
        {
            public string type { get; set; }
            public string[] @enum { get; set; }
            public string description { get; set; }
        }

        public class Attendees
        {
            public string type { get; set; }
            public ItemType items { get; set; } = new ItemType() { type = "string" };
            public string description { get; set; }
        }

        public class ItemType
        {
            public string type { get; set; }
        }

        public class Date_Schedule
        {
            public string type { get; set; }
            public string description { get; set; }
        }
        public class Time_Schedule
        {
            public string type { get; set; }
            public string description { get; set; }
        }
        public class Topic
        {
            public string type { get; set; }
            public string description { get; set; }
        }
    }
}
