﻿using Application.Dtos;
using AutoMapper;


namespace CF.Customer.Infrastructure.Mappers;

public class ProjetoProfile : Profile
{
    public ProjetoProfile()
    {
        CreateProfile();
    }

    private void CreateProfile()
    {
        CreateMap<ProjetoRequestDto, Domain.Entities.Projeto>()
            .ForMember(dest => dest.Created, opt => opt.Ignore())
            .ForMember(dest => dest.Updated, opt => opt.Ignore());

        CreateMap<Domain.Entities.Projeto, ProjetoResponseDto>();
    }
}