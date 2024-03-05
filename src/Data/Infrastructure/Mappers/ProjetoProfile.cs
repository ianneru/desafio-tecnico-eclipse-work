using Application.Dtos;
using AutoMapper;


namespace CF.Customer.Infrastructure.Mappers;

public class ProjetoProfile : Profile
{
    public ProjetoProfile()
    {
        CreateCustomerProfile();
    }

    private void CreateCustomerProfile()
    {
        CreateMap<ProjetoRequestDto, Domain.Entities.Projeto>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Created, opt => opt.Ignore())
            .ForMember(dest => dest.Updated, opt => opt.Ignore());
    }
}