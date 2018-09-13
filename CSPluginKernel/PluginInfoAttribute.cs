using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPluginKernel
{
    public class PluginInfoAttribute : System.Attribute
    {
        /// <summary>
        /// 初始化插件版本信息
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="version">版本</param>
        /// <param name="authro">作者</param>
        /// <param name="webpage">网址</param>
        /// <param name="loadWhenStart">是否在启动时加载</param>
        public PluginInfoAttribute(string name, string version, string authro, string webpage, bool loadWhenStart)
        {
            Name = name;
            Version = version;
            Author = authro;
            WebPage = webpage;
            LoadWhenStart = loadWhenStart;
        }

        public string Name { get; } = "";

        public string Version { get; } = "";

        public string Author { get; } = "";

        public string WebPage { get; } = "";
        public bool LoadWhenStart { get; } = true;

        /// <summary>
        /// 存储有用的信息
        /// </summary>
        public object Tag { get; set; } = null;

        /// <summary>
        /// 存储序号
        /// </summary>
        public int Index { get; set; } = 0;
    }
}
