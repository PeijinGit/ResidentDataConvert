using Abstraction;
using Domain;
using Domain.Static;

namespace BusinessLayer
{
    public class FileChecker : IFileCheck
    {

        public CommonResponse CheckFileExisting(string selectPath)
        {
            CommonResponse response = new CommonResponse { ErrorCode = false };
            if (!File.Exists(selectPath))
            {
                response = new CommonResponse()
                {
                    ErrorCode = true,
                    Message = ErrorMessage.FileNotExist
                };
            }

            if (!FileFormatIsMatchModel(selectPath)) 
            {
                response = new CommonResponse()
                {
                    ErrorCode = true,
                    Message = ErrorMessage.FieldsNotMatch
                };
            }

            return response;
        }

        private bool FileFormatIsMatchModel(string selectPath)
        {
            try
            {
                using (StreamReader sr = new StreamReader(selectPath)) 
                {
                    var firstLine = sr.ReadLine();
                    string line = string.IsNullOrEmpty(firstLine) ? string.Empty : firstLine.ToUpper();
                    var fileds = line.Split(',').ToList();
                    if (
                        fileds.Contains(CommonValue.RequiredFieldGivenName)
                        && fileds.Contains(CommonValue.RequiredFieldSurnName)
                        &&fileds.Contains(CommonValue.RequiredFieldDob)
                        &&fileds.Contains(CommonValue.RequiredFieldGen)
                        && fileds.Contains(CommonValue.NHI)
                        ) 
                    {
                        return true;
                    }
                }
                return false;
            }
            catch 
            {
                throw;
            }
        }
    }
}
