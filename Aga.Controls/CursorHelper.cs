using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

namespace Aga.Controls
{
    public static class CursorHelper
    {
        // VSpilt Cursor with Innerline (symbolisize hidden column)
        private static Cursor _DVSplit = GetCursor(Properties.Resources.DVSplit);
        public static Cursor DVSplit
        {
            get { return _DVSplit; }
        }


        /// <summary>
        /// Helpfunction to convert byte[] from resource into Cursor Type 
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
