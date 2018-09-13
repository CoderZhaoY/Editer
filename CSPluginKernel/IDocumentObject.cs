using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPluginKernel
{
    public interface IDocumentObject
    {
        //这些属性是RTB控件的相应属性的映射
        string DocSelectionText { get; set; }
        Color DocSelectionColor { get; set; }
        Font DocSelectionFont { get; set; }
        int DocSelectionStart { get; set; }
        int DocSelectionLength { get; set; }
        string DocSelectionRTF { get; set; }

        bool DocHasChanges { get; }

        void DocSelect(int start, int length);
        void DocAppendText(string str);
        void DocSaveFile(string fileName);
        void DocSaveFile();
        void DocOpenFile(string fileName);
        void DocCloseFile();
    }
}
