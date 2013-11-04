using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubscriberWebService.Services
{
    public class SensorTrafficDataService : AbstractDatexService, ISensorTrafficDataService
    {
        public putDatex2DataResponse GetDeliverSensorTrafficDataResponse(D2LogicalModel deliverSensorTrafficDataRequest)
        {
            log.Info("Handling Fused Sensor-only PTD Request!");

            ElaboratedDataPublication elaboratedDataPublication = deliverSensorTrafficDataRequest.payloadPublication as ElaboratedDataPublication;

            if (elaboratedDataPublication != null)
            {
                log.Info("Publication Time is " + elaboratedDataPublication.publicationTime);
                log.Info("Time Default is  " + elaboratedDataPublication.timeDefault);
                log.Info("Total Elaborated Data objects  are " + elaboratedDataPublication.elaboratedData.Length);
            }

            log.Info("Fused Sensor-only PTD Request: Processing Completed Successfuly");

            return new putDatex2DataResponse();
        }
    }
}
