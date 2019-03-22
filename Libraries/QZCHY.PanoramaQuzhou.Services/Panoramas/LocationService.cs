using QZCHY.PanoramaQuzhou.Core.Data;
using QZCHY.PanoramaQuzhou.Core.Domain.Panoramas;
using QZCHY.PanoramaQuzhou.Services.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QZCHY.PanoramaQuzhou.Services.Panoramas
{
   public  class LocationService:ILocationService
    {
        private readonly IRepository<PanoramaLocation> _locationRepository;
        private readonly IEventPublisher _eventPublisher;

        public LocationService(IRepository<PanoramaLocation> locationRepository, IEventPublisher eventPublisher)
        {
            this._locationRepository = locationRepository;
            this._eventPublisher = eventPublisher;
        }

        public PanoramaLocation GetLocationById(int id)
        {
            var query = from v in _locationRepository.Table
                        where v.Id == id
                        select v;
            return query.FirstOrDefault();
        }
    }
}
