using System.IO;

namespace NXLogger.StreamLog.StreamWriter
{
    public interface IStreamFactory
    {
        Stream Create();
    }
}
