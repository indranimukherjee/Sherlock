using System;
using UtilityBusiness;

namespace DataCaptureModule.EntryPoint.Handler
{
    public interface IEntryHandler
    {
        int CaptureLead<T>(AllFieldCapture lead, Action<T> SendBackStatus);
    }
}
