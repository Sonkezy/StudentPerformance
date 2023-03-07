using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using StudentPerformance.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StudentPerformance.Models
{
    class Serializer <T>
    {
        /*void Save(string path, Student[] students)
        {
            List<Student> list = new List<Student>();
            foreach (Student student in students)
            {
                list.Add(student);
            }
            using(var stream = File.Open(path, FileMode.Create))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write(list.Count);
                    foreach (Student student in list)
                    {
                        writer.Write(student.Name);
                        writer.Write(student.Elec);
                        writer.Write(student.Elec);
                        writer.Write(student.Elec);
                        writer.Write(student.Elec);
                        writer.Write(student.Elec);
                        writer.Write(student.Elec);

                    }
                }
            }
            
        }*/
        /*
        public static void Save(string path, T item)
        {
            var formatter = new BinaryFormatter();
            using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                formatter.Serialize(stream, item);
                stream.Seek(0, SeekOrigin.Begin);
            }
        }
        public static object Load(string path)
        {
            var formatter = new BinaryFormatter();
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Write, FileShare.Write))
            {
                return formatter.Deserialize(stream);
            }
        }*/

        public static void Save(string path, T item)
        {
            XmlSerializer serializer= new XmlSerializer(typeof(T));
            using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(file, item);
            } 
            
        }
        public static T Load(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                return (T)serializer.Deserialize(file);
            }
            
        }
    }
}
