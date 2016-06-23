/*=====================================================================
  
  This file is part of the Autodesk Vault API Code Samples.

  Copyright (C) Autodesk Inc.  All rights reserved.

THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
PARTICULAR PURPOSE.
=====================================================================*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace VaultWebView
{
    public partial class WebViewControl : UserControl
    {
        public void Navigate(string url)
        {
            if (url != null && url.Length > 0)
            {
                string currentUrl = String.Empty;
                if (m_webBrowser.Url != null)
                    currentUrl = m_webBrowser.Url.ToString();
                if (url != currentUrl)
                    ThreadPool.QueueUserWorkItem(NavigateWorker, url);
            }
            else
            {
                if (m_webBrowser.Url != null)
                    ThreadPool.QueueUserWorkItem(NavigateWorker, String.Empty);
            }


            //ThreadPool.QueueUserWorkItem(NavigateWorker, url);
        }

        private void NavigateWorker(object o)
        {
            try
            {
                string uri = (string)o;
                m_webBrowser.Navigate(uri);
            }
            catch
            {
                if (m_webBrowser.Url != null)
                    m_webBrowser.Navigate(String.Empty);
            }
        }

        public WebViewControl()
        {
            InitializeComponent();
        }
    }
}
