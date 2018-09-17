using CSPluginKernel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditerLibrary
{
    public class MyRichTextBox : RichTextBox, IDocumentObject
    {
        public MyRichTextBox() : base()
        {
            this.ImeMode = ImeMode.Off;
        }
        public string DocSelectionText
        {
            get
            {
                if (this.DocText.Length > 0)
                {
                    return this.SelectedText;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                SelectedText = value;
            }
        }
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
        public Font DocSelectionFont
        {
            get
            {
                return SelectionFont;
            }
            set
            {
                SelectionFont = value;
            }

        }
        public int DocSelectionStart
        {
            get
            {
                return SelectionStart;
            }
            set
            {
                if (value<0)
                {
                    SelectionStart = 0;
                }
                SelectionStart = value;
            }
        }
        public int DocSelectionLength
        {
            get
            {
                return SelectionLength;
            }
            set
            {
                SelectionLength = value;
            }
        }
        public string DocSelectionRTF
        {
            get
            {
                return SelectedRtf;
            }
            set
            {
                SelectedRtf = value;
            }
        }
        public bool DocHasChanges
        {
            get
            {
                return Modified;
            }
            set
            {
                Modified = value;
            }
        }
        public string DocText
        {
            get
            {
                return this.Text;
            }
            set
            {
                this.Text = value;
            }
        }


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
            if (start >= 0)
            {
                this.Select(start, length);
            }

        }
    }
}
