using App.Application.Common.DTO.Service;
using App.Application.Common.DTO.Statuses;
using App.Application.Common.Interfaces;
using App.Application.Common.Responses;
using App.Application.Services.Query.GetAll;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Statuses.Query
{
    public class GetAllStatusQueryHandler : IRequestHandler<GetAllStatusQuery, GenericResponse<List<GetAllStatusDto>>>
    {
        private readonly IGenericRepository<Domain.Entities.List.Statuses> _genericRepository;
        public GetAllStatusQueryHandler(IGenericRepository<Domain.Entities.List.Statuses> genericRepository) => _genericRepository = genericRepository;

        public async Task<GenericResponse<List<GetAllStatusDto>>> Handle(GetAllStatusQuery request, CancellationToken cancellationToken)
        {
            var data = await _genericRepository.GetAllAsync();

            var dto = data.Select(item => new GetAllStatusDto
            {
                Id = item.Id,
                Name = item.Name,
            }).ToList();

            return GenericResponse<List<GetAllStatusDto>>.Ok(dto);
        }
    }
}
