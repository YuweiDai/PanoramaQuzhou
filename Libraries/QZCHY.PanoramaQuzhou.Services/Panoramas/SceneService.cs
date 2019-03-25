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
   public class SceneService: ISceneService
    {
        private readonly IRepository<PanoramaScene> _sceneRepository;
        private readonly IRepository<PanoramaLocation> _locationRepository;
        private readonly IEventPublisher _eventPublisher;

        public SceneService(IRepository<PanoramaScene> sceneRepository, IRepository<PanoramaLocation> locationRepository, IEventPublisher eventPublisher)
        {
            this._sceneRepository = sceneRepository;
            this._locationRepository = locationRepository;
            this._eventPublisher = eventPublisher;
        }

        public PanoramaScene GetSceneById(int id)
        {
            var query = from v in _sceneRepository.Table
                        where v.Id == id
                        select v;
      

            return query.FirstOrDefault();
        }

        public void InsertPanoramaScene(PanoramaScene sencen)
        {
            if (sencen == null) throw new ArgumentNullException("location");
            else
            {
                _sceneRepository.Insert(sencen);
                _eventPublisher.EntityInserted(sencen);
            }
        }

        public void UpdatePanoramaScene(PanoramaScene location)
        {
            if (location == null) throw new ArgumentNullException("location");
            else
            {
                _sceneRepository.Update(location);
                _eventPublisher.EntityUpdated(location);
            }
        }

        public void DeletePanoramaScene(PanoramaScene location)
        {
            if (location == null) throw new ArgumentNullException("location");
            else
            {
                _sceneRepository.Delete(location);
                _eventPublisher.EntityDeleted(location);
            }
        }

        public PanoramaScene GetPnoramaSceneById(int id)
        {
            var scene = _sceneRepository.GetById(id);
            if (scene.Deleted) return null;
            else return scene;
        }

        public IQueryable<PanoramaScene> GetHotPanoramaScenes(int count)
        {
            var query = from ps in _sceneRepository.TableNoTracking
                        where !ps.Deleted
                        select ps;

            query = query.OrderByDescending(ps => ps.Views).Take(count);

            return query;

        }

        public IQueryable<PanoramaScene> GetNewPanoramaScenes(int count)
        {
            var query = from ps in _sceneRepository.TableNoTracking
                        where !ps.Deleted
                        select ps;

            query = query.OrderByDescending(ps => ps.ProductionDate).Take(count);

            return query;
        }
    }
}
