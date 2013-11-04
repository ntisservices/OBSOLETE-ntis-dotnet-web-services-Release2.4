using System;
using log4net;
using SubscriberWebService.Services;

namespace SubscriberWebService
{

    public class WebServiceSubscriber : supplierPushInterface
    {
        protected static readonly ILog log = LogManager.GetLogger(typeof(WebServiceSubscriber));
        protected static IAnprTrafficDataService anprTrafficDataService = new AnprTrafficDataService();
        protected static IFVDTrafficDataService fvdTrafficDataService = new FVDTrafficDataService();
        protected static IMidasTrafficDataService midasTrafficDataService = new MidasTrafficDataService();
        protected static INtisModelNotificationService ntisModelNotificationService = new NtisModelNotificationService();
        protected static ISensorTrafficDataService SensorTrafficDataService = new SensorTrafficDataService();
        protected static ITMUTrafficDataService tmuTrafficDataService = new TMUTrafficDataService();
        protected static IVMSDataService vmsDataService = new VMSDataService();

        public WebServiceSubscriber()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public putDatex2DataResponse putDatex2Data(putDatex2DataRequest request)
        {
            try
            {
                D2LogicalModel d2LogicalModel = request.d2LogicalModel;
                string feedType = d2LogicalModel.payloadPublication.feedType;
                if (feedType.Contains("ANPR Journey Time Data".ToLower()))
                {
                    return anprTrafficDataService.GetDeliverAnprTrafficDataResponse(d2LogicalModel);
                }
                else if (feedType.Contains("MIDAS Loop Traffic Data".ToLower()))
                {
                    return midasTrafficDataService.GetDeliverMidasTrafficDataResponse(d2LogicalModel);
                }
                else if (feedType.Contains("TMU Loop Traffic Data".ToLower()))
                {
                    return tmuTrafficDataService.GetDeliverTMUTrafficDataResponse(d2LogicalModel);
                }
                else if (feedType.Contains("Fused Sensor-only PTD".ToLower()))
                {
                    return SensorTrafficDataService.GetDeliverSensorTrafficDataResponse(d2LogicalModel);
                }
                else if (feedType.Contains("Fused FVD and Sensor PTD".ToLower()))
                {
                    return fvdTrafficDataService.GetDeliverFVDTrafficDataResponse(d2LogicalModel);
                }
                else if (feedType.Contains("VMS and Matrix Signal Status Data".ToLower()))
                {
                    return vmsDataService.GetDeliverVMSTrafficDataResponse(d2LogicalModel);
                }
                else if (feedType.Contains("NTIS Model Update Notification".ToLower()))
                {
                    return ntisModelNotificationService.GetNtisModelNotificationDataResponse(d2LogicalModel);
                }
                else
                {
                    throw new Exception("Unrecognised feed type");
                }
            }
            catch (Exception e)
            {
                log.Info(e.Message);
                return new putDatex2DataResponse();
            }
        }
    }
}