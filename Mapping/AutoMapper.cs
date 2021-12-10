
using ApiProductManagment.Dtos;
using ApiProductManagment.Dtos.EditingDtos;
using ApiProductManagment.ModelsUpdate;
using AutoMapper;

namespace ApiProductManagment.Mapping
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Users, RegisterUserDto>().ReverseMap();

            CreateMap<CupBoard, CupboardDto>().ReverseMap();
            CreateMap<CreateCupBoardDto, CupBoard>().ReverseMap();

            CreateMap<CupBoardDetail, CupboardDetailPutDto>().ReverseMap();
            CreateMap<CupboardDetailDto, CupBoardDetail>().ReverseMap();

            CreateMap<UserXcupBoard, UserXCupboardDto>().ReverseMap();
            CreateMap<UserXshoppingList, UserXshoppingListDto>().ReverseMap();

            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, PostProductDto>().ReverseMap();
            CreateMap<Product, PutProductDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, EditingCategoryDto>().ReverseMap();
            CreateMap<CategoriesXproduct, CategoriesXproductsDto>().ReverseMap();
            
            CreateMap<Trademark, TrademarkDto>().ReverseMap();
            CreateMap<Trademark, EditingTrademarkDto>().ReverseMap();

            CreateMap<ShoppingList, ShoppingListDto>().ReverseMap();
            CreateMap<ShoppingList, EditingShoppingListDto>().ReverseMap();
        }
    }
}
