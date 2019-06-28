using System;
using System.ComponentModel;

namespace Niue.Application.BackgroundJobs.Args
{
    [Serializable]
    public class SendSmsArgs
    {
        [Description("手机号")]
        public string Mobile { get; set; }

        [Description("内容")]
        public string Content { get; set; }

        [Description("小号")]
        public string Xh { get; set; }

        //public SendSmsArgs()
        //{
        //    Xh = "";
        //}
    }
}
