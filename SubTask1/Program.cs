using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace SubTask1 {
    class Program {
        static void Main(string[] args) { // Deserialize from other file to demostrate the use of serialization
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Number.ComplexNumber)); // Json serializer
            FileStream fs = null;
            try { // Try/Catch to avoid exceptions
                fs = new FileStream(@"D:\repos\Lab4\Task1\ComNum.json", FileMode.Open);
                Number.ComplexNumber serCn = (Number.ComplexNumber)ser.ReadObject(fs); // Deserialization from .json
                serCn.Display();
            } catch(FileNotFoundException e) {
                Console.WriteLine(e.Message);
            } catch(Exception) {
                Console.WriteLine("Unknown Error");
            } finally {
                if(fs != null) { // Closing stream anyway
                    fs.Close();
                }
            }
        }
    }
}
