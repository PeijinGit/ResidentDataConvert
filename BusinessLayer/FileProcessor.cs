using Abstraction;
using Domain;
using Domain.Static;
using System.ComponentModel;

namespace BusinessLayer
{
    public class FileProcessor : IFileProcessor
    {
        private readonly ICsvHandler _csvHandler;
        
        public FileProcessor(ICsvHandler csvHandler)
        {
            _csvHandler = csvHandler;
        }
        public void ProcessFile(string fileName, string destination, BackgroundWorker worker)
        {
            try
            {
                var residentsToBeConvert = _csvHandler.ParseCsv(fileName);

                residentsToBeConvert.Where(r => r.Gen == CommonValue.MaleAbb).ToList().ForEach(r => r.Gen = CommonValue.Male);
                residentsToBeConvert.Where(r => r.Gen == CommonValue.FemaleAbb).ToList().ForEach(r => r.Gen = CommonValue.Female);
                residentsToBeConvert.Where(r => r.Gen == CommonValue.UnknownAbb).ToList().ForEach(r => r.Gen = CommonValue.Unknown);
                residentsToBeConvert.Where(r => r.Gen == CommonValue.OtherAbb).ToList().ForEach(r => r.Gen = CommonValue.Other);

                List<ResidentConverted> residentsConverted = new List<ResidentConverted>();

                var totalResidents = residentsToBeConvert.Count;
                for (int i = 0; i < totalResidents; i++) 
                {
                    var converted = new ResidentConverted()
                    {
                        FirstName = residentsToBeConvert[i].GivenName,
                        LastName = residentsToBeConvert[i].SurnName,
                        Gender = residentsToBeConvert[i].Gen,
                        PatientUniqueIdentifierType = !string.IsNullOrEmpty(residentsToBeConvert[i].Nhi) ? CommonValue.NHI : null,
                        PatientUniqueIdentifier = residentsToBeConvert[i].Nhi
                    };
                    converted.DOB = DateTime.TryParse(residentsToBeConvert[i].Dob, out DateTime dateTime) ? dateTime.ToString(CommonValue.DateTimeFormat) : null;

                    residentsConverted.Add(converted);
                    var pro = (i+1) * 100 / totalResidents ;
                    worker.ReportProgress(pro);
                }

                _csvHandler.WriteCSV(destination, residentsConverted);

            }
            catch (Exception ex) 
            {
                throw;
            }
        }

    }
}