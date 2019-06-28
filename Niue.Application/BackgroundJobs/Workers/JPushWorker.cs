//using System;
//using System.Collections.Generic;
//using Niue.Abp.Abp.Dependency;
//using Niue.Abp.Abp.Domain.Uow;
//using Niue.Abp.Abp.Threading.BackgroundWorkers;
//using Niue.Abp.Abp.Threading.Timers;

//namespace Viaduct.BackgroundJobs.Workers
//{
//    public class JPushWorker : PeriodicBackgroundWorkerBase, ISingletonDependency
//    {
//        private static readonly string AppKey = ConfigurationManager.AppSettings["JPush.Bus.AppKey"];
//        private static readonly string MasterSecret = ConfigurationManager.AppSettings["JPush.Bus.MasterSecret"];

//        private readonly IOrderSplitManager _orderSplitManager;
//        private readonly IOrderSplitTripNodeManager _orderSplitTripNodeManager;
//        private readonly INoticeManager _noticeManager;

//        public JPushWorker(AbpTimer timer, IOrderSplitManager orderSplitManager, IOrderSplitTripNodeManager orderSplitTripNodeManager, INoticeManager noticeManager) : base(timer)
//        {
//            _orderSplitManager = orderSplitManager;
//            _orderSplitTripNodeManager = orderSplitTripNodeManager;
//            _noticeManager = noticeManager;
//            Timer.Period = 360000; //5 seconds (good for tests, but normally will be more)
//        }

//        [UnitOfWork]
//        protected override void DoWork()
//        {
//            using (CurrentUnitOfWork.DisableFilter(AbpDataFilters.MayHaveTenant))
//            {
//                var orderSplits = _orderSplitManager.GetOrderSplits(o => o.State == EnumSplitState.FlashBooked || o.State == EnumSplitState.IsAboutToBegin);
//                var orderSplitTripNodes = _orderSplitTripNodeManager.GetOrderSplitTripNodes(o => o.TripNo == 1);
//                var noticeRelations = _noticeManager.GetNoticeRelations();
//                var client = new JPushClient(AppKey, MasterSecret);
//                foreach (var orderSplit in orderSplits)
//                {
//                    var orderSplitTripNode = orderSplitTripNodes.FirstOrDefault(o => o.SplitId == orderSplit.Id);
//                    if (orderSplitTripNode == null || !(orderSplitTripNode.BeginTime >= DateTime.Now.AddDays(2) && orderSplitTripNode.BeginTime <= DateTime.Now.AddDays(2).AddHours(1)))
//                    {
//                        continue;
//                    }
//                    var firstOrDefault =
//                        noticeRelations.FirstOrDefault(
//                            o => o.DataGuid == orderSplit.Id && o.Notice.Type == EnumNoticeType.BusReminder);
//                    if (firstOrDefault != null)
//                    {
//                        continue;
//                    }
//                    var notice = new Notice();
//                    notice.Type = EnumNoticeType.BusReminder;
//                    notice.Title = "Please submit bus information.";
//                    notice.Detail = "There are 48 hours to start the order of No." + orderSplit.No + ", please submit the bus information in advance 24 hours, so as to contact.";
//                    _noticeManager.CreateNotice(notice);
//                    var noticeRelation = new NoticeRelation();
//                    noticeRelation.Notice = notice;
//                    noticeRelation.ReceiverId = orderSplit.FlashBookerId.Value;
//                    noticeRelation.SenderId = 1;
//                    noticeRelation.State = EnumNoticeState.NotRead;
//                    _noticeManager.CreateNoticeRelation(noticeRelation);
//                    var jPushParam = new JPushParam();
//                    jPushParam.Time = DateTime.Now;
//                    jPushParam.Type = "24h remind";
//                    jPushParam.Message = "Please submit bus information.";
//                    jPushParam.Data = "There are 48 hours to start the order of No." + orderSplit.No + ", please submit the bus information in advance 24 hours, so as to contact.";
//                    jPushParam.Alias = new HashSet<string> {orderSplit.FlashBookerEmail};
//                    var payload = JPushHelper.PushObject_all_alias_alert(jPushParam);
//                    var jPushResult = JPushHelper.Push(client, payload);
//                    if (jPushResult.Code == 0)
//                    {
//                        noticeRelation.DataGuid = orderSplit.Id;
//                    }
//                    Logger.Info("JPush-" + JsonHelper.FromObjectToJson(jPushParam) + "-" + JsonHelper.FromObjectToJson(jPushParam));
//                }

//                CurrentUnitOfWork.SaveChanges();
//            }
//        }
//    }
//}
