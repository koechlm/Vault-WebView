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
using System.Text;
using System.Xml.Serialization;

namespace VaultWebView
{
    [XmlRoot("Settings")]
    public class Settings
    {
        [XmlElement("Tabs")]
        public List<TabSettings> Tabs = new List<TabSettings>();


        public String Save()
        {
            try
            {
                StringBuilder buffer = new StringBuilder();
                using (System.IO.StringWriter writer = new System.IO.StringWriter(buffer))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                    serializer.Serialize(writer, this);
                }

                return buffer.ToString();
            }
            catch
            { }

            return null;
        }

        public static Settings Load(String xml)
        {
            Settings retVal = null;

            try
            {
                using (System.IO.StringReader reader = new System.IO.StringReader(xml))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                    retVal = (Settings)serializer.Deserialize(reader);
                }
            }
            catch
            { }

            if (retVal == null)
            {
                retVal = new Settings();
                retVal.Tabs = new List<TabSettings>();
            }
            return retVal;
        }
    }

    [XmlRoot("Settings")]
    public class TabSettings
    {
        [XmlAttribute("TabName")]
        public String TabName { get; set; }

        [XmlElement("EntityClasses")]
        public List<String> EntityClasses = new List<string>();

        [XmlAttribute("Url")]
        public String Url;

        [XmlIgnore]
        public Guid Guid = Guid.NewGuid();

        public override string ToString()
        {
            return TabName;
        }

        /// <summary>
        /// Copy data into this object from another object.
        /// </summary>
        public void Copy(TabSettings newSettings)
        {
            this.TabName = newSettings.TabName;
            this.EntityClasses = newSettings.EntityClasses;
            this.Url = newSettings.Url;
            this.Guid = newSettings.Guid;
        }
    }
}
