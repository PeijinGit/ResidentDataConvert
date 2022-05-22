using Domain;

namespace Abstraction
{
    public interface IFileCheck
    {
        CommonResponse CheckFileExisting(string selectPath);

    }
}
