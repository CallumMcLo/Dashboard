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
    }
}
