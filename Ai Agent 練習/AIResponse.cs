﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ai_Agent_練習
{
    internal class AIResponse
    {
        public Candidate[] candidates { get; set; }
        public Usagemetadata usageMetadata { get; set; }
        public string modelVersion { get; set; }
        public string responseId { get; set; }

        public class Usagemetadata
        {
            public int promptTokenCount { get; set; }
            public int candidatesTokenCount { get; set; }
            public int totalTokenCount { get; set; }
            public Prompttokensdetail[] promptTokensDetails { get; set; }
            public int thoughtsTokenCount { get; set; }
        }

        public class Prompttokensdetail
        {
            public string modality { get; set; }
            public int tokenCount { get; set; }
        }

        public class Candidate
        {
            public Content content { get; set; }
            public string finishReason { get; set; }
            public int index { get; set; }
        }

        public class Content
        {
            public Part[] parts { get; set; }
            public string role { get; set; }
        }

        public class Part
        {
            public string text { get; set; }
            public Functioncall functionCall { get; set; }
            public string thoughtSignature { get; set; }
        }

        public class Functioncall
        {
            public string name { get; set; }
            public Args args { get; set; }
        }

        public class Args
        {
            public string color_temp { get; set; }
            public int brightness { get; set; }
            public string[] attendees { get; set; }
            public string date_schedule { get; set; }
            public string time_schedule { get; set; }
            public string topic { get; set; }
            public string location { get; set; }
        }

    }
}
