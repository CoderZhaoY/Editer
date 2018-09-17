using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSPluginKernel;

namespace PluginsForCSPluginKernel
{
    [PluginInfo(
         "XMLReaderPlugin",
         "1.0",
         "Codeeror",
         "https://blog.csdn.net/Codeeror", true)
   ]
    public class XMLReader : IPlugin
    {
        public ConnectionResult Connect(IApplicationObject app)
        {
            throw new NotImplementedException();
        }

        public void OnDestory()
        {
            throw new NotImplementedException();
        }

        public void OnLoad()
        {
            throw new NotImplementedException();
        }

        public void Response(object sender, EventArgs args)
        {
            throw new NotImplementedException();
        }

        public void Work(IDocumentObject document)
        {
            throw new NotImplementedException();
        }
    }
}