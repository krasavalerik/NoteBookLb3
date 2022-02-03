using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Threading.Tasks;

namespace Lb3Txi
{
    public class Save
    {
        NoteBook note;

        public void SaveNote(String path, NoteBook n)
        {
            try
            {
                Stream s = File.Create(path);
                XmlSerializer serial = new XmlSerializer(typeof(NoteBook));
                serial.Serialize(s, n);
                s.Close();
            }

            catch(Exception e)
            {
                var v = e.ToString();
            }
        }

        public NoteBook LoadNote(String path)
        {
            try
            {
                Stream s = File.OpenRead(path);
                XmlSerializer serial = new XmlSerializer(typeof(NoteBook));
                note = (NoteBook)serial.Deserialize(s);
                s.Close();
                return note;
            }

            catch(Exception)
            {
                return null;
            }
        }
    }
}
