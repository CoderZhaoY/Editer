
using CSPluginKernel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editer
{
    public partial class MainForm : Form,IApplicationObject
    {
        private string textFileName = "未命名";
        private string programeName = "Editer";
        private string filePath = "";
        private string asFilePath = "";
        private string selecteText = "";
        private string helpUrl = "www.baidu.com";
        private string wrongMessage = "你好像遇到了错误...";
        private string fileFormat = "文本文件(*.txt)|*.txt|Icey文件(*.ice)|*.ice|C++文件(*.cpp)|*.cpp|C文件(*.c)|*.c|所有文件(*.*)|(*.*)";
        private int currentIndex = 0;
        public static List<IPlugin> plugins = new List<IPlugin>();
        public static ArrayList piPer = new ArrayList();
        List<MyRichTextBox> myRiches = new List<MyRichTextBox>();
        private string plugPath = @"E:\Code\CSharp\WinForm\DEMO\Editer\Plugins\Plugins.dll";

        public MainForm()
        {
            InitializeComponent();
            MyRichTextBox editBox1 = new MyRichTextBox();
            editBox1.TextChanged += EditBox1_TextChanged;
            editBox1.Tag = textFileName + "-" +0;
            editBox1.Size = tabPage1.Size;
            editBox1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            editBox1.Name = "edit" + (myRiches.Count - 1).ToString();
            editBox1.TextChanged += editBox1_TextChanged;
            myRiches.Add(editBox1);
            tabPage1.Text = editBox1.Tag.ToString();
            tabPage1.Controls.Add(editBox1);


        }

        private void EditBox1_TextChanged(object sender, EventArgs e)
        {
            if (plugins.Count > 0)
            {
                plugins[0].Run(myRiches[currentIndex]);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = textFileName + " - " + programeName;//显示文件名
            this.timer1.Start();
            GetPlug(plugPath);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
                
        }
        #region  菜单
        private void 日期ToolStripMenuItem_Click(object sender, EventArgs e)
        {
                myRiches[currentIndex].AppendText(System.DateTime.Now.ToString());   
        }
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile();
        }
        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newFile();
        }
        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAsFile();
        }
        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile();
        }
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < myRiches.Count; i++)
            {
                if (myRiches[i].Text!= String.Empty ||myRiches[i].Modified==true)
                {
                    tabControl1.TabPages[i].Show();
                    myRiches[i].Focus();
                    DialogResult result = MessageBox.Show("是否将窗口1已编辑文件保存到 " + textFileName, wrongMessage, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        saveFile();
                   
                    }
                }
            }
                Application.Exit();
        }

        private void 状态栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (状态栏ToolStripMenuItem.Checked == true)
            {
                状态栏ToolStripMenuItem.Checked = false;
                statusStrip1.Visible = false;
            }
            else
            {
                状态栏ToolStripMenuItem.Checked = true;
                statusStrip1.Visible = true;
            }
        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((myRiches[currentIndex].SelectedText.Equals("")))
            {
                剪切ToolStripMenuItem.Enabled = false;
                复制ToolStripMenuItem.Enabled = false;
                删除ToolStripMenuItem.Enabled = false;
            }
            else
            {
                剪切ToolStripMenuItem.Enabled = true;
                复制ToolStripMenuItem.Enabled = true;
                删除ToolStripMenuItem.Enabled = true;
            }
        }

        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myRiches[currentIndex].SelectAll();
        }

        private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selecteText = myRiches[currentIndex].SelectedText;
            myRiches[currentIndex].Cut();
            
        }

        private void 撤销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myRiches[currentIndex].Undo();
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myRiches[currentIndex].Copy();
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myRiches[currentIndex].Paste();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myRiches[currentIndex].SelectedText = "";
        }

        private void 查看帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(helpUrl);
        }

        private void 关于ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.StartPosition = FormStartPosition.CenterScreen;
            about.Show();
            about.Owner = this;
        }

        private void 自动换行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            if (自动换行ToolStripMenuItem.Checked == true)
            {
                myRiches[currentIndex].WordWrap = false;
                自动换行ToolStripMenuItem.Checked = false;
            }
            else
            {
                myRiches[currentIndex].WordWrap = true;
                自动换行ToolStripMenuItem.Checked = true;
            }
        }

        private void 插件ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void 字体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                myRiches[currentIndex].Font = fontDialog.Font;
            }
        }
        private void 全屏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fullScreen();
        }
        #endregion
        #region 事件
        private void editBox1_TextChanged(object sender, EventArgs e)
        {
            infoLb.Text = "已修改";
            myRiches[currentIndex].Modified = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = 0; i < myRiches.Count; i++)
            {
                if (myRiches[i].Modified)
                {
                    tabControl1.TabPages[i].Show();
                    myRiches[i].Focus();
                    DialogResult result = MessageBox.Show("是否将窗体1已编辑文件保存到 " + textFileName, wrongMessage, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        saveFile();
                        e.Cancel = false;
                    }
                    else if (result == DialogResult.No)
                    {
                        e.Cancel = false;
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                }
            }
                Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            statusStrip1.Text = myRiches[currentIndex].Text.Length.ToString();
            int totalline =  myRiches[currentIndex].GetLineFromCharIndex(myRiches[currentIndex].Text.Length) + 1 ;//得到总行数
            int index = myRiches[currentIndex].GetFirstCharIndexOfCurrentLine();//得到当前行第一个字符的索引
            int line = myRiches[currentIndex].GetLineFromCharIndex(index) + 1;//得到当前行的行号
            int col = myRiches[currentIndex].SelectionStart - index + 1;//.SelectionStart得到光标所在位置的索引 - 当前行第一个字符的索引 = 光标所在的列数
            infoLb.Text = "第" + line + "行，第" + col + "列";
            if (myRiches[currentIndex].SelectedText.Equals(""))
            {
                cutButton.Enabled = false;
                copyButton.Enabled = false;
                deleteButton.Enabled = false;
            }
            else
            {
                cutButton.Enabled = true;
                copyButton.Enabled = true;
                deleteButton.Enabled = true;
            }
            if (myRiches[currentIndex].Tag!=null)
            {
                this.Text = myRiches[currentIndex].Tag.ToString()+"-"+programeName;
            }
            else
            {
                this.Text = "无标题-" + currentIndex.ToString();
            }
        }

        private void cutButton_Click(object sender, EventArgs e)
        {
            selecteText = myRiches[currentIndex].SelectedText;
            myRiches[currentIndex].Cut();
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            myRiches[currentIndex].Copy();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            myRiches[currentIndex].SelectedText = "";
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            newFile();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void saveAsButton_Click(object sender, EventArgs e)
        {
            saveAsFile();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab.Show();
            myRiches[tabControl1.SelectedIndex].Focus();
            currentIndex = tabControl1.SelectedIndex;
        }

        #endregion
        #region  工具函数
        private void saveAsFile()
        {
            SaveFileDialog saveAsFile = new SaveFileDialog();
            saveAsFile.Filter = fileFormat;
            saveAsFile.FileName = "*.txt";
            if (saveAsFile.ShowDialog() == DialogResult.OK)
            {
                asFilePath = saveAsFile.FileName;
                StreamWriter sw = new StreamWriter(asFilePath, false, Encoding.Default);
                sw.WriteLine(myRiches[currentIndex].Text);
                sw.Close();
                FileInfo fileInfo = new FileInfo(saveAsFile.FileName);
                myRiches[currentIndex].Tag = fileInfo.Name;
            }
            msgLb.Text = "已保存";
        }
        private void newFile()
        {
            AddNewDocumentObj();
            currentIndex = tabControl1.TabPages.Count - 1;
            tabControl1.TabPages[tabControl1.TabPages.Count - 1].Focus();


        }
        private void saveFile()
        {
            if (!textFileName.Equals(""))
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = fileFormat;
                saveFile.FileName = "*.txt";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    filePath = saveFile.FileName;
                    StreamWriter sw = new StreamWriter(filePath, false, Encoding.Default);
                    sw.Write(myRiches[currentIndex].Text);
                    sw.Close();
                    myRiches[currentIndex].Tag = saveFile.FileName;
                    myRiches[currentIndex].Modified = false;
                    myRiches[currentIndex].Parent.Text = Path.GetFileNameWithoutExtension(saveFile.FileName);
                }
            }
            msgLb.Text = "已保存";
        }
        private void openFile()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = fileFormat;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFile.FileName, Encoding.Default);
                AddNewDocumentObj();
                myRiches[currentIndex].Text = sr.ReadToEnd();
                myRiches[currentIndex].Parent.Text = Path.GetFileName(openFile.FileName);
                sr.Close();
                FileInfo fileInfo = new FileInfo(openFile.FileName);
                myRiches[currentIndex].Tag = fileInfo.Name + " - " + programeName;
                myRiches[currentIndex].Modified = false;
                textFileName = fileInfo.Name;
            }
        }
        private void fullScreen()
        {
            if (全屏ToolStripMenuItem.Checked == false)
            {
                this.WindowState = FormWindowState.Maximized;
                全屏ToolStripMenuItem.Checked = true;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            }
            else
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
                全屏ToolStripMenuItem.Checked = false;
            }
        }

        private void AddNewDocumentObj()
        {
            MyRichTextBox editBox1 = new MyRichTextBox();
            editBox1.Tag = textFileName + "-" + tabControl1.TabPages.Count;
            editBox1.Size = tabPage1.Size;
            editBox1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            editBox1.Name = "edit" + (myRiches.Count).ToString();
            editBox1.TextChanged += editBox1_TextChanged;
            myRiches.Add(editBox1);

            TabPage tabPage = new TabPage(editBox1.Tag.ToString());
            tabPage.Size = tabControl1.TabPages[0].Size;
            tabControl1.TabPages.Add(tabPage);
            tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(editBox1);
        }
        #endregion



        private void GetPlug(string plugPath)
        {
            Assembly asm = Assembly.LoadFrom(plugPath);
            Type[] types;
            try
            {
                types = asm.GetTypes();
            }
            catch (Exception ex )
            {
                MessageBox.Show("无法加载的程序集"+ex.Message);
                throw;
            }

            foreach (Type t in types)
            {
                if (IsValidPlugin(t))
                {
                    try
                    {
                        plugins.Add((IPlugin)asm.CreateInstance(t.FullName));
                    }
                    catch (Exception ex )
                    {
                        MessageBox.Show("加载插件失败：错误的类型;"+ex.Message);
                        throw;
                    }
                    
                }
            }
            plugins[0].Connect(this);
        }

        private bool IsValidPlugin(Type t)
        {
            bool ret = false;
            Type[] interfaces = t.GetInterfaces();
            foreach (Type theInterface in interfaces)
            {
                if (theInterface.FullName == "CSPluginKernel.IPlugin")
                {
                    ret = true;
                    break;
                }

            }
            return ret;
        }

        public void Alert(string msg)
        {
            msgLb.Text = msg;
            
        }

        public void ShowInStatusBar(string msg)
        {
            msgLb.Text = msg;
        }

        public IDocumentObject QueryCurrentDocument()
        {
            return myRiches[currentIndex];
        }

        public IDocumentObject[] QueryDocuments()
        {
            IDocumentObject[] documents = new IDocumentObject[myRiches.Count];
            for (int i = 0; i < myRiches.Count; i++)
            {
                documents[0] = myRiches[i];
            }
            return documents;
        }

        public void SetDelegate(Delegates whichOne, EventHandler targer)
        {
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentIndex = tabControl1.SelectedIndex;
        }
    }
}
