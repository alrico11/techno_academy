using System;
using System.Linq;
using TechnoAcademyApi.Data;
using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services.Impl
{
    public class StatusLogService : IStatusLogService
    {
        private readonly ApplicationDbContext _context;
        public StatusLogService(ApplicationDbContext context)
        {
            _context = context;
        }
        public ResBase<StatusLog> Create(StatusLog statusLog)
        {
            try
            {
                _context.StatusLogs.Add(statusLog);
                _context.SaveChanges();
                return new ResBase<StatusLog>()
                {
                    Data = statusLog
                };
            }
            catch (Exception ex)
            {
                return new ResBase<StatusLog>()
                {
                    Code = 400,
                    Message = ex.Message,
                    Success = false,
                    Data = null
                };
            }
        }
        public ResBase<StatusLog> Delete(string uuid)
        {
            var data = _context.StatusLogs.FirstOrDefault(x => x.UUID == uuid);
            if (data != null)
            {
                _context.StatusLogs.Remove(data);
                _context.SaveChanges();
                return new ResBase<StatusLog>()
                {
                    Data = null,
                };
            }
            else
            {
                return new ResBase<StatusLog>()
                {
                    Success = false,
                    Data = null,
                    Code = 404,
                    Message = "Not found"
                };
            }
        }

        public ResBase<List<StatusLog>> GetAll()
        {
            var data = _context.StatusLogs.ToList();
            return new ResBase<List<StatusLog>>()
            {
                Data = data
            };
        }

        public ResBase<StatusLog> GetByUUID(string uuid)
        {
            var data = _context.StatusLogs.FirstOrDefault(x => x.UUID == uuid);
            if (data != null)
            {
                return new ResBase<StatusLog>()
                {
                    Data = data
                };
            }
            else
            {
                return new ResBase<StatusLog>()
                {
                    Success = false,
                    Data = null,
                    Code = 404,
                    Message = "Not FOund"
                };
            }
        }

        public ResBase<StatusLog> Update(string uuid, StatusLog statusLog)
        {
            var data = _context.StatusLogs.FirstOrDefault(x => x.UUID == uuid);

            if (data != null && data.Status.Length > 0)
            {
                string currentStatus = data.Status[data.Status.Length - 1];
                switch (currentStatus)
                {
                    case "accepted_files":
                        UpdateStatus(data, "screening", "2", statusLog.Notes);
                        break;
                    case "screening":
                        UpdateStatus(data, "online_test", "3", statusLog.Notes);
                        break;
                    case "online_test":
                        UpdateStatus(data, "technicaltest", "3", statusLog.Notes);
                        break;
                    case "technicaltest":
                        UpdateStatus(data, "interview_user1", "4", statusLog.Notes);
                        break;
                    case "interview_user1":
                        UpdateStatus(data, "interview_user2", "5", statusLog.Notes);
                        break;
                    case "interview_user2":
                        UpdateStatus(data, "interview_hc", "6", statusLog.Notes);
                        break;
                    case "interview_hc":
                        UpdateStatus(data, "final", "7", statusLog.Notes);
                        break;
                    default:
                        // Handle unsupported status
                        break;
                }
                _context.SaveChanges();

                return new ResBase<StatusLog>()
                {
                    Message = "Success next step & updated in field Last_Status AppliedProgram"
                };
            }

            return new ResBase<StatusLog>()
            {
                Success = false,
                Code = 404,
                Message = "Not found",
                Data = null
            };
        }
        private void UpdateStatus(StatusLog data, string newStatus, string newSequence, string[] newNotes)
        {
            string[] newStatusArr = new string[data.Status.Length + 1];
            Array.Copy(data.Status, newStatusArr, data.Status.Length);
            newStatusArr[data.Status.Length] = newStatus;
            data.Status = newStatusArr;

            var dataAppliedProgram = data.AppliedProgram;
            var dataApplied = _context.AppliedPrograms.FirstOrDefault(ap => ap.UUID == data.IdAppliedProgram);
            if (dataApplied != null)
            {
                dataApplied.Last_Status = newStatus;
                _context.SaveChanges();
            }

            string[] newDateArr = new string[data.DateHistory.Length + 1];
            Array.Copy(data.DateHistory, newDateArr, data.DateHistory.Length);
            newDateArr[data.DateHistory.Length] = DateTime.Now.ToString();
            data.DateHistory = newDateArr;

            string[] newSequenceArr = new string[data.Sequence.Length + 1];
            Array.Copy(data.Sequence, newSequenceArr, data.Sequence.Length);
            newSequenceArr[data.Sequence.Length] = newSequence;
            data.Sequence = newSequenceArr;

            string[] newNotesArr = new string[data.Notes.Length + newNotes.Length];
            Array.Copy(data.Notes, newNotesArr, data.Notes.Length);
            Array.Copy(newNotes, 0, newNotesArr, data.Notes.Length, newNotes.Length);
            data.Notes = newNotesArr;

            data.StepStatus = int.Parse(newSequence);
        }
        public ResBase<StatusLog> UpdatedReject(string uuid, StatusLog statusLog)
        {
            var data = _context.StatusLogs.FirstOrDefault(x => x.UUID == uuid);
            if (data != null)
            {
                string[] newStatusArr = new string[data.Status.Length + 1];
                Array.Copy(data.Status, newStatusArr, data.Status.Length);
                newStatusArr[data.Status.Length] = "rejected";
                data.Status = newStatusArr;

                string[] newDateArr = new string[data.DateHistory.Length + 1];
                Array.Copy(data.DateHistory, newDateArr, data.DateHistory.Length);
                newDateArr[data.DateHistory.Length] = DateTime.Now.ToString();
                data.DateHistory = newDateArr;

                string[] newSequenceArr = new string[data.Sequence.Length + 1];
                Array.Copy(data.Sequence, newSequenceArr, data.Sequence.Length);
                newSequenceArr[data.Sequence.Length] = "rejected";
                data.Sequence = newSequenceArr;

                string[] newNotesArr = new string[data.Notes.Length + statusLog.Notes.Length];
                Array.Copy(data.Notes, newNotesArr, data.Notes.Length);
                Array.Copy(statusLog.Notes, 0, newNotesArr, data.Notes.Length, statusLog.Notes.Length);
                data.Notes = newNotesArr;

                data.StepStatus *= 0;

                var dataAppliedProgram = data.AppliedProgram;
                var dataApplied = _context.AppliedPrograms.FirstOrDefault(ap => ap.UUID == data.IdAppliedProgram);
                if (dataApplied != null)
                {
                    dataApplied.Last_Status = "rejected";
                    _context.SaveChanges();
                }

                _context.SaveChanges();
                return new ResBase<StatusLog>()
                {
                    Message = "Rejected Applied Program",
                    Data = data,
                };
            }
            else
            {
                return new ResBase<StatusLog>()
                {
                    Message = "Failed to reject applied progam",
                    Code = 500,
                    Data = null,
                    Success = false
                };
            }
        }
    }
}