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

        void UpdatePanoramaScene(PanoramaScene location);

        void DeletePanoramaScene(PanoramaScene location);

        PanoramaScene GetPnoramaSceneById(int id);

        IQueryable<PanoramaScene> GetHotPanoramaScenes();

        IQueryable<PanoramaScene> GetNewPanoramaScenes();


    }
}
