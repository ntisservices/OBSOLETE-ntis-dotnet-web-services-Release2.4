using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriberWebService.Services
{
    public interface ISensorTrafficDataService
    {
        putDatex2DataResponse GetDeliverSensorTrafficDataResponse(D2LogicalModel deliverSensorTrafficDataRequest); 
    }
}
