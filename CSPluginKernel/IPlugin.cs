
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CSPluginKernel
{
    /// <summary>
    /// 插件接口，定义了文档插件的一般行为。
    /// </summary>
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
        void Work(IDocumentObject document);
        /// <summary>
        /// 响应事件
        /// </summary>
        /// <param name="document"></param>
        /// <param name=""></param>
        void Response(object sender, EventArgs args);
    } 
    public enum ConnectionResult
    {
        Connection_Success,
        Connection_Failed
    }
}
