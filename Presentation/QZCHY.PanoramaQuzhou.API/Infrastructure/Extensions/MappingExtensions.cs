﻿using AutoMapper;

namespace QZCHY.PanoramaQuzhou.Web.Api.Extensions
{
    /// <summary>
    /// 实体到模型映射
    /// </summary>
    public static class MappingExtensions
    {
        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }

        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return Mapper.Map(source, destination);
        }
 
    }
}