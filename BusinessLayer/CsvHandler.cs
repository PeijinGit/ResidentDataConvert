using Abstraction;
using CsvHelper;
using CsvHelper.Configuration;
using Domain;
using Domain.Static;
using System.Globalization;

namespace BusinessLayer
{
    public class CsvHandler : ICsvHandler
    {
        public List<ResidentToBeConvert> ParseCsv(string filePath)
        {
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = false
            };

            using var streamReader = File.OpenText(filePath);
            using var csvReader = new CsvReader(streamReader, csvConfig);
            csvReader.Read();
            var residents = csvReader.GetRecords<ResidentToBeConvert>();
            return residents.ToList();
        }

        public void WriteCSV(string destination,List<ResidentConverted> residentsConverted)
        {
            var currentDatetime = DateTime.Now;
            using (var writer = new StreamWriter(String.Format(CommonValue.FileNameFormat, destination, currentDatetime.ToString(CommonValue.FileNameDatetime), CommonValue.FileNameStandard)))
            {
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(residentsConverted);
                }
            }
        }
    }
}
