
using System.Collections.Generic;
using System.Windows.Forms;

namespace CSPluginKernel
{
    public interface IPlugin
    {
        ConnectionResult Connect(IApplicationObject app);
        /// <summary>
        /// 
        /// </summary>
        void OnDestory();
        /// <summary>
        /// 
        /// </summary>
        void OnLoad();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="OperateRtb"></param>
        void Run(RichTextBox OperateRtb);
        /// <summary>
        /// 格式化RichTextBox
        /// </summary>
        /// <param name="OperateRtb"></param>
        string FormatText(RichTextBox OperateRtb);
        /// <summary>
        /// 以指定格式格式化文本
        /// </summary>
        /// <param name="OperateRtb"></param>
        /// <param name="formate"></param>
        string FormatTextBySettings(RichTextBox OperateRtb, Dictionary<string, string> formate);
        
    }
    public enum ConnectionResult
    {
        Connection_Success,
        Connection_Failed
    }
}
