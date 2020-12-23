using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace WinUI2Template.Helpers
{
    internal static class StringToSymbolHelper
    {
        internal static SymbolIcon Convert(string iconName)
        {
            SymbolIcon icon;
            object parsedObject;
            bool didParse = Enum.TryParse(typeof(Symbol), iconName, out parsedObject);
            if (didParse)
            {
                Symbol symbol = (Symbol)parsedObject;
                icon = new SymbolIcon(symbol);
            }
            else
            {
                icon = new SymbolIcon(Symbol.Page2);
            }

            return icon;
        }
    }
}
