using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editer.PluginKernel
{
    /// <summary>
    /// 文档接口
    /// </summary>
    public interface IDocumentObject
    {
        //这些属性是RTB控件的相应属性的映射
        /// <summary>
        /// 同richtextbox
        /// </summary>
        string DocSelectionText { get; set; }
        /// <summary>
        /// 同richtextbox
        /// </summary>
        Color DocSelectionColor { get; set; }
        /// <summary>
        /// 同richtextbox
        /// </summary>
        Font DocSelectionFont { get; set; }
        /// <summary>
        /// 同richtextbox
        /// </summary>
        int DocSelectionStart { get; set; }
        /// <summary>
        /// 同richtextbox
        /// </summary>
        int DocSelectionLength { get; set; }
        /// <summary>
        /// 同richtextbox
        /// </summary>
        string DocSelectionRTF { get; set; }
        /// <summary>
        /// 指示文档是否发生改变
        /// </summary>
        bool DocHasChanges { get; }
        /// <summary>
        ///选择文档内容
        /// </summary>
        void DocSelect(int start, int length);
        /// <summary>
        /// 向文档中追加文本
        /// </summary>
        /// <param name="str"></param>
        void DocAppendText(string str);
        /// <summary>
        /// 保存文档
        /// </summary>
        /// <param name="fileName"></param>
        void DocSaveFile(string fileName);
        /// <summary>
        /// 保存文档
        /// </summary>
        void DocSaveFile();
        /// <summary>
        /// 打开文档
        /// </summary>
        /// <param name="fileName"></param>
        void DocOpenFile(string fileName);
        /// <summary>
        /// 关闭文档
        /// </summary>
        void DocCloseFile();
    }
}
