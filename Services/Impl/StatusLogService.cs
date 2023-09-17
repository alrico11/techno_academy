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

        public StatusLog? DeleteById(string uuid)
        {
            var data = _context.Log_status.Find(uuid);
            if (data == null) { return null; }
            data.Flag_Active = false;
            _context.SaveChanges();
            return data;
        }

        public List<StatusLog> GetAll()
        {
            var data = _context.Log_status.Where(x => x.Flag_Active == true).ToList();
            return data;
        }

        public StatusLog? GetByUUID(string uuid)
        {
            var data = _context.Log_status.Find(uuid);
            return data == null ? null : data;
        }
        public List<StatusLog>? GetStatusUserByEmail(string email)
        {
            var dataUser = _context.Mst_user.FirstOrDefault(x => x.Email == email);
            var dataTrnApplied = _context.Trn_applied_program.FirstOrDefault(x => x.IdRegister == dataUser.UUID);
            var dataStatusLog = _context.Log_status.Where(x => x.IdAppliedProgram == dataTrnApplied.UUID).OrderBy(x => x.Sequence).ToList();
            return dataStatusLog;
        }
    }
}