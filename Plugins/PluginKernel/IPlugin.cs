using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editer.PluginKernel
{
    /// <summary>
    /// 插件接口，所有插件必须继承此接口，并实现其方法
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// 连接到应用程序
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        ConnectionResult Connect(IApplicationObject app);
        /// <summary>
        /// 销毁插件
        /// </summary>
        void OnDestory();
        /// <summary>
        /// 加载插件
        /// </summary>
        void OnLoad();
        /// <summary>
        /// 表示插件发生作用
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
    /// <summary>
    /// 表示与应用程序的连接结果
    /// </summary>
    public enum ConnectionResult
    {
        /// <summary>
        /// 连接成功
        /// </summary>
        Connection_Success,
        /// <summary>
        /// 连接失败
        /// </summary>
        Connection_Failed
    }
}
