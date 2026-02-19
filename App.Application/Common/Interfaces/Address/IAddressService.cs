using App.Application.Common.DTO.Address;
using App.Application.Common.Responses;

namespace App.Application.Common.Interfaces.Address;

public interface IAddressService
{
    Task<GenericResponse<bool>> CreateAsync(CreateAddressDto dto);
    Task<GenericResponse<bool>> RemoveAsync(int id);
    Task<GenericResponse<bool>> UpdateAsync(UpdateAddressDto dto);
    Task<GenericResponse<List<GetAllAddressDto>>> GetAllAsync(Guid clientId);
    Task<GenericResponse<GetByIdAddressDto>> GetByIdAsync(int id);
}
