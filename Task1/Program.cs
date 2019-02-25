using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Task1 {
    class Program {
        static void Main(string[] args) {
            Number.ComplexNumber cn = new Number.ComplexNumber(8, 3); // Class ComplexNumber is moved to a ClassLibrary ComplexNumber
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Number.ComplexNumber)); // Serialize using JSON serializer
            using(FileStream fs = new FileStream(@"D:\repos\Lab4\Task1\ComNum.json", FileMode.OpenOrCreate)) {
                ser.WriteObject(fs, cn); // Serialization
            }
        }
    }
}
