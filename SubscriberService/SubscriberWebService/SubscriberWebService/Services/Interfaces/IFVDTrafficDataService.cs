using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriberWebService.Services
{
    public interface IFVDTrafficDataService
    {
        putDatex2DataResponse GetDeliverFVDTrafficDataResponse(D2LogicalModel deliverFVDTrafficDataRequest); 
    }
}
