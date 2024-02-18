using WebApplicationRememberAll.Dtos;
using WebApplicationRememberAll.Repositories;

namespace WebApplicationRememberAll.Services;

public class SlavesService
{
    private SlavesRepository _slavesRepository;

    public SlavesService(SlavesRepository slavesRepository)
    {
        _slavesRepository = slavesRepository;
    }

    public List<SlavesGetAllResponseDto> GetAll()
    {
        return _slavesRepository.GetAll()
            .Select(item => new SlavesGetAllResponseDto()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age
            })
            .ToList();
    }
}