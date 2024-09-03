using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NubanGenerator.Services
{
    public class NubanService : INubanService
    {
        //Below is the method for check digit validation
        private static int ComputeCheckDigit(string digits, int[] weights)
        {
            int sum = 0;

            for (int i = 0; i < digits.Length; i++)
            {
                int digit = int.Parse(digits[i].ToString());
                sum += digit * weights[i];
            }

            int remainder = sum % 10;
            int checkDigit = (10 - remainder) % 10;

            return checkDigit;
        }

        //for digital mobile banks nuban generation, we have...
        public string GenerateNubanDmb(string institutionCode, string serialNumber)
        {
             var paddedInstitutionCode = institutionCode.PadLeft(6, '0');
            string nubanNumber = paddedInstitutionCode + serialNumber.PadLeft(8, '0');

            int[] dmbWeights = { 3, 7, 3, 3, 7, 3, 3, 7, 3, 3, 7, 3, 3, 7, 3 };
            int checkDigit = ComputeCheckDigit(nubanNumber, dmbWeights);

            string institutionName = InstitutionNames.ContainsKey(institutionCode) ? InstitutionNames[institutionCode] : "Unknown Institution";
            return $"{institutionName}: {nubanNumber + checkDigit}";
        }

        public string GenerateNubanOfi(string institutionCode, string serialNumber)
        {
            string paddedInstitutionCode = ("9" + institutionCode).PadLeft(6, '0');
            string nubanNumber = paddedInstitutionCode + serialNumber.PadLeft(8, '0');

            int[] ofiWeights = { 3, 7, 3, 3, 7, 3, 3, 7, 3, 3, 7, 3, 3, 7, 3 };
            int checkDigit = ComputeCheckDigit(nubanNumber, ofiWeights);

            string institutionName = InstitutionNames.ContainsKey(institutionCode) ? InstitutionNames[institutionCode] : "Unknown Institution";
            return $"{institutionName}: {nubanNumber + checkDigit}";
        }


        private static readonly Dictionary<string, string> InstitutionNames = new Dictionary<string, string>
{
    { "011", "First Bank of Nigeria" },
    { "071", "Vale Finance Limited(Vale)" },
    { "023", "United Bank for Africa (UBA)" },
    { "032", "Guaranty Trust Bank" },
    { "033", "Zenith Bank" },
    { "044", "Access Bank" },
    { "045", "EcoBank Nigeria" },
    { "050", "Wema Bank" },
    { "058", "Stanbic IBTC Bank" },
    { "063", "Citibank Nigeria" },
    { "070", "Standard Chartered Bank" },
    { "076", "Fidelity Bank" },
    { "082", "Union Bank" },
    { "085", "Keystone Bank" },
    { "090", "JAIZ Bank" },
    { "301", "Bank of Agriculture" },
    { "304", "Nigeria Export-Import Bank (NEXIM)" }
};

    }
}