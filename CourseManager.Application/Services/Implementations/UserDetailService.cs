using CourseManager.Application.DTOs;
using CourseManager.Application.Services.Interfaces;
using CourseManager.Domain.Entities;
using CourseManager.Domain.Interfaces;

namespace CourseManager.Application.Services.Implementations
{
    public class UserDetailService : IUserDetailService
    {
        private readonly IUserDetailRepository _userDetailRepository;

        public UserDetailService(IUserDetailRepository userDetailRepository)
        {
            _userDetailRepository = userDetailRepository;
        }

        public async Task<IEnumerable<UserDetailResponseDTO>> GetAllAsync()
        {
            var details = await _userDetailRepository.GetAllAsync();
            return details.Select(d => new UserDetailResponseDTO
            {
                Id = d.Id,
                CPF = d.CPF,
                Address = d.Address,
                Phone = d.Phone,
                CreatedAt = d.CreatedAt,
                UpdatedAt = d.UpdatedAt
            });
        }

        public async Task<UserDetailResponseDTO?> GetByIdAsync(int id)
        {
            var d = await _userDetailRepository.GetByIdAsync(id);
            if (d == null) return null;

            return new UserDetailResponseDTO
            {
                Id = d.Id,
                CPF = d.CPF,
                Address = d.Address,
                Phone = d.Phone,
                CreatedAt = d.CreatedAt,
                UpdatedAt = d.UpdatedAt
            };
        }

        public async Task<UserDetailResponseDTO> CreateAsync(CreateUserDetailDTO dto)
        {
            var detail = new UserDetail
            {
                CPF = dto.CPF,
                Address = dto.Address,
                Phone = dto.Phone,
                CreatedAt = DateTime.Now
            };

            await _userDetailRepository.AddAsync(detail);
            await _userDetailRepository.SaveChangesAsync();

            return await GetByIdAsync(detail.Id);
        }

        public async Task<bool> UpdateAsync(int id, UpdateUserDetailDTO dto)
        {
            var detail = await _userDetailRepository.GetByIdAsync(id);
            if (detail == null) return false;

            detail.Address = dto.Address;
            detail.Phone = dto.Phone;
            detail.UpdatedAt = DateTime.Now;

            _userDetailRepository.Update(detail);
            await _userDetailRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var detail = await _userDetailRepository.GetByIdAsync(id);
            if (detail == null) return false;

            _userDetailRepository.Remove(detail);
            await _userDetailRepository.SaveChangesAsync();
            return true;
        }
    }
}
