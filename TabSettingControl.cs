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
using System.Linq;
using System.Windows.Forms;

using Autodesk.DataManagement.Client.Framework.Vault.Currency.Connections;
using Autodesk.DataManagement.Client.Framework.Vault.Currency.Entities;
using Autodesk.Connectivity.WebServices;

namespace VaultWebView
{
    public partial class TabSettingControl : UserControl
    {
        Connection m_conn;
        Guid m_guid = Guid.NewGuid();

        Dictionary<string, CustEntDef> m_custEntMap = null;

        // default constructor
        public TabSettingControl()
        {
            InitializeComponent();
        }

        public void SetValues(TabSettings settings, Connection conn)
        {
            if (settings == null)
            {
                m_guid = Guid.NewGuid();
                Clear();
            }
            else
            {
                m_conn = conn;
                m_guid = settings.Guid;

                if (m_custEntMap == null)
                {
                    CustEntDef[] defs = m_conn.WebServiceManager.CustomEntityService.GetAllCustomEntityDefinitions();
                    m_custEntMap = defs.ToDictionary(n => n.Name);
                }

                InitSettings(settings);
            }
        }

        public TabSettings GetSettings()
        {
            TabSettings settings = new TabSettings()
            {
                TabName = m_tabNameTextBox.Text,
                Url = m_urlTextBox.Text,
                Guid = m_guid
            };

            settings.EntityClasses = new List<String>();

            foreach (object o in m_entCheckedListBox.CheckedItems)
            {
                EntityClass entityClass = o as EntityClass;
                if (entityClass != null)
                {
                    settings.EntityClasses.Add(entityClass.ServerId);
                    continue;
                }

                CustEntDefItem custEnt = o as CustEntDefItem;
                if (custEnt != null)
                {
                    settings.EntityClasses.Add(custEnt.CustEntDef.Name);
                    continue;
                }
            }

            return settings;
        }

        private void Clear()
        {
            m_tabNameTextBox.Text = null;
            m_urlTextBox.Text = null;
            m_entCheckedListBox.Items.Clear();
        }

        private void InitSettings(TabSettings settings)
        {
            this.SuspendLayout();

            if (settings == null)
            {
                Clear();
                return;
            }

            m_tabNameTextBox.Text = settings.TabName;
            m_urlTextBox.Text = settings.Url;

            IEnumerable<EntityClass> entityClasses = 
                m_conn.ConfigurationManager.GetEntityClasses();

            m_entCheckedListBox.Items.Clear();
            foreach (EntityClass entityClass in entityClasses)
            {
                if (!entityClass.IsUserPresentable || entityClass.ServerId == EntityClassIds.CustomObject)
                    continue;

                if (entityClass.ServerId == EntityClassIds.ItemReferenceDesignators)
                    continue;

                int index = m_entCheckedListBox.Items.Add(entityClass);

                m_entCheckedListBox.SetItemChecked(index, IsChecked(entityClass, settings));
            }
            foreach (CustEntDef def in m_custEntMap.Values)
            {
                int index = m_entCheckedListBox.Items.Add(new CustEntDefItem(def));

                m_entCheckedListBox.SetItemChecked(index, settings.EntityClasses.Contains(def.Name));
            }

            this.ResumeLayout();
        }

        private bool IsChecked(EntityClass entityClass, TabSettings settings)
        {
            if (entityClass.ServerId == EntityClassIds.Files ||
                entityClass.ServerId == EntityClassIds.Folder ||
                entityClass.ServerId == EntityClassIds.Items ||
                entityClass.ServerId == EntityClassIds.ChangeOrders)
            {
                return settings.EntityClasses.Contains(entityClass.ServerId);
            }

            return false;
        }
    }

    public class CustEntDefItem
    {
        public CustEntDef CustEntDef;

        public CustEntDefItem(CustEntDef def)
        {
            this.CustEntDef = def;
        }

        public override string ToString()
        {
            return CustEntDef.DispName;
        }
    }

}
