using QZCHY.PanoramaQuzhou.Core;
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

        public void InsertPanoramaScene(PanoramaScene sence)
        {
            if (sence == null) throw new ArgumentNullException("sence");
            else
            {
                _sceneRepository.Insert(sence);
                _eventPublisher.EntityInserted(sence);
            }
        }

        public void UpdatePanoramaScene(PanoramaScene scene)
        {
            if (scene == null) throw new ArgumentNullException("scene");
            else
            {
                _sceneRepository.Update(scene);
                _eventPublisher.EntityUpdated(scene);
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
            if (scene==null || scene.Deleted) return null;
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

        public IQueryable<PanoramaScene> GetAllPanoramaScenes()
        {
            var query = from ps in _sceneRepository.TableNoTracking
                        where !ps.Deleted
                        select ps;

            return query;
        }
        /// <summary>
        /// 将全景图按照由近及远排序
        /// </summary>
        /// <param name="lat">定位位置的纬度</param>
        /// <param name="lng">定位位置的经度</param>
        /// <returns></returns>
        public IEnumerable<PanoramaScene> GetAllPanoramaScenesOrderByDistance(double lat, double lng, int pageSize = 15, int index = 0)
        {
            var query = from ps in _sceneRepository.TableNoTracking
                        where !ps.Deleted
                        select ps;

            var panoramaScenes = query.ToList();

            //foreach (var ps in panoramaScenes)
            //{
            //}


            var result = panoramaScenes.OrderBy(ps => GeographyHelper.GetDistance(lat, lng, ps.PanoramaLocation.Lat, ps.PanoramaLocation.Lng))
                            .Skip(index * pageSize).Take(pageSize);

            return panoramaScenes;
        }
       

      



    }
}
