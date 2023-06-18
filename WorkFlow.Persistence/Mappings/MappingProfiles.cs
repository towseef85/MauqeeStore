using AutoMapper;
using MStore.Application.Dtos.CatalogDtos.Category;
using MStore.Domain.Entities.Catalog.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlow.Persistence.Mappings
{
    public class MappingProfiles :Profile
    {
        public MappingProfiles()
        {
            CreateMap<PostCategoryDto, Category>();
            CreateMap<Category, GetCategoriesDto>();
        }
    }
}
