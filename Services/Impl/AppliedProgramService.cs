using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Text.Json;
using TechnoAcademyApi.Data;
using TechnoAcademyApi.Models;
using TechnoAcademyApi.Models.Dto.Req;
using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services.Impl
{
    public class AppliedProgramService : IAppliedProgramService
    {
        private readonly ApplicationDbContext _context;
        public AppliedProgramService(ApplicationDbContext context)
        {
            _context = context;
        }
        public ResBase<AppliedProgram> Create(AppliedDto appliedProgramDto)
        {
            try
            {
                if (appliedProgramDto.IdProgramEntity != null && appliedProgramDto.IdProgramEntity.Length >= 0)
                {
                    foreach (var id in appliedProgramDto.IdProgramEntity)
                    {
                        var newAppliedProgram = new AppliedProgram
                        {
                            Last_Status = "accepted_files",
                            IdRegister = appliedProgramDto.IdRegister.ToString(),
                            IdProgramEntity = id,
                            FormRegister = appliedProgramDto.FormRegister
                        };
                        var newStatusLog = new StatusLog
                        {
                            Status = new string[] { "accepted_files" },
                            Sequence = new string[] { "1" },
                            Notes = new string[] { "Dokumen Tersimpan" },
                            StepStatus = 1,
                            DateHistory = new string[] { DateTime.Now.ToString() },
                            IdAppliedProgram = newAppliedProgram.UUID
                        };
                        _context.StatusLogs.Add(newStatusLog);
                        _context.AppliedPrograms.Add(newAppliedProgram);
                    }
                    _context.SaveChanges();
                    return new ResBase<AppliedProgram>()
                    {
                        Message = "Success created AppliedPrograms & StatusLogs"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResBase<AppliedProgram>
                {
                    Success = false,
                    Code = 500,
                    Message = ex.Message,
                    Data = null
                };
            }
            return null;
        }
        public ResBase<AppliedProgram> Delete(string uuid)
        {
            var data = _context.AppliedPrograms.FirstOrDefault(x => x.UUID == uuid);
            if (data != null)
            {
                _context.AppliedPrograms.Remove(data);
                _context.SaveChanges();
                return new ResBase<AppliedProgram> { Message = "Deleted applied program", Data = data };
            }
            else
            {
                return new ResBase<AppliedProgram>
                {
                    Success = false,
                    Message = "Not found",
                    Code = 400,
                    Data = null
                };

            }
        }

        public ResBase<List<AppliedProgram>> GetAll()
        {
            var data = _context.AppliedPrograms
                .Include(p => p.FormRegister)
                .Include(p => p.ProgramEntity)
                .ToList();
            return new ResBase<List<AppliedProgram>>
            {
                Data = data,
            };
        }

        public ResBase<AppliedProgram> GetByUUID(string uuid)
        {
            var data = _context.AppliedPrograms
                 .Include(p => p.FormRegister)
                 .Include(p => p.ProgramEntity)
                 .FirstOrDefault(x => x.UUID == uuid);
            if (data != null)
            {
                return new ResBase<AppliedProgram>
                {
                    Data = data
                };
            }
            else
            {
                return new ResBase<AppliedProgram>
                {
                    Success = false,
                    Message = "Not found",
                    Code = 404,
                    Data = null
                };
            }
        }

        public ResBase<AppliedProgram> Update(string uuid, AppliedProgram appliedProgram)
        {
            var data = _context.AppliedPrograms.FirstOrDefault(x => x.UUID == uuid);
            if (data != null)
            {
                data.Last_Status = appliedProgram.Last_Status;
                _context.SaveChanges();
                return new ResBase<AppliedProgram> { Data = data };
            }
            else
            {
                return new ResBase<AppliedProgram>
                {
                    Success = false,
                    Code = 500,
                    Message = "Cant Updated",
                    Data = null
                };
            }
        }
    }
}
