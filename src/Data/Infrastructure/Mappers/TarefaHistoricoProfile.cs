using Application.Dtos;
using AutoMapper;
using Domain.Entities;


namespace CF.Customer.Infrastructure.Mappers;

public class TarefaHistoricoProfile : Profile
{
    public TarefaHistoricoProfile()
    {
        CreateProfile();
    }

    private void CreateProfile()
    {
        CreateMap<Domain.Entities.TarefaHistorico, TarefaHistoricoResponseDto>();
    }
}