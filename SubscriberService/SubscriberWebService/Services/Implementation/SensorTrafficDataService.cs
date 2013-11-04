using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

namespace SubscriberWebService.Services
{
    public class SensorTrafficDataService : AbstractDatexService, ISensorTrafficDataService
    {
        public putDatex2DataResponse GetDeliverSensorTrafficDataResponse(D2LogicalModel request)
        {
            log.Info("Handling Fused Sensor-only PTD Request!");

            // Validate the D2Logical Model
            if (!ExampleDataCheckOk(request))
            {
                throw new SoapException("Incoming request does not appear to be valid!", SoapException.ClientFaultCode);
            }


            ElaboratedDataPublication elaboratedDataPublication = request.payloadPublication as ElaboratedDataPublication;

            if (elaboratedDataPublication != null)
            {
                log.Info("Publication Time is " + elaboratedDataPublication.publicationTime);
                log.Info("Time Default is  " + elaboratedDataPublication.timeDefault);
                log.Info("Total Elaborated Data objects  are " + elaboratedDataPublication.elaboratedData.Length);
            }

            log.Info("Fused Sensor-only PTD Request: Processing Completed Successfuly");

            return new putDatex2DataResponse { d2LogicalModel = new D2LogicalModel() };
        }
    }
}
