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
                string pointString = $"{points[i].X}, {points[i].Y},";
                writer.Write(pointString);
            }
            
        }

        public static Point3D[] Deserialize(BinaryReader path)
        {
            List<jimmy_form> forms = new List<jimmy_form>();
            int count = path.ReadInt32();
            Console.WriteLine($"Количество точек для десериализации: {count}");
            Point3D[] points = new Point3D[forms.Count];
            for (int i = 0; i < count; i++)
            {
                string pointString = path.ReadString();
                Console.WriteLine($"Десериализованная строка: {pointString}");
                forms.Add(new jimmy_form(pointString));
                points[i] = new Point3D(pointString[0], pointString[1], pointString[2]);
            }
            return points;
        }
    }
}
