using MedicoAPI.Models;
using MedicoAPI.Repositories;
using MedicoAPI.Services.DTOs;
using MedicoAPI.Services.Mappers;

namespace MedicoAPI.Services;

public class PractitionerService: IPractitionerService
{
    private IPractitionerRepository _practitionerRepository;
    private PractitionerMapper _practitionerMapper;

    public PractitionerService(IPractitionerRepository practitionerRepository, PractitionerMapper practitionerMapper)
    {
        _practitionerRepository = practitionerRepository;
        _practitionerMapper = practitionerMapper;
    }

    public List<PractitionerResponseDto> GetPractitioners()
    {
        return _practitionerMapper.EntityToResponseDtos(_practitionerRepository.GetPractitioners());
    }

    public PractitionerResponseDto GetPractitionerById(int id)
    {
       Practitioner? practitioner = _practitionerRepository.GetPractitionerById(id);
       if (practitioner == null)
       {
           throw new Exception("Practitioner not found");
       }

       PractitionerResponseDto response = _practitionerMapper.EntityToResponseDto(practitioner);
       return response ?? throw new Exception("Practitioner not found");
    }

    public PractitionerResponseDto CreatePractitioner(PractitionerCreateDto practitionerCreateDto)
    {
        Practitioner practitioner = _practitionerRepository.createPractitioner(_practitionerMapper.EntityToCreateDto(practitionerCreateDto));
        if (practitioner == null)
        {
            throw new Exception("Practitioner not found");
        }
        return _practitionerMapper.EntityToResponseDto(practitioner);
    }

    public PractitionerResponseDto UpdatePractitioner(PractitionerUpdateDto practitionerUpdateDto)
    {
        Practitioner? practitioner = _practitionerRepository.updatePractitioner(_practitionerMapper.EntityToUpdateDto(practitionerUpdateDto));
        if (practitioner == null)
        {
            throw new Exception("Practitioner not found");
        }
        return _practitionerMapper.EntityToResponseDto(practitioner) ?? throw new Exception("Patient not found");
    }

    public void DeletePractitioner(int id)
    {
        _practitionerRepository.DeletePractitioner(id);
    }
}