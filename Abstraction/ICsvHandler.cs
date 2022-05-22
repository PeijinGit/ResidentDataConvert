using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    public interface ICsvHandler
    {
        List<ResidentToBeConvert> ParseCsv(string filePath);
        void WriteCSV(string destination, List<ResidentConverted> residentsConverted);
    }
}
