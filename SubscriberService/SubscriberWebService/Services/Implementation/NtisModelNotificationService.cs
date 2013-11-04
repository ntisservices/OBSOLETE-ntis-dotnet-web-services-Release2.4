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
    public class NtisModelNotificationService : AbstractDatexService, INtisModelNotificationService
    {

        public putDatex2DataResponse GetNtisModelNotificationDataResponse(D2LogicalModel deliverNtisModelNotificationDataRequest)
        {
            log.Info("Handling Ntis Model Notification Request!");

            // Validate the D2Logical Model
            if (!ExampleDataCheckOk(deliverNtisModelNotificationDataRequest))
            {
                throw new SoapException("Incoming request does not appear to be valid!", SoapException.ClientFaultCode);
            }

            if (deliverNtisModelNotificationDataRequest.payloadPublication != null)
            {
                GenericPublication genericPublication = deliverNtisModelNotificationDataRequest.payloadPublication as GenericPublication;

                log.Info("Ntis model publication time: " + genericPublication.publicationTime);
                log.Info("Generic publication name: " + genericPublication.genericPublicationName);

                _GenericPublicationExtensionType genericPublicationExtension = genericPublication.genericPublicationExtension;
                NtisModelVersionInformation ntisModelVersionInformation = genericPublicationExtension.ntisModelVersionInformation;

                log.Info("Network model - file name " + ntisModelVersionInformation.modelFilename);
                log.Info("Network model - version " + ntisModelVersionInformation.modelVersion);
                log.Info("Network model - publication time " + ntisModelVersionInformation.modelPublicationTime);                
            }


            log.Info("Ntis Model Notification Data Request: Processing Completed Successfuly");

            return new putDatex2DataResponse { d2LogicalModel = new D2LogicalModel() };
        }
    }
}