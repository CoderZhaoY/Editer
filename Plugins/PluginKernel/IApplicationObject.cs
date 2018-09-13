using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editer.PluginKernel
{
    /// <summary>
    /// 应用程序接口
    /// </summary>
    public interface IApplicationObject
    {

        /// <summary>
        /// 产生一条消息
        /// </summary>
        void Alert(string msg);
        /// <summary>
        /// 将指定的信息显示在状态栏
        /// </summary>
        void ShowInStatusBar(string msg);
        /// <summary>
        /// 获取当前使用的文档对象
        /// </summary>
        IDocumentObject QueryCurrentDocument();
        /// <summary>
        /// 获取当前所有的文档对象
        /// </summary>
        IDocumentObject[] QueryDocuments();
        /// <summary>
        /// 设置事件处理器
        /// </summary>
        void SetDelegate(Delegates whichOne, EventHandler targer);

    }
   /// <summary>
   /// 该接口支持的事件类型
   /// </summary>
    public enum Delegates
    {
        /// <summary>
        /// 当文本发生改变时，触发事件（未使用）
        /// </summary>
        Delegate_ActiveDocumentChanged,
    }
}
