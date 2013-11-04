using System.Collections.Generic;
using System.Web.Services.Protocols;


namespace SubscriberWebService.Services
{
    public class TMUTrafficDataService : AbstractDatexService, ITMUTrafficDataService
    {
        public putDatex2DataResponse GetDeliverTMUTrafficDataResponse(D2LogicalModel request)
        {
            log.Info("NEW DeliverTMUTrafficDataRequest Received!");

            if (!ExampleDataCheckOk(request))
                throw new SoapException("Incoming request does not appear to be valid!", SoapException.ClientFaultCode);

            MeasuredDataPublication measuredDataPublication = request.payloadPublication as MeasuredDataPublication;

            if (measuredDataPublication != null)
            {
                SiteMeasurements[] siteMeasurementsArray = measuredDataPublication.siteMeasurements;
                foreach (SiteMeasurements siteMeasurements in siteMeasurementsArray)
                {
                    _SiteMeasurementsIndexMeasuredValue[] measuredValueArray = siteMeasurements.measuredValue;
                    foreach (_SiteMeasurementsIndexMeasuredValue siteMeasurementsIndexMeasuredValue in measuredValueArray)
                    {
                        MeasuredValue measuredValue = siteMeasurementsIndexMeasuredValue.measuredValue;
                        BasicData basicData = measuredValue.basicData;

                        if (basicData is TrafficFlow)
                        {
                            VehicleFlowValue value = ((TrafficFlow)basicData).vehicleFlow;
                            log.Info("Vehicle flow rate : " + value.vehicleFlowRate);
                        }
                        else if (basicData is TrafficSpeed)
                        {
                            float speed = ((TrafficSpeed)basicData).averageVehicleSpeed.speed;
                            log.Info("Traffic speed : " + speed);
                        }
                        else if (basicData is TrafficHeadway)
                        {
                            float headWay = ((TrafficHeadway)basicData).averageTimeHeadway.duration;
                            log.Info("Traffic Headway : " + headWay);
                        }
                        else if (basicData is TrafficConcentration)
                        {
                            float percentage = ((TrafficConcentration)basicData).occupancy.percentage;
                            log.Info("Traffic concentration percentage : " + percentage);
                        }
                    }
                }
            }

            return new putDatex2DataResponse { d2LogicalModel = new D2LogicalModel() };

        }
    }
}