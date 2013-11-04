using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubscriberWebService.Services
{
    public class FVDTrafficDataService : AbstractDatexService, IFVDTrafficDataService
    {
        public putDatex2DataResponse GetDeliverFVDTrafficDataResponse(D2LogicalModel deliverFVDTrafficDataRequest)
        {
            log.Info("Handling Fused FVD and Sensor PTD Request");

            ElaboratedDataPublication elaboratedDataPublication = deliverFVDTrafficDataRequest.payloadPublication as ElaboratedDataPublication;

            if (elaboratedDataPublication != null)
            {
                ElaboratedData[] trafficDataList = filterEnumerableByType(elaboratedDataPublication.elaboratedData, typeof(TrafficSpeed))
                    .ToArray();
                ElaboratedData[] travelTimeDataList = filterEnumerableByType(elaboratedDataPublication.elaboratedData, typeof(TravelTimeData))
                    .ToArray();

                log.Info("Publication Time is " + elaboratedDataPublication.publicationTime);
                log.Info("Time Default is  " + elaboratedDataPublication.timeDefault);
                log.Info("Total Traffic Data objects  are " + trafficDataList.Length);
                log.Info("Total Travel Time Data objects  are " + travelTimeDataList.Length);

            }
            
            log.Info("Fused FVD and Sensor PTD Request: Processing Completed Successfuly");

            return new putDatex2DataResponse();

        }

        private IEnumerable<T> filterEnumerableByType<T>(IEnumerable<T> payLoadElaboratedDataList, Type type)
        {
            var edEnumerable = from ed in payLoadElaboratedDataList
                               where ed.GetType() == type
                               select ed;

            return edEnumerable;
        }
    }
}