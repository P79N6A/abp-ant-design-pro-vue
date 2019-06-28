//using System;
//using Niue.Abp.Abp.BackgroundJobs;
//using Niue.Abp.Abp.Dependency;
//using Niue.Abp.Abp.UI;

//namespace Viaduct.BackgroundJobs.Jobs
//{
//    public class JPushJob : BackgroundJob<JPushParam>, ITransientDependency
//    {
//        private static readonly string AppKey = ConfigurationManager.AppSettings["JPush.Bus.AppKey"];
//        private static readonly string MasterSecret = ConfigurationManager.AppSettings["JPush.Bus.MasterSecret"];

//        private readonly IOrderSplitManager _orderSplitManager;

//        public JPushJob(IOrderSplitManager orderSplitManager)
//        {
//            _orderSplitManager = orderSplitManager;
//        }

//        public override void Execute(JPushParam jPushParam)
//        {
//            Logger.Debug("JPush-" + JsonHelper.FromObjectToJson(jPushParam));
//            try
//            {
//                var client = new JPushClient(AppKey, MasterSecret);
//                var payload = JPushHelper.PushObject_All_All_Alert(jPushParam);
//                var jPushResult = JPushHelper.Push(client, payload);
//                var orderSplitId = new Guid(jPushParam.Data);
//                if (jPushParam.Type == "Flash Booking")
//                {
//                    var orderSplit = _orderSplitManager.GetOrderSplitById(orderSplitId);
//                    if (jPushResult.Code == 0)
//                    {
//                        orderSplit.IsPush = true;
//                    }
//                    else
//                    {
//                        throw new UserFriendlyException("由于推送系统出现错误而导致发布失败。" + jPushParam.Data);
//                    }
//                }
//            }
//            catch (Exception exception)
//            {
//                Logger.Debug("JPushException-" + JsonHelper.FromObjectToJson(exception));
//            }
//        }
//    }
//}
