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
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Autodesk.Connectivity.Extensibility.Framework;
using Autodesk.Connectivity.Explorer.Extensibility;
using Autodesk.Connectivity.WebServices;

using Autodesk.DataManagement.Client.Framework.Vault.Currency.Connections;
using Autodesk.DataManagement.Client.Framework.Vault.Currency.Entities;
using Autodesk.DataManagement.Client.Framework.Vault.Currency.Properties;


[assembly: ApiVersion("15.0")]
[assembly: ExtensionId("7dc70157-5782-47b4-a204-572ac5855e5d")]

namespace VaultWebView
{

    public class WebView : IExplorerExtension
    {
        private string SETTINGS_FILE = "Settings.xml";
        private string SETTINGS_VAULT_OPTION = "Autodesk.WebView.Settings";
        private Dictionary<string, TabSettings> m_settingsPerTab;

        private Settings m_settings;

        public WebView()
        {
            GetSettings();
        }

        private List<SelectionTypeId> m_allowedSelectionTypes = new List<SelectionTypeId>()
        {
            SelectionTypeId.ChangeOrder,
            SelectionTypeId.File,
            SelectionTypeId.Folder,
            SelectionTypeId.Item
        };

        private Dictionary<SelectionTypeId, string> m_entityClassMap = new Dictionary<SelectionTypeId,string>()
        {
            { SelectionTypeId.ChangeOrder, "CO"},
            { SelectionTypeId.File, "FILE" },
            { SelectionTypeId.Folder, "FLDR" },
            { SelectionTypeId.Item, "ITEM"}
        };

        #region IExtension Members

        public IEnumerable<CommandSite> CommandSites()
        {
            CommandSite site = new CommandSite("Autodesk.WebView.Site", "Web View")
            {
                DeployAsPulldownMenu = false,
                Location = CommandSiteLocation.ToolsMenu,
            };

            CommandItem configureCommand = new CommandItem("Autodesk.WebView.Configure", "Configure Web View...")
            {
                Description = "Set the URL property for Web View",
                Hint = "Set the URL property for Web View",
                Image = Icons.OnesAndZeros,
                MultiSelectEnabled = true,
                NavigationTypes = null,
                ToolbarPaintStyle = PaintStyle.TextAndGlyph
            };
            configureCommand.Execute += new EventHandler<CommandItemEventArgs>(configureCommand_Execute);

            site.AddCommand(configureCommand);
            return new CommandSite[] { site };
        }

        void configureCommand_Execute(object sender, CommandItemEventArgs e)
        {
            try
            {
                ConfigureCommand(e.Context.Application.Connection);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        /// <summary>
        /// Get the settins from the local file.  This function may be called before the user logs in
        /// so it can't read the Vault option.
        /// </summary>
        private void GetSettings()
        {
            try
            {
                string settingsPath = System.IO.Path.Combine(Util.GetAssemblyPath(), SETTINGS_FILE);
                string xmlValue2 = System.IO.File.ReadAllText(settingsPath);

                m_settings = Settings.Load(xmlValue2);
            }
            catch
            {
                m_settings = new Settings();
            }
        }

        private void CheckSettings(Connection conn)
        {
            string xmlValue = conn.WebServiceManager.KnowledgeVaultService.GetVaultOption(SETTINGS_VAULT_OPTION);
            if (xmlValue == null)
                return;

            // normalize the data
            Settings tmp = Settings.Load(xmlValue);
            xmlValue = tmp.Save();

            string settingsPath = System.IO.Path.Combine(Util.GetAssemblyPath(), SETTINGS_FILE);
            string xmlValue2 = null;

            if (System.IO.File.Exists(settingsPath))
            {
                xmlValue2 = System.IO.File.ReadAllText(settingsPath);
            }

            if (xmlValue != xmlValue2)
            {
                MessageBox.Show("The web view settings have been updated.  You may need to restart Vault explorer to see the correct web view tabs.");
                System.IO.File.WriteAllText(settingsPath, xmlValue);
            }

        }

        private void ConfigureCommand(Connection conn)
        {
            if (!Util.IsAdmin(conn))
                throw new Exception("Only administrators can run this command");

            ConfigDialog dialog = new ConfigDialog(m_settings, conn);

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Settings settings = dialog.GetSettings();
                string xml = settings.Save();

                string settingsPath = System.IO.Path.Combine(Util.GetAssemblyPath(), SETTINGS_FILE);
                System.IO.File.WriteAllText(settingsPath, xml);
                conn.WebServiceManager.KnowledgeVaultService.SetVaultOption(SETTINGS_VAULT_OPTION, xml);
                m_settings = settings;

                // try to update settings associated with each tab control
                foreach (TabSettings tabSet in m_settingsPerTab.Values)
                {
                    TabSettings newSet = m_settings.Tabs.FirstOrDefault(n => n.Guid == tabSet.Guid);

                    if (newSet != null)
                        tabSet.Copy(newSet);
                }

                MessageBox.Show("Settings updated.  If you added or removed a tab, " +
                    "you will need to restart Vault Explorer for the settings to be applied.");
            }
        }

        public IEnumerable<CustomEntityHandler> CustomEntityHandlers()
        {
            return null;
        }

        public IEnumerable<DetailPaneTab> DetailTabs()
        {
            List<DetailPaneTab> tabs = new List<DetailPaneTab>();
            m_settingsPerTab = new Dictionary<string, TabSettings>();

            int i = 0;
            foreach (TabSettings tabSettings in m_settings.Tabs)
            {
                i++;
                foreach (string entityClass in tabSettings.EntityClasses)
                {
                    DetailPaneTab webViewTab = null;
                    if (entityClass == EntityClassIds.Files)
                        webViewTab = new DetailPaneTab("Autodesk.WebView.Tab." + i.ToString() + ".File", tabSettings.TabName, SelectionTypeId.File, typeof(WebViewControl));
                    else if (entityClass == EntityClassIds.Folder)
                        webViewTab = new DetailPaneTab("Autodesk.WebView.Tab." + i.ToString() + ".Folder", tabSettings.TabName, SelectionTypeId.Folder, typeof(WebViewControl));
                    else if (entityClass == EntityClassIds.Items)
                        webViewTab = new DetailPaneTab("Autodesk.WebView.Tab." + i.ToString() + ".Items", tabSettings.TabName, SelectionTypeId.Item, typeof(WebViewControl));
                    else if (entityClass == EntityClassIds.ChangeOrders)
                        webViewTab = new DetailPaneTab("Autodesk.WebView.Tab." + i.ToString() + ".ChangeOrders", tabSettings.TabName, SelectionTypeId.ChangeOrder, typeof(WebViewControl));
                    else
                    {
                        // assume custom entity tab
                        SelectionTypeId customType = new SelectionTypeId(entityClass);
                        webViewTab = new DetailPaneTab("Autodesk.WebView.Tab." + i.ToString() + ".CustEnt." + customType, tabSettings.TabName, customType, typeof(WebViewControl));
                    }
                    webViewTab.SelectionChanged += new EventHandler<SelectionChangedEventArgs>(webViewTab_SelectionChanged);
                    
                    tabs.Add(webViewTab);
                    m_settingsPerTab.Add(webViewTab.Id, tabSettings);
                }
            }

            return tabs;

        }

        public IEnumerable<string> HiddenCommands()
        {
            return null;
        }

        public void OnLogOff(IApplication application)
        {

        }

        public void OnLogOn(IApplication application)
        {
            Util.DoAction(delegate
            {
                CheckSettings(application.Connection);
            });
        }

        public void OnShutdown(IApplication application)
        {
        }

        public void OnStartup(IApplication application)
        {
            
        }

        #endregion

        void webViewTab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DetailPaneTab tab = sender as DetailPaneTab;
                if (sender == null)
                    return;

                InvokeControl(e, m_settingsPerTab[tab.Id]);
            }
            catch
            {   
            }
        }


        void InvokeControl(SelectionChangedEventArgs e, TabSettings tabSettings)
        {

            if (e.Context.SelectedObject == null)
                return;

            ISelection selectedObject = e.Context.SelectedObject;
            Connection conn = e.Context.Application.Connection;
            WebViewControl control = (WebViewControl)e.Context.UserControl;

            string url = tabSettings.Url;

            // grab all text inside a {}
            Regex propRegex = new Regex("\\{.+?\\}");

            // Replace text
            Dictionary<string, string> replaceMap = new Dictionary<string,string>();
            foreach (Match match in propRegex.Matches(url))
            {
                replaceMap.Add(match.Value.ToLower(), null);
            }

            if (replaceMap.Count > 0)
            {
                long entityId = selectedObject.Id;

                if (selectedObject.TypeId == SelectionTypeId.File)
                {
                    File file = conn.WebServiceManager.DocumentService.GetLatestFileByMasterId(entityId);
                    entityId = file.Id;
                }

                url = SubstituteEntityProps(url, conn, entityId, selectedObject.TypeId.EntityClassId, replaceMap);

                
            }
            ISelection nav = e.Context.NavSelectionSet.FirstOrDefault();
            if (nav != null && nav.TypeId == SelectionTypeId.Folder && nav.Id > 0)
            {
                if (replaceMap.Count > 0)
                {
                    // take folder properties into account
                    url = SubstituteEntityProps(url, conn, nav.Id, nav.TypeId.EntityClassId, replaceMap);
                }
                Regex folderRegex = new Regex("#FOLDERID#", RegexOptions.IgnoreCase);
                folderRegex.Replace(url, nav.Id.ToString());
            }

            // a few hard-coded substs
            Regex regex = new Regex("#SERVER#", RegexOptions.IgnoreCase);
            regex.Replace(url, conn.Server);

            // easter egg
            Regex easter = new Regex("^[10]*$");
            if (easter.IsMatch(url))
                url = "http://justonesandzeros.typepad.com";

            if (propRegex.IsMatch(url))
                control.Navigate(String.Empty);  // we don't show anything if there are unresolved {}
            else
                control.Navigate(url);

        }

        private string SubstituteEntityProps(string url, Connection conn, long entityId, string entityClassId, Dictionary<string, string> replaceMap)
        {
            PropInst[] props = conn.WebServiceManager.PropertyService.GetPropertiesByEntityIds(
                    entityClassId, entityId.ToSingleArray());

            PropertyDefinitionDictionary propDict = conn.PropertyManager.GetPropertyDefinitions(null, null, PropertyDefinitionFilter.IncludeAll);

            foreach (PropInst prop in props)
            {
                if (prop.Val == null || String.IsNullOrEmpty(prop.Val.ToString()))
                    continue;

                if (prop.ValTyp != DataType.Numeric && prop.ValTyp != DataType.String)
                    continue;

                PropertyDefinition propDef = propDict[prop.PropDefId];
                string sysName = "{" + propDef.SystemName.ToLower() + "}";
                string dispName = "{" + propDef.DisplayName.ToLower() + "}";

                if (replaceMap.ContainsKey(sysName))
                    replaceMap[sysName] = prop.Val.ToString();
                else if (replaceMap.ContainsKey(dispName))
                    replaceMap[dispName] = prop.Val.ToString();
            }

            foreach (KeyValuePair<string, string> entry in replaceMap)
            {
                if (entry.Value == null)
                    continue;

                Regex r = new Regex(entry.Key, RegexOptions.IgnoreCase);
                url = r.Replace(url, entry.Value);
            }

            return url;
        }

    }
}
