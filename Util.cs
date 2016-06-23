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
using System.IO;
using System.Linq;
using System.Text;

using Autodesk.Connectivity.WebServices;
using Autodesk.Connectivity.WebServicesTools;

using Autodesk.DataManagement.Client.Framework.Vault.Currency.Connections;
using VDF = Autodesk.DataManagement.Client.Framework;

namespace VaultWebView
{
    /// <summary>
    /// Utilities for dealing with Vault users
    /// </summary>
    public class Util
    {
        /// <summary>
        /// Tells if the logged in user is an admin or not.
        /// </summary>
        public static bool IsAdmin(Connection conn)
        {
            long userId = conn.WebServiceManager.SecurityService.SecurityHeader.UserId;
            if (userId > 0)
            {
                Permis[] permissions = conn.WebServiceManager.AdminService.GetPermissionsByUserId(userId);

                // assume that if the current user has the AdminUserRead permission,
                // then they are an admin.
                long adminUserRead = 82;

                foreach (Permis p in permissions)
                {
                    if (p.Id == adminUserRead)
                        return true;
                }
            }
            return false;
        }

        public static void DoAction(Action a)
        {
            try
            {
                a();
            }
            catch (Exception ex)
            {
                VDF.Forms.Library.ShowError(ex, "Vault Web View");
            }
        }

        public static string GetAssemblyPath()
        {
            string prefix = "file:///";
            string codebase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            if (codebase.StartsWith(prefix))
                codebase = codebase.Substring(prefix.Length);

            return Path.GetDirectoryName(codebase);
        }
    }


    internal static class ExtensionMethods
    {
        internal static T[] ToSingleArray<T>(this T obj)
        {
            return new T[] { obj };
        }
        internal static bool IsNullOrEmpty<T>(this IEnumerable<T> collection)
        {
            return collection == null || collection.Count() == 0;
        }

    }
}
