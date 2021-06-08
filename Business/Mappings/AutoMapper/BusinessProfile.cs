using AutoMapper;
namespace Business.Mappings.AutoMapper
{
    public class BusinessProfile:Profile
    {
        public BusinessProfile()
        {
            CreateMap<Entities.Concrete.Product, Entities.DTOs.Response.GetProductQueryResponse>().ReverseMap();
            CreateMap<Entities.Concrete.Product, Entities.DTOs.Request.ProductAddRequest>().ReverseMap();
            CreateMap<Entities.DTOs.Response.GetUserResponse, Core.Entities.Concrete.User>().ReverseMap();
            CreateMap<Entities.Concrete.Cart, Entities.DTOs.Request.AddProductToCartRequest>().ReverseMap();
            CreateMap<Entities.Concrete.Category, Entities.DTOs.Response.GetAllCategoryQueryResponse>().ReverseMap();
            CreateMap<Entities.Concrete.Product, Entities.DTOs.Response.GetBrandsQueryResponse>().ReverseMap();
        }
    }
}
