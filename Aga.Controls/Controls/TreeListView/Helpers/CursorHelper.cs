using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

namespace Quimron.WinUI.Controls.TreeListView.Helpers
{
    public static class CursorHelper
    {
        // VSpilt Cursor mit Innenlinie (symbolisiert versteckte Spalte)
        private static Cursor _DVSplit = GetCursor(Resources.DVSplit);
        public static Cursor DVSplit
        {
            get { return _DVSplit; }
        }


        /// <summary>
        /// Hilfsfunktion um byte[] aus resource in Cursor Type zu wandeln
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static Cursor GetCursor(byte[] data)
        {
            using (MemoryStream s = new MemoryStream(data))
            {
                return new Cursor(s);
            }
        }

    }
}
