// Copyright (C) 2011 Thales Transportation Systems UK 
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy,modify, merge, publish, distribute, sublicense, and/or sell 
// copies of the Software, and to permit persons to whom the Software is 
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software. 
//    
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN 
// THE SOFTWARE.

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