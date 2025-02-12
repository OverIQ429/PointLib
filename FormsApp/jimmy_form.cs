using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using YamlDotNet.Core;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FormsApp
{
    public class jimmy_form
    {
        string text { get; set; }

        public jimmy_form(string text)
        {
            this.text = text;
        }
        public override string ToString()
        {
            return string.Format(text);
        }
        public static void Serialize(BinaryWriter writer, IList<PointLib.Point> points)
        {
            writer.Write(points.Count);
            for (int i = 0; i < points.Count; i++)
            {
                string pointString = $"{points[i]}";
                writer.Write(pointString);
            }
            
        }
    }
}
