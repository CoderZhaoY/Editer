using CSPluginKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;

namespace Editer
{
    [PluginInfo(
          "My Pluging 1( Just for test )",
          "1.0",
          "Codeeror",
          "https://blog.csdn.net/Codeeror", true)
    ]
    class KeyWordTip : IPlugin
    {
        public IApplicationObject app;
        public IDocumentObject[] documents;
        private string[] keywords;
        public ConnectionResult Connect(IApplicationObject app)
        {
            this.app = app;
            this.documents= app.QueryDocuments();
            return ConnectionResult.Connection_Success;
        }
        private char[] GetSplitChars()
        {
            //这里可以使用正则表达式快捷生成所有特殊字符的表
            return new char[] { ' ', '\t' };
        }
        public void OnDestory()
        {
           
        }      
        public void OnLoad()
        {
            if (CheckAppConfig())
            {
                string KeyWordsPath = ConfigurationManager.AppSettings["KeyWordsPath"].ToString();
                string[] files = Directory.GetFiles(KeyWordsPath);
                foreach (string file in files)
                {
                    using (StreamReader sr = new StreamReader(file))
                    {
                        try
                        {
                            keywords = sr.ReadToEnd().Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                            app.Alert("已加载插件:My Pluging 1( Just for test )");
                        }
                        catch (Exception)
                        {
                            
                            throw;
                        }
                    }
                }

            }
           
        }
        private bool CheckAppConfig()
        {
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key == "KeyWordsPath")
                {
                    if (ConfigurationManager.AppSettings["KeyWordsPath"] == "")
                    {
                        app.Alert("未能读取到关键词文本，该控件将不会工作");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void Work(IDocumentObject document)
        {
            if (app.QueryCurrentDocument().DocText.Length > 0)
            {
                ShowKeyWords();
            }
          

        }
        private void ShowKeyWords()
        {
            app.Alert(CreateTipText(app.QueryCurrentDocument()));          
        }
        private string CreateTipText(IDocumentObject OperateRtb)
        {
                StringBuilder keyString = new StringBuilder();
                char ch = OperateRtb.DocText.Last();
                List<string> showStres = new List<string>();
                for (int i = 0; i < keywords.Length; i++)
                {
                    if (keywords[i].First() == ch)
                    {
                        showStres.Add(keywords[i]);
                    }
                }
                foreach (string item in showStres)
                {
                    keyString.Append(item + "|");
                }

                return keyString.ToString();
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

        private void FormatText(IDocumentObject document)
        {
            int set = 0;
            //设置关键字颜色
            foreach (string word in keywords)
            {
                set = document.DocText.IndexOf(word, set);
                if (set != -1)
                {
                    document.DocSelect(set, word.Length);
                    document.DocSelectionColor = Color.Green;
                    
                }
                else
                {
                    set = 0;
                    continue;
                }
            }
            document.DocSelect(document.DocText.Length,1);
        }

        public void Response(object sender, EventArgs args)
        {
            FormatText(app.QueryCurrentDocument());
        }
    }
}
