namespace ReadExcelApp
{
    class GetBasicConversation
    {
        public string BasicConversation { get; set; }
        public int BasicConversationCount { get; set; }
        /*public string OutCalls { get; set; }
        public string InSMS { get; set; }
        public string OutSMS { get; set; }

        public int InTotal { get; set; }
        public int OutTotal { get; set; }

        public int InSmsTotal { get; set; }

        public int OutSmsTotal { get; set; }*/

        public GetBasicConversation(string BasicConversation, int BasicConversationCount)
        {
            this.BasicConversation = BasicConversation;
            this.BasicConversationCount = BasicConversationCount;
        }
    }
}
