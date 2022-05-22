using System.ComponentModel;

namespace Abstraction
{
    public interface IFileProcessor
    {
        void ProcessFile(string fileName, string destination, BackgroundWorker worker);
    }
}