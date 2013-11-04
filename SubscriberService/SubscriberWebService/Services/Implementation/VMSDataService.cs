using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

namespace SubscriberWebService.Services
{

    public class VMSDataService : AbstractDatexService, IVMSDataService
    {
        public putDatex2DataResponse GetDeliverVMSTrafficDataResponse(D2LogicalModel VMSTrafficData)
        {
            log.Info("Handling VMS Traffic Data");
            // Validate the D2Logical Model
            if (!ExampleDataCheckOk(VMSTrafficData))
            {
                throw new SoapException("Incoming request does not appear to be valid!", SoapException.ClientFaultCode);
            }


            VmsPublication payloadPublication = VMSTrafficData.payloadPublication as VmsPublication;

            if (payloadPublication != null)
            {
                VmsUnit vmsUnit = payloadPublication.vmsUnit[0];
                if (vmsUnit != null)
                {
                    log.Info(string.Format("Vmsunit GUID: {0}", vmsUnit.vmsUnitReference.id));

                    IList<_VmsUnitVmsIndexVms> vmsIndexList = vmsUnit.vms;
                    if (vmsIndexList != null && vmsIndexList.Count > 0)
                    {
                        _VmsUnitVmsIndexVms vmsUnitVmsIndexVms = vmsIndexList[0];
                        IList<_VmsMessageIndexVmsMessage> vmsMessageList = vmsUnitVmsIndexVms.vms.vmsMessage;
                        if (vmsMessageList.Count > 0)
                        {
                            VmsMessage vmsMessage = vmsMessageList[0].vmsMessage;
                            IList<_TextPage> textPageList = vmsMessage.textPage;
                            if (textPageList.Count > 0)
                            {
                                _TextPage textPage = textPageList[0];
                                VmsText vmsText = textPage.vmsText;
                                IList<_VmsTextLineIndexVmsTextLine> vmsTextLineList = vmsText.vmsTextLine;
                                if (vmsTextLineList.Count > 0)
                                {
                                    _VmsTextLineIndexVmsTextLine vmsTextLineIndexVmsTextLine = vmsTextLineList[0];
                                    log.Info(string.Format("vms text line {0}", vmsTextLineIndexVmsTextLine.vmsTextLine.vmsTextLine));
                                }
                            }
                        }
                    }
                }
            }

            log.Info("VMSTraffic Data Request: Processing Completed Successfuly");

            return new putDatex2DataResponse { d2LogicalModel = new D2LogicalModel() };

        }
    }
}