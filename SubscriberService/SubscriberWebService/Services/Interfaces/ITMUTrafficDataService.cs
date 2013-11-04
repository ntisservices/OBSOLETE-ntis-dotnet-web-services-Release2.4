using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace SubscriberWebService.Services
{
    public interface ITMUTrafficDataService
    {
        putDatex2DataResponse GetDeliverTMUTrafficDataResponse(D2LogicalModel deliverTMUTrafficDataRequest);
    }
}