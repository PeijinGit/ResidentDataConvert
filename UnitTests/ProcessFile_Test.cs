using Abstraction;
using BusinessLayer;
using Domain;
using Moq;
using System.ComponentModel;
using Xunit;

namespace UnitTests
{
    public class ProcessFile_Test
    {
        [Fact]
        public void ProcessFile_Should_Execute_WriteCSV_IfTest()
        {
            var csvHandler = new Mock<ICsvHandler>();
            var selectFile = "testPath";
            var destination = "testPath";
            BackgroundWorker worker = new();

            var residentsToBeConvert = new List<ResidentToBeConvert>();
            csvHandler.Setup(x => x.ParseCsv(It.IsAny<string>())).Returns(residentsToBeConvert);
            csvHandler.Setup(x => x.WriteCSV(It.IsAny<string>(), It.IsAny<List<ResidentConverted>>()));

            var subject = new FileProcessor(csvHandler.Object);
            subject.ProcessFile(selectFile, destination, worker);

            csvHandler.Verify(x => x.WriteCSV(It.IsAny<string>(), It.IsAny<List<ResidentConverted>>()),Times.Once);
        }
    }
}