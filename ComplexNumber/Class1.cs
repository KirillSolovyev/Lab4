using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Number
{
    [DataContract] // More powerful attrubute for serialization; Serializes all fields, properties preceding with [DataMember]
    public class ComplexNumber {
        [DataMember]
        public decimal realPart = 0;
        [DataMember]
        public decimal imaginaryPart = 0;

        public ComplexNumber(decimal realP, decimal imaginaryP) {
            realPart = realP;
            imaginaryPart = imaginaryP;
        }

        public void Display() {
            Console.WriteLine(realPart + " + " + imaginaryPart + "i");
        }
    }
}
