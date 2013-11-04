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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

namespace SubscriberWebService.Services
{
    public class FVDTrafficDataService : AbstractDatexService, IFVDTrafficDataService
    {
        public putDatex2DataResponse GetDeliverFVDTrafficDataResponse(D2LogicalModel deliverFVDTrafficDataRequest)
        {
            log.Info("Handling Fused FVD and Sensor PTD Request");

            // Validate the D2Logical Model
            if (!ExampleDataCheckOk(deliverFVDTrafficDataRequest))
            {
                throw new SoapException("Incoming request does not appear to be valid!", SoapException.ClientFaultCode);
            }


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

            return new putDatex2DataResponse { d2LogicalModel = new D2LogicalModel() };

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