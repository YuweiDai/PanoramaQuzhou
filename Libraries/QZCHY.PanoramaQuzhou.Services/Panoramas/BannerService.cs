using QZCHY.PanoramaQuzhou.Core.Data;
using QZCHY.PanoramaQuzhou.Core.Domain.Panoramas;
using QZCHY.PanoramaQuzhou.Services.Events;
using System;
using System.Linq;

namespace QZCHY.PanoramaQuzhou.Services.Panoramas
{
    public class BannerService : IBannerService
    {
        private readonly IRepository<Banner> _bannerRepository;
        private readonly IEventPublisher _eventPublisher;

        public BannerService(IRepository<Banner> bannerRepository, IEventPublisher eventPublisher)
        {
            this._bannerRepository = bannerRepository;
            this._eventPublisher = eventPublisher;
        }

        public IQueryable<Banner> GetTopBanners(int count=3)
        {
            var query = from b in this._bannerRepository.TableNoTracking
                        where !b.Deleted
                        select b;

            //sort by order then  take three banner
            query = query.OrderBy(b => b.Order).Take(count);

            return query;
        }

        public void InsertBanner(Banner banner)
        {
            if (banner == null) throw new ArgumentNullException();
            else
            {
                _bannerRepository.Insert(banner);
                _eventPublisher.EntityDeleted(banner);
            }
        }
    }
}
