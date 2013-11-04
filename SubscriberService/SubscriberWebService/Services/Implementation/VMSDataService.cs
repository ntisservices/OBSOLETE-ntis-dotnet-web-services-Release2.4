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