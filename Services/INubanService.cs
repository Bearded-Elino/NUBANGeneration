using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NubanGenerator.Services
{
    public interface INubanService
    {
        string GenerateNubanDmb(string institutionCode, string serialNumber);
        string GenerateNubanOfi(string institutionCode, string serialNumber);
    }
}