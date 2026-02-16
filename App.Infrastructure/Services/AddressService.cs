using App.Application.Common.DTO.Address;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Address;
using App.Application.Common.Responses;
using App.Domain.Entities.List;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Services;

public class AddressService : IAddressService
{
    private readonly IGenericRepository<Addresses> _addressRepository;
    public AddressService(IGenericRepository<Addresses> addressRepository) => _addressRepository = addressRepository;

    public async Task<GenericResponse<bool>> CreateAsync(CreateAddressDto dto)
    {
        var data = new Addresses()
        {
            Address = dto.Address,
            ClientId = dto.ClientId,
            Name = dto.Name,
            X = dto.X,
            Y = dto.Y
        };

        await _addressRepository.InsertAsync(data);
        return GenericResponse<bool>.Ok(true);
    }

    public async Task<GenericResponse<List<GetAllAddressDto>>> GetAllAsync(Guid clientId)
    {
        var data = await _addressRepository.Where(x => x.ClientId == clientId).Select(item => new GetAllAddressDto
        {
            Id = item.Id,
            Name = item.Name,
        }).ToListAsync();

        return GenericResponse<List<GetAllAddressDto>>.Ok(data);
    }

    public async Task<GenericResponse<GetByIdAddressDto>> GetByIdAsync(int id)
    {
        var data = await _addressRepository.GetByIdAsync(id);
        if (data == null)
            return GenericResponse<GetByIdAddressDto>.Ok(null);

        var dto = new GetByIdAddressDto()
        {
            Address = data.Address,
            ClientId = data.ClientId,
            Id = data.Id,
            Name = data.Name,
            X = data.X,
            Y = data.Y
        };

        return GenericResponse<GetByIdAddressDto>.Ok(dto);
    }

    public async Task<GenericResponse<bool>> RemoveAsync(int id)
    {
        var data = await _addressRepository.GetByIdAsync(id);
        if (data == null)
            return GenericResponse<bool>.Ok(false);

        _addressRepository.Delete(data);

        return GenericResponse<bool>.Ok(true);
    }

    public async Task<GenericResponse<bool>> UpdateAsync(int id, UpdateAddressDto dto)
    {
        var data = await _addressRepository.GetByIdAsync(id);
        if (data == null)
            return GenericResponse<bool>.Ok(false);

        data.Address = dto.Address;
        data.X = dto.X;
        data.Y = dto.Y;
        data.Name = dto.Name;

        return GenericResponse<bool>.Ok(true);
    }
}
