using Application.Dtos;
using AutoMapper;


namespace CF.Customer.Infrastructure.Mappers;

public class TarefaProfile : Profile
{
    public TarefaProfile()
    {
        CreateProfile();
    }

    private void CreateProfile()
    {
        CreateMap<TarefaRequestDto, Domain.Entities.Tarefa>()
            .ForMember(dest => dest.Created, opt => opt.Ignore())
            .ForMember(dest => dest.Updated, opt => opt.Ignore());

        CreateMap<Domain.Entities.Tarefa, TarefaResponseDto>();
    }
}