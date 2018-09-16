using CSPluginKernel;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Editer
{
    class MyRichTextBox : RichTextBox, IDocumentObject
    {
        
        public string DocSelectionText { get => DocSelectionText = SelectedText; set { SelectedText = DocSelectionText; } }
        public Color DocSelectionColor
        {
            get
            {
                return SelectionColor;
            }
            set
            {
                SelectionColor = value;
            }
        }
        public Font DocSelectionFont { get => SelectionFont; set { SelectionFont = DocSelectionFont; } }
        public int DocSelectionStart { get => SelectionStart; set { SelectionStart = DocSelectionStart; } }
        public int DocSelectionLength { get => SelectionLength; set { SelectionLength = DocSelectionLength; } }
        public string DocSelectionRTF { get => SelectedRtf; set { SelectedRtf = DocSelectionRTF; } }
        
        public bool DocHasChanges => Modified = this.DocHasChanges;

        public string DocText { get => this.Text; set { this.Text = this.DocText; } }

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
            if (start>=0)
            {
                this.Select(start, length);
            }
            
        }
    }
}
