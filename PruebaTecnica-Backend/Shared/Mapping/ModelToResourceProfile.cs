using AutoMapper;
using PruebaTecnica_Backend.Products.Domain.Models;
using PruebaTecnica_Backend.Products.Resources;

namespace PruebaTecnica_Backend.Shared.Mapping
{
    public class ModelToResourceProfile: Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Product, ProductResource>();
        }
    }
}
