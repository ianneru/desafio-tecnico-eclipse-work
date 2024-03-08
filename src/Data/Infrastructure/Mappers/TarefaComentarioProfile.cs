using Application.Dtos;
using AutoMapper;


namespace CF.Customer.Infrastructure.Mappers;

public class TarefaComentarioProfile : Profile
{
    public TarefaComentarioProfile()
    {
        CreateProfile();
    }

    private void CreateProfile()
    {
        CreateMap<TarefaComentarioRequestDto, Domain.Entities.TarefaComentario>()
            .ForMember(dest => dest.Created, opt => opt.Ignore())
            .ForMember(dest => dest.Updated, opt => opt.Ignore());

        CreateMap<Domain.Entities.TarefaComentario, TarefaComentarioResponseDto>();
    }
}