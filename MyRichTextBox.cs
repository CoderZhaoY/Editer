using CSPluginKernel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editer
{
    class MyRichTextBox : RichTextBox, IDocumentObject
    {
        public event EventHandler Event;

        public string DocSelectionText { get => SelectedText; set { DocSelectionText = SelectedText; } }
        public Color DocSelectionColor { get => SelectionColor; set { DocSelectionColor = SelectionColor; } }
        public Font DocSelectionFont { get => SelectionFont; set { DocSelectionFont = SelectionFont; } }
        public int DocSelectionStart { get => SelectionStart; set { DocSelectionStart = SelectionStart; } }
        public int DocSelectionLength { get => SelectionLength; set { DocSelectionLength = SelectionLength; } }
        public string DocSelectionRTF { get => SelectedRtf; set { DocSelectionRTF = SelectedRtf; } }

        public bool DocHasChanges => Modified = this.DocHasChanges;


        public void DocAppendText(string str)
        {
            this.AppendText(str);
        }

        public void DocCloseFile()
        {
            throw new NotImplementedException();
        }

        public void DocOpenFile(string fileName)
        {
            throw new NotImplementedException();
        }

        public void DocSaveFile(string fileName)
        {
            throw new NotImplementedException();
        }

        public void DocSaveFile()
        {
            throw new NotImplementedException();
        }

        public void DocSelect(int start, int length)
        {
            throw new NotImplementedException();
        }
    }
}
