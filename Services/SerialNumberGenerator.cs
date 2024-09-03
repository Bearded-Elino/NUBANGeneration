using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NubanGenerator.Services
{
    public class SerialNumberGenerator
    {
        public static string GenerateSerialNumber(int length = 8)
    {
        Random random = new Random();
        string serialNumber = "";
        for (int i = 0; i < length; i++)
        {
            serialNumber += random.Next(0, 10); // Generate a digit between 0 and 9
        }
        return serialNumber;
    }
    }
}