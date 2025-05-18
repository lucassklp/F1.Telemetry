using System.Runtime.InteropServices;

namespace F1.Telemetry.Collector.Processors;

public static class UnmarshallProcessor
{
    public static T ToStruct<T>(this byte[] data) where T : struct
    {
        GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);
        try
        {
            return (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
        }
        finally
        {
            handle.Free();
        }
    }
}