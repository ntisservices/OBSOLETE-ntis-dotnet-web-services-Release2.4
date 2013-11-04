using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubscriberWebService.Services
{
    public interface IVMSDataService
    {
        putDatex2DataResponse GetDeliverVMSTrafficDataResponse(D2LogicalModel deliverTMUTrafficDataRequest);
    }
}
