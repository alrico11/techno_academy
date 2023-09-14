using AutoWrapper.Extensions;
using Microsoft.AspNetCore.Mvc;
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

        public AppliedProgram? Create(AppliedDto appliedProgram)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                if (appliedProgram.IdProgramEntity != null && appliedProgram.IdProgramEntity.Length >= 1)
                {
                    List<AppliedProgram> listAppliedProgram = new List<AppliedProgram>();
                    List<StatusLog> listStatusLog = new List<StatusLog>();

                    var lastStatus = _context.Mst_GCM_Academy
                                          .Where(x => x.Condition == "Mst_Status" && x.CharValue1 == "001")
                                          .Select(x => x.CharDesc1)
                                          .FirstOrDefault();
                    var stepStatus = _context.Mst_GCM_Academy
                                          .Where(x => x.Condition == "Mst_Step_status" && x.CharValue1 == "001")
                                          .Select(x => x.CharDesc1)
                                          .FirstOrDefault();
                    foreach (var id in appliedProgram.IdProgramEntity)
                    {
                        var newUUID = Guid.NewGuid().ToString();
                        var newAppliedProgram = new AppliedProgram
                        {
                            UUID = newUUID,
                            Last_Status = lastStatus,
                            IdProgramEntity = id,
                            IdRegister = appliedProgram.IdRegister
                            
                        };
                        var newStatusLog = new StatusLog
                        {
                            Status = lastStatus,
                            Sequence = 1,
                            IdAppliedProgram = newUUID,
                            Notes = "Lolos dokumen",
                            StepStatus = stepStatus
                        };

                        listAppliedProgram.Add(newAppliedProgram);
                        listStatusLog.Add(newStatusLog);
                    }
                    _context.Trn_applied_program.AddRange(listAppliedProgram);
                    _context.Log_status.AddRange(listStatusLog);
                    _context.SaveChanges();
                    transaction.Commit();
                }
                return null;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Something went wrong", ex);
            }
        }

        public AppliedProgram Delete(string uuid)
        {
            var data = _context.Trn_applied_program.Find(uuid);
            if (data == null) { return null; }
            _context.Trn_applied_program.Remove(data);
            _context.SaveChanges();
            return data;
        }

        public List<AppliedProgram> GetAll()
        {
            var data = _context.Trn_applied_program
                        .Where(x => x.Flag_Active == true)
                        .ToList();
            return data;
        }

        public AppliedProgram? GetByUUID(string uuid)
        {
            var data = _context.Trn_applied_program.Find(uuid);
            return data == null ? null : data;
        }

        public AppliedProgram? Update(string uuid, AppliedProgram appliedProgram)
        {
            var data = _context.Trn_applied_program.Find(uuid);
            if (data == null) { return null; }
            data.Flag_Active = appliedProgram.Flag_Active;
            data.Last_Status = appliedProgram.Last_Status;
            data.ProgramEntity = appliedProgram.ProgramEntity;
            _context.SaveChanges();
            return data;
        }

        public AppliedProgram? UpdateStatus(string uuid, UpdateStatusReq updateStatusReq)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var data = _context.Trn_applied_program.Find(uuid);
                if (data == null) { return null; }

                var dataStatusLog = _context.Log_status.Where(x => x.IdAppliedProgram == data.UUID).OrderByDescending(x => x.Sequence).Select(x => x.Sequence).FirstOrDefault();
                var currentStatus = data.Last_Status;
                var lastStatusArr = _context.Mst_GCM_Academy
                                    .Where(x => x.Condition == "Mst_Status")
                                    .OrderBy(x => x.CharValue1)
                                    .Select(x => x.CharDesc1)
                                    .ToList();
                var stepStatusArr = _context.Mst_GCM_Academy
                                    .Where(x => x.Condition == "Mst_Step_status")
                                    .OrderBy(x => x.CharValue1)
                                    .Select(x => x.CharDesc1)
                                    .ToList();
                switch (currentStatus)
                {
                    case "Dokumen diterima":
                        FuncUpdateStatus(data, lastStatusArr[1], updateStatusReq.Notes, Convert.ToInt32(dataStatusLog), stepStatusArr[0]);
                        data.Last_Status = lastStatusArr[1];
                        break;
                    case "Screening":
                        FuncUpdateStatus(data, lastStatusArr[2], updateStatusReq.Notes, Convert.ToInt32(dataStatusLog), stepStatusArr[0]);
                        data.Last_Status = lastStatusArr[2];
                        break;
                    case "Online Test":
                        FuncUpdateStatus(data, lastStatusArr[3], updateStatusReq.Notes, Convert.ToInt32(dataStatusLog), stepStatusArr[0]);
                        data.Last_Status = lastStatusArr[3];
                        break;
                    case "Logical Test":
                        FuncUpdateStatus(data, lastStatusArr[4], updateStatusReq.Notes, Convert.ToInt32(dataStatusLog), stepStatusArr[0]);
                        data.Last_Status = lastStatusArr[4];
                        break;
                    case "Wawancara User 1":
                        FuncUpdateStatus(data, lastStatusArr[5], updateStatusReq.Notes, Convert.ToInt32(dataStatusLog), stepStatusArr[0]);
                        data.Last_Status = lastStatusArr[5];
                        break;
                    case "Wawancara User 2":
                        FuncUpdateStatus(data, lastStatusArr[6], updateStatusReq.Notes, Convert.ToInt32(dataStatusLog), stepStatusArr[0]);
                        data.Last_Status = lastStatusArr[6];
                        break;
                    case "Wawancara HC":
                        FuncUpdateStatus(data, lastStatusArr[6], updateStatusReq.Notes, Convert.ToInt32(dataStatusLog), stepStatusArr[2]);
                        break;
                    default:
                        break;
                }
                _context.SaveChanges();
                transaction.Commit();
                return data;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        private void FuncUpdateStatus(AppliedProgram data, string newStatus, string newNotes, int dataStatusLog, string stepStatus)
        {
            var newStatusLog = new StatusLog
            {
                Status = newStatus,
                Sequence = dataStatusLog + 1,
                IdAppliedProgram = data.UUID,
                Notes = newNotes,
                StepStatus = stepStatus
            };
            _context.Log_status.Add(newStatusLog);
        }
    }
}
