using MedicoAPI.Services.DTOs;

namespace MedicoAPI.Services;

public interface IPractitionerService
{
    List<PractitionerResponseDto> GetPractitioners();
    PractitionerResponseDto GetPractitionerById(int id);
    PractitionerResponseDto CreatePractitioner(PractitionerCreateDto practitionerCreateDto);
    PractitionerResponseDto UpdatePractitioner(PractitionerUpdateDto practitionerUpdateDto);
    void DeletePractitioner(int id);
}