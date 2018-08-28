using System;
using System.Reflection;
using System.Windows.Controls;

namespace ExtensionMethods
{
    public static class ExtensionMethods
    {
        //Check if object has a method
        public static bool HasMethod(this UserControl objectToCheck, string methodName)
        {
            try
            {
                var type = objectToCheck.GetType();
                return type.GetMethod(methodName) != null;
            }

            catch (AmbiguousMatchException)
            {
                // ambiguous means there is more than one result,
                return true;
            }
        }

        // convert a secure string into a normal plain text string
        public static String ToPlainString(this System.Security.SecureString secureStr)
        {
            String plainStr = new System.Net.NetworkCredential(string.Empty, secureStr).Password;
            return plainStr;
        }

        // convert a plain text string into a secure string
        public static System.Security.SecureString ToSecureString(this String plainStr)
        {
            System.Security.SecureString secStr = new System.Security.SecureString(); secStr.Clear();
            foreach (char c in plainStr.ToCharArray())
            {
                secStr.AppendChar(c);
            }
            return secStr;
        }
    }
}
