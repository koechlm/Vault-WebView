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
    /// <summary>
    /// This is here for legacy purposes.  Version 1.0 used to store URL data as an XML text in a knowledge option.
    /// The current version uses Vault properties to store the url.
    /// </summary>
    [XmlRoot]
    public class FolderSettings
    {
        public List<FolderSetting> Folders;

        public FolderSettings()
        {
            Folders = new List<FolderSetting>();
        }

        public string ToXml()
        {
            string retval = null;
            try
            {
                StringBuilder buffer = new StringBuilder();
                using (System.IO.StringWriter writer = new System.IO.StringWriter(buffer))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(FolderSettings));
                    serializer.Serialize(writer, this);
                }
                retval = buffer.ToString();
            }
            catch
            {
            }

            return retval;
        }

        public static FolderSettings FromXml(string str)
        {
            FolderSettings settings = null;
            try
            {
                using (System.IO.StringReader reader = new System.IO.StringReader(str))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(FolderSettings));
                    settings = (FolderSettings)serializer.Deserialize(reader);
                }
            }
            catch
            {
                settings = new FolderSettings();
            }

            return settings;
        }
    }

    [XmlType]
    public class FolderSetting
    {
        public long FolderId;

        /// <summary>
        /// The folder path was not part of the 1.0 settings.  It's being added here to make things human readable.
        /// </summary>
        public string FolderPath;

        public string Url;
    }
}
