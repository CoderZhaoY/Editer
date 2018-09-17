using CSPluginKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plugins
{
    public abstract class CSPlugin : IPlugin
    {
        /// <summary>
        /// 插件加载到的应用程序对象
        /// </summary>
        public IApplicationObject app;


        /// <summary>
        /// 文档对象
        /// </summary>
        public IDocumentObject[] documents;
        /// <summary>
        /// 连接到主程序
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public virtual ConnectionResult Connect(IApplicationObject app)
        {
            this.app = app;
            this.documents = app.QueryDocuments();
            return ConnectionResult.Connection_Success;
        }
        /// <summary>
        /// 插件退出时
        /// </summary>
        public abstract void OnDestory();
        /// <summary>
        /// 插件加载时
        /// </summary>
        public abstract void OnLoad();
        /// <summary>
        /// 插件响应用户界面的交互操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public abstract void Response(object sender, EventArgs args);
        /// <summary>
        /// 插件运行
        /// </summary>
        /// <param name="document"></param>
        public abstract void Work(IDocumentObject document);
    }
}