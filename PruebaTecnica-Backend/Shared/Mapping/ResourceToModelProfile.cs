using AutoMapper;
using PruebaTecnica_Backend.Products.Domain.Models;
using PruebaTecnica_Backend.Products.Resources;

namespace PruebaTecnica_Backend.Shared.Mapping
{
    public class ResourceToModelProfile: Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveProductResource, Product>();
        }
    }
}
