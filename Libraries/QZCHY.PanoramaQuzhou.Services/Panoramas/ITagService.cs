using QZCHY.PanoramaQuzhou.Core.Domain.Panoramas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QZCHY.PanoramaQuzhou.Services.Panoramas
{
    public interface ITagService
    {
        Tag GetTagById(int id);
         

        IQueryable<Tag> GetAllTags();
    }
}
