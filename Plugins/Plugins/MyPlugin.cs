using CSPluginKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editer
{
    [PluginInfo(
          "My Pluging 1( Just for test )",
          "1.0",
          "Codeeror",
          "https://blog.csdn.net/Codeeror", true)
    ]
    class MyPlugin : IPlugin
    {
        public IApplicationObject app;

        public ConnectionResult Connect(IApplicationObject app)
        {
            //初始化
            this.app = app;
            return ConnectionResult.Connection_Success;
        }

        public string FormatText(RichTextBox OperateRtb)
        {
            throw new NotImplementedException();
        }

        public string FormatTextBySettings(RichTextBox OperateRtb, Dictionary<string, string> formate)
        {
            throw new NotImplementedException();
        }

        public void OnDestory()
        {
            throw new NotImplementedException();
        }

        public void OnLoad()
        {
            //要求读取一个特殊文件，该文件规定了关键字，当输入该字符时智能提示。
            
        }

        /// <summary>
        /// 统计字符数
        /// </summary>
        /// <param name="OperateRtb"></param>
        public void Run(RichTextBox OperateRtb)
        {
            string text = OperateRtb.Text;
            CountWords(text);
            StringBuilder keyString = new StringBuilder();
            string[] keywords = new string[] { "test", "test1", "test2" };
            char ch = OperateRtb.Text.Last();
            List<string> showStres = new List<string>();
            for (int i = 0; i < keywords.Length; i++)
            {
                if (keywords[i].First()==ch)
                {
                    showStres.Add(keywords[i]);
                }
            }
            foreach (string item in showStres)
            {
                keyString.Append(item + "|");
            }
            app.Alert(keyString.ToString());
        }

        private Dictionary<char, int> CountWords(string text)
        {
            Dictionary<char, int> wordsCount = new Dictionary<char, int>();
            for (int i = 0; i < text.Length; i++)
            {
                if (wordsCount.ContainsKey(text[i]))
                {
                    wordsCount[text[i]]++;
                }
                else
                {
                    wordsCount.Add(text[i], 1);
                }
            }
            foreach (KeyValuePair<char, int> item in wordsCount)
            {
               
            }
            return wordsCount;
        }
    }
}
