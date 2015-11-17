using System;

namespace DataCaptureModule.AddFieldValue
{
    public interface IModifyValues
    {
        int ModifyLeadValues<Y,M>(Y lead, Action<M> SendBackStatus);
    }
}
