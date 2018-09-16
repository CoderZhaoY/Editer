using CSPluginKernel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editer
{
    /// <summary>
    /// 插件加载的帮助类
    /// </summary>
    public static class PluginLoader
    {
        /// <summary>
        /// 插件列表
        /// </summary>
        public static List<IPlugin> plugins = new List<IPlugin>();
        /// <summary>
        /// 从指定位置搜索插件
        /// </summary>
        /// <param name="plugPath"></param>
        public static void GetPlug(string plugPath)
        {
            Assembly asm;
            try
            {
                asm = Assembly.LoadFrom(plugPath);
            }
            catch (Exception ex)
            {
                throw ;
            }
            Type[] types;
            try
            {
                types = asm.GetTypes();
            }
            catch (Exception ex)
            {

                throw ;
            }

            foreach (Type t in types)
            {
                if (IsValidPlugin(t))
                {
                    try
                    {
                        plugins.Add((IPlugin)asm.CreateInstance(t.FullName));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("加载插件失败：错误的类型;" + ex.Message);
                        throw;
                    }

                }
            }
        }
        private static bool IsValidPlugin(Type t)
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
        /// <summary>
        /// 将插件嵌入到应用中。为插件生成操作按钮
        /// </summary>
        /// <param name="app"></param>
        /// <param name="插件ToolStripMenuItem">插件依托的操作按钮</param>
        public static void LoadPlugins(IApplicationObject app,ToolStripMenuItem 插件ToolStripMenuItem)
        {
            List<ToolStripMenuItem> pluginItemList = new List<ToolStripMenuItem>();
            foreach (IPlugin item in PluginLoader.plugins)
            {
                PluginInfoAttribute pluginInfo = (PluginInfoAttribute)Attribute.GetCustomAttribute(item.GetType(), typeof(PluginInfoAttribute));
                if (item.Connect(app) != ConnectionResult.Connection_Success)
                {
                    app.Alert("未成功加载插件" + pluginInfo.Name + "" + pluginInfo.Version);
                }
                else
                {
                    //为插件添加入口按钮：
                    ToolStripMenuItem pluginItem = new ToolStripMenuItem(pluginInfo.Name);
                    pluginItemList.Add(pluginItem);
                    pluginItem.Click += item.Response;
                    item.OnLoad();
                }
            }
           插件ToolStripMenuItem.DropDownItems.AddRange(pluginItemList.ToArray());

        }
    }
}
