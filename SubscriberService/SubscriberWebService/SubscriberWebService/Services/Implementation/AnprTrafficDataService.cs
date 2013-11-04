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
using log4net;
using System.Web.Services.Protocols;

namespace SubscriberWebService.Services
{
    public class AnprTrafficDataService : AbstractDatexService, IAnprTrafficDataService
    {
        #region IAnprTrafficDataService Members

        public putDatex2DataResponse GetDeliverAnprTrafficDataResponse(D2LogicalModel deliverANPRTrafficDataRequest)
        {
            log.Info("New DeliverANPRTrafficDataRequest received.");

            // Validate the D2Logical Model
            if (!ExampleDataCheckOk(deliverANPRTrafficDataRequest))
            {
                throw new SoapException("Incoming request does not appear to be valid!", SoapException.ClientFaultCode);
            }


            MeasuredDataPublication measuredDataPublication = deliverANPRTrafficDataRequest.payloadPublication as MeasuredDataPublication;

            log.Info("Got MeasuredDataPublication from request");

            log.Info("Feed Type " + measuredDataPublication.feedType);

            log.Info("ANPR Request: Processing Completed Successfuly");

            return new putDatex2DataResponse { d2LogicalModel = new D2LogicalModel() };

        }

        #endregion
    }
}
