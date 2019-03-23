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

        void InsertPanoramaScene(PanoramaScene location);

        void UpdatePanoramaScene(PanoramaScene location);

        void DeletePanoramaScene(PanoramaScene location);


        PanoramaScene GetSceneById(int id);


    }
}
