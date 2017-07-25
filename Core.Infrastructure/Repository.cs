using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Guards.Extensions;

namespace Camoran.CQRS.Core.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : IAggregateRoot
    {
        public IUnitOfWork UOW { get; protected set; }
        public IEventService EventService { get; protected set; }
        public IAggregateRootFactory<T> AggFactory { get; protected set; }
        private static object _lockObj = new object();


        public Repository(IUnitOfWork unitOfWork,IEventService eventService)
        {
            unitOfWork.EnsureNotNull();
            eventService.EnsureNotNull();

            UOW = unitOfWork;
            EventService = eventService;
        }

        public virtual T GetById(Guid id)
        {
            //聚合根id获取该事件集合,思考，数据量大怎么办,可以用快照的方式解决？
            var events = EventService.GetEvents(id);
            var aggregateRoot = AggFactory.Create();
            aggregateRoot.RestoreFromEvents(events);

            return aggregateRoot;
        }

        public virtual void Save(T t)
        {
            var agg = GetById(t.ID);
            agg.EnsureNotNull();

            var aggVersion = agg.Version;

            Monitor.Enter(_lockObj);

            using (UOW)
            {
                try
                {
                    //保存未执行的事件
                    foreach (var @event in agg.UnCommitEvents)
                    {
                        aggVersion++;
                        @event.Version = aggVersion;
                        EventService.SaveEvent(@event);
                    }

                    UOW.Commit();
                }
                catch
                {
                    UOW.RollBack();
                }
            }

            //发布消息,通知聚合根执行事件，并更改内存中的聚合根为最新状态
            EventService.Publish(agg.UnCommitEvents);

            Monitor.Exit(_lockObj);
        }

    }
}
