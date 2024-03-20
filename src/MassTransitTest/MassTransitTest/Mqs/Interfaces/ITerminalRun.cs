using System;

namespace TN.Message
{
    /// <summary>
    /// 导航设备运行启停消息
    /// </summary>
    public class ITerminalRun
    {
        /// <summary>
        /// 终端编号
        /// </summary>
        public string TerminalNo { get; set; }

        /// <summary>
        /// 消息产生的时间,处理时如果超过1分钟，就无视
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// true 启动运行 false 停止运行
        /// </summary>
        public bool Run { get; set; }
    }
}
