namespace HonestProduct.Infrastructure.Helpers;

using AutoMapper;
using HonestProduct.Web.Models;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // // CreateRequest -> User
        // CreateMap<CreateRequest, Product>();

        // // UpdateRequest -> User
        // CreateMap<UpdateRequest, Product>()
        //     .ForAllMembers(x => x.Condition(
        //         (src, dest, prop) =>
        //         {
        //             // ignore both null & empty string properties
        //             if (prop == null) return false;
        //             if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

        //             // ignore null role
        //             if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

        //             return true;
        //         }
        //     ));
    }
}