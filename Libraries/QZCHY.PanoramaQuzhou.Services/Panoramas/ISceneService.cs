using QZCHY.PanoramaQuzhou.Core.Domain.Panoramas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QZCHY.PanoramaQuzhou.Services.Panoramas
{
   public interface ISceneService
    {      

        void InsertPanoramaScene(PanoramaScene scene);

        void UpdatePanoramaScene(PanoramaScene scene);

        void DeletePanoramaScene(PanoramaScene scene);

        PanoramaScene GetPnoramaSceneById(int id);

        IQueryable<PanoramaScene> GetHotPanoramaScenes(int count);

        IQueryable<PanoramaScene> GetNewPanoramaScenes(int count);

        IQueryable<PanoramaScene> GetAllPanoramaScenes();


    }
}
