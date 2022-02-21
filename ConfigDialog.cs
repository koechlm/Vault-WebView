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
using System.Windows.Forms;

using Autodesk.DataManagement.Client.Framework.Vault.Currency.Connections;

namespace VaultWebView
{
    public partial class ConfigDialog : Form
    {
        private Connection m_conn;
        private TabSettings m_selectedTabSettings = null;

        public ConfigDialog(Settings settings, Connection conn)
        {
            InitializeComponent();

            m_conn = conn;

            Init(settings);
        }

        private void Init(Settings settings)
        {
            foreach (TabSettings tabSettings in settings.Tabs)
            {
                TabSettings newSetting = new TabSettings();
                newSetting.Copy(tabSettings);
                m_tabsListBox.Items.Add(newSetting);
            }

        }

        public Settings GetSettings()
        {
            Settings settings = new Settings()
            {
                Tabs = new List<TabSettings>()
            };

            foreach (object o in m_tabsListBox.Items)
            {
                settings.Tabs.Add((TabSettings)o);
            }

            return settings;
        }

        private void ReadFromTabSettingControl()
        {
            if (m_selectedTabSettings != null)
            {
                TabSettings newSettings = m_tabSettingControl.GetSettings();
                m_selectedTabSettings.Copy(newSettings);

                if (m_selectedTabSettings == m_tabsListBox.SelectedItem)
                    return;

                m_tabsListBox.SuspendLayout();
                int index = m_tabsListBox.Items.IndexOf(m_selectedTabSettings);
                if (index >= 0)
                {
                    m_selectedTabSettings = m_tabsListBox.SelectedItem as TabSettings;
                    m_tabsListBox.RefreshItem(index);
                }
                m_tabsListBox.ResumeLayout();
            }
            else
                m_selectedTabSettings = m_tabsListBox.SelectedItem as TabSettings;

            m_tabSettingControl.SetValues(m_selectedTabSettings, m_conn);
        }

        private void m_okButton_Click(object sender, EventArgs e)
        {
            Util.DoAction(delegate
            {
                ReadFromTabSettingControl();

            });
            

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }


        private void m_cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void m_tabsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Util.DoAction(delegate
            {
                ReadFromTabSettingControl();
                
            });
        }

        private void m_addTabButton_Click(object sender, EventArgs e)
        {
            TabSettings newSettings = new TabSettings()
            {
                TabName = "Web View"
            };

            m_tabsListBox.Items.Add(newSettings);
        }

        private void m_deleteTabButton_Click(object sender, EventArgs e)
        {
            if (m_tabsListBox.SelectedItem == null)
                return;

            m_selectedTabSettings = null;
            m_tabsListBox.Items.Remove(m_tabsListBox.SelectedItem);
            
        }

    }

    public class RefreshingListBox : ListBox
    {
        private bool m_refreshing = false;

        public new void RefreshItem(int index)
        {
            base.RefreshItem(index);
        }

        public new void RefreshItems()
        {
            if (!m_refreshing)
            {
                m_refreshing = true;
                base.RefreshItems();
                m_refreshing = false;
            }
        }
    }
}
