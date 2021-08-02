using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TrueFalseEditor
{
    class TrueFalse
    {
        
        #region  Private Fields

        string fileName;
        private List<Question> list;

        #endregion

        #region Public Properties
        public bool Changed { get; set; }
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public int Count
        {
            get { return list.Count; }
        }

        public Question this[int index]
        {
            get { return list[index]; }
        }

        #endregion


        #region Constructors

        public TrueFalse(string fileName)
        {
            this.fileName = fileName;
            list = new List<Question>();
        }

        public TrueFalse()
        {
            list = new List<Question>();
        }

        #endregion

        #region Public Methods

        public void Add(string text, bool trueFalse)
        {
            list.Add(new Question(text, trueFalse));
        }

        public void Remove(int index)
        {
            if (list != null && index < list.Count && index >= 0)
                list.RemoveAt(index);
        }



        public void Load()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Question>));
            var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            list = (List<Question>)xmlSerializer.Deserialize(stream);
            stream.Close();
        }

        public void Save()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Question>));
            var stream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xmlSerializer.Serialize(stream, list);
            stream.Close();
        }

        #endregion

    }
}
