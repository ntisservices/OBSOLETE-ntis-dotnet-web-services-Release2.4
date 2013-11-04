using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubscriberWebService.Services
{
    public class NtisModelNotificationService : AbstractDatexService, INtisModelNotificationService
    {

        public putDatex2DataResponse GetNtisModelNotificationDataResponse(D2LogicalModel deliverNtisModelNotificationDataRequest)
        {
            log.Info("Handling Ntis Model Notification Request!");

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

            return new putDatex2DataResponse();
        }
    }
}