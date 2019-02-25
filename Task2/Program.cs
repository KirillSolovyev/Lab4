using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task2 {
    [DataContract]
    public class Mark {
        int numMark = 0;

        [DataMember]
        public int GetMark{
            get {
                return numMark;
            }
            set {
                if(value < 0) {
                    numMark = 0;
                } else if(value > 100) {
                    numMark = 100;
                } else {
                    numMark = value;
                }
            }
        }

        public Mark() {

        }

        public Mark(int _numMark) {
            numMark = _numMark;
        }

        public override string ToString() {
            string letMark = "F";
            if(numMark >= 95) {
                letMark = "A";
            } else if(numMark < 95 && numMark >= 90) {
                letMark = "A-";
            } else if(numMark < 90 && numMark >= 85) {
                letMark = "B+";
            } else if(numMark < 85 && numMark >= 80) {
                letMark = "B";
            } else if(numMark < 80 && numMark >= 75) {
                letMark = "B-";
            } else if(numMark < 75 && numMark >= 60) {
                letMark = "C";
            } else if(numMark < 60 && numMark >= 51) {
                letMark = "D";
            }
            return letMark;
        }
    }
    class Program {
        static void Main(string[] args) {
            List<Mark> Marks = new List<Mark>();
            Marks.Add(new Mark(99999999));
            for(int i = 0; i < 3; i++) {
                Marks.Add(new Mark(79 + (i * 5)));
            }

            XmlSerializer ser = new XmlSerializer(typeof(List<Mark>));

            using(FileStream fs = new FileStream(@"D:\repos\Lab4\Task2\Marks.xml", FileMode.OpenOrCreate)) {
                ser.Serialize(fs, Marks);
            }

            using(FileStream fs = new FileStream(@"D:\repos\Lab4\Task2\Marks.xml", FileMode.Open)) {
                List<Mark> MarksSer = (List<Mark>)ser.Deserialize(fs);
                foreach(var el in MarksSer) {
                    Console.WriteLine("Mark: {0}", el.ToString());
                }
            }
        }
    }
}
