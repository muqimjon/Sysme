using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sysme.Data.IRepositories;
using Sysme.Domain.Entities.Hospitals;
using Sysme.Service.DTOs.Attachments;
using Sysme.Service.DTOs.Hospitals;
using Sysme.Service.Exceptions;
using Sysme.Service.Interfaces;

namespace Sysme.Service.Services;

public class HospitalService : IHospitalService
{
    private readonly IRepository<Hospital> repository;
    private readonly IAttachmentService attachmentService;
    private readonly IMapper mapper;
    public HospitalService(IRepository<Hospital> repository, IMapper mapper, IAttachmentService attachmentService)
    {
        this.mapper = mapper;
        this.repository = repository;
        this.attachmentService = attachmentService;
    }
    public async Task<HospitalResultDto> AddAsync(HospitalCreationDto dto)
    {
        var existHospital = await repository.GetAsync(h => h.Name == dto.Name);
        if (existHospital is not null)
            throw new AlreadyExistException("This hospital already exist");

        var mappedHospital = mapper.Map<Hospital>(dto);
        await repository.CreateAsync(mappedHospital);
        await repository.SaveChanges();

        return mapper.Map<HospitalResultDto>(mappedHospital);
    }

    public async Task<bool> RemoveByIdAsync(long id)
    {
        var existHospital = await repository.GetAsync(h => h.Id.Equals(id))
            ?? throw new NotFoundException("This hospital not found");

        repository.Delete(existHospital);
        await repository.SaveChanges();

        return true;
    }

    public async Task<IEnumerable<HospitalResultDto>> RetrieveAllAsync()
    {
        var allHospitals = await repository.GetAll().ToListAsync();
        return mapper.Map<IEnumerable<HospitalResultDto>>(allHospitals);
    }

    public async Task<HospitalResultDto> RetrieveByIdAsync(long id)
    {
        var existHospital = await repository.GetAsync(h => h.Id.Equals(id))
            ?? throw new NotFoundException("This hospital not found");

        return mapper.Map<HospitalResultDto>(existHospital);
    }

    public async Task<HospitalResultDto> ModifyAsync(HospitalUpdateDto dto)
    {
        var existHospital = await repository.GetAsync(h => h.Id.Equals(dto.Id))
            ?? throw new NotFoundException("This hospital not found");

        mapper.Map(dto, existHospital);
        repository.Update(existHospital);
        await repository.SaveChanges();

        return mapper.Map<HospitalResultDto>(existHospital);
    }

    public async Task<HospitalResultDto> UploadImageAsync(long HospitalId, AttachmentCreationDto dto)
    {
        var existHospital = await repository.GetAsync(u => u.Id.Equals(HospitalId))
               ?? throw new NotFoundException("This Hospital is not found");

        var createdAttachment = await attachmentService.UploadAsync(dto);
        existHospital.Attachment = createdAttachment;
        await repository.SaveChanges();

        return mapper.Map<HospitalResultDto>(existHospital);
    }
    public async Task<HospitalResultDto> ModifyImageAsync(long HospitalId, AttachmentCreationDto dto)
    {
        var existHospital = await repository.GetAsync(u => u.Id.Equals(HospitalId), includes: new[] { "Attachment" })
              ?? throw new NotFoundException("This Hospital is not found");

        await attachmentService.RemoveAsync(existHospital.Attachment);
        var createdAttachment = await attachmentService.UploadAsync(dto);
        existHospital.Attachment = createdAttachment;
        repository.Update(existHospital);
        await repository.SaveChanges();

        return mapper.Map<HospitalResultDto>(existHospital);
    }
}