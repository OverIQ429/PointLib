using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            {
                writer.Write(points.Count);

                foreach (PointLib.Point point in points)
                {

                    if (point is Point3D point3D)
                    {
                        writer.Write((byte)1); 
                        writer.Write(point3D.X);
                        writer.Write(point3D.Y);
                        writer.Write(point3D.Z);
                    }
                    else
                    {
                        writer.Write((byte)0); 
                        writer.Write(point.X);
                        writer.Write(point.Y);
                    }
                    Console.WriteLine($"Количество точек для десериализации: {writer}");
                }
            }
        }
        public static PointLib.Point[] Deserialize(BinaryReader reader)
        {
            int length = reader.ReadInt32();
            PointLib.Point[] points = new PointLib.Point[length];

            for (int i = 0; i < length; i++)
            {
                byte typeCode = reader.ReadByte();

                if (typeCode == 1)
                {
                    Point3D point3D = new Point3D();
                    point3D.X = reader.ReadInt32();
                    point3D.Y = reader.ReadInt32();
                    point3D.Z = reader.ReadInt32();
                    points[i] = point3D;
                }
                else
                {

                    PointLib.Point point = new PointLib.Point();
                    point.X = reader.ReadInt32();
                    point.Y = reader.ReadInt32();
                    points[i] = point;
                }
            }

            return points;
        }
    
    }
}
