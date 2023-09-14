using TechnoAcademyApi.Data;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.DataSeeder
{
    public class DataSeeders
    {
        public static void SeedData(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                // Menambahkan data awal ke model FormRegister
                
                var formRegister1 = new FormRegister
                {
                    Name = "John Doe",
                    Telephone = "1234567890",
                    Email = "john.doe@example.com",
                    University = "Example University",
                    StudyProgram = "Computer Science",
                    StudentStatus = true,
                    Semester = 3,
                    IPK = 3.5f,
                    CV = "path/to/cv.pdf",
                    Domicile = "City",
                    Flag_Active = true,
                };
                dbContext.Mst_user.AddRange(formRegister1);
                dbContext.SaveChanges();
                var programCategory1 = new ProgramCategory
                {
                      Name = "Bootcamp",
                      DateStart = DateTime.Now,
                      DateEnd = DateTime.Now.AddMonths(4),
                      Flag_Active = true
                };

                dbContext.Mst_program.AddRange(programCategory1);
                dbContext.SaveChanges();
                var programEntity1 = new ProgramEntity
                { 
                    Name = "Bootcamp Batch 7",
                    IdCategory = programCategory1.UUID,
                    Flag = false,
                    Desc = "Bootcamp Batch 7 Diselenggarakan 4 Bulan",
                };
                dbContext.SaveChanges();
                var programEntity2 = new ProgramEntity
                {
                    Name = "Bootcamp Batch 8",
                    IdCategory = programCategory1.UUID,
                    Flag = false,
                    Desc = "Bootcamp Batch 8 Diselenggarakan 4 Bulan",
                };

                dbContext.Mst_applied_program.AddRange(programEntity1,programEntity2);
                dbContext.SaveChanges();

                var roles = new RoleEntity
                {
                    RoleName = "admin"
                };
                dbContext.Mst_role.Add(roles);
                dbContext.SaveChanges();

                var mstHeroContent = new GCMEntity
                {
                    Condition = "MST_Hero_Content",
                    CharValue1 = "001",
                    CharValue2 = "001",
                    CharDesc1 = "10",
                    CharDesc2 = "Mentor",
                    Pict = "/public/image/benefit/small_classroom_size.png"
                };
                var mstHeroContent1 = new GCMEntity
                {
                    Condition = "MST_Hero_Content",
                    CharValue1 = "002",
                    CharValue2 = "002",
                    CharDesc1 = "100",
                    CharDesc2 = "Join"
                };
                var mstHeroContent2 = new GCMEntity
                {
                    Condition = "MST_Hero_Content",
                    CharValue1 = "003",
                    CharValue2 = "003",
                    CharDesc1 = "200",
                    CharDesc2 = "Register"
                };
                var mstHeroContent3 = new GCMEntity
                {
                    Condition = "MST_Hero_Content",
                    CharValue1 = "004",
                    CharValue2 = "004",
                    CharDesc1 = "80%",
                    CharDesc2 = "Diterima di Techno Center"
                };

                var mstBenefit = new GCMEntity 
                {
                    Condition = "MST_Benefit",
                    CharValue1 = "001",
                    CharValue2 = "001",
                    CharDesc1 = "Small Classroom Size",
                    CharDesc2 = "Proses pembelajaran semakin intim dengan maksimal 25 students per kelas"
                };

                var realProject = new GCMEntity
                {
                    Condition = "MST_Benefit",
                    CharValue1 = "002",
                    CharValue2 = "002",
                    CharDesc1 = "Real Project",
                    CharDesc2 = "Tidak hanya belajar teori, namun akan mendapatkan real project yang akan dikerjakan"
                };

                var sertifikat = new GCMEntity
                {
                    Condition = "MST_Benefit",
                    CharValue1 = "003",
                    CharValue2 = "003",
                    CharDesc1 = "Sertifikat",
                    CharDesc2 = "Mendapatkan Sertifikat beserta penilaian selama program setelah selesai program"
                };

                var topikSkripsi = new GCMEntity
                {
                    Condition = "MST_Benefit",
                    CharValue1 = "004",
                    CharValue2 = "004",
                    CharDesc1 = "Topik Skripsi",
                    CharDesc2 = "Terdapat sesi diskusi dengan expert tentang technical skill maupun soft skill kamu"
                };

                var berkarirTechnoCenter = new GCMEntity
                {
                    Condition = "MST_Benefit",
                    CharValue1 = "005",
                    CharValue2 = "005",
                    CharDesc1 = "Berkarir di Techno Center",
                    CharDesc2 = "Berkesempatan berkarir di Berijalan Techno Center setelah program Bootcamp selesai"
                };

                var uangSaku = new GCMEntity
                {
                    Condition = "MST_Benefit",
                    CharValue1 = "006",
                    CharValue2 = "006",
                    CharDesc1 = "Uang Saku",
                    CharDesc2 = "Mendapatkan Uang saku tiap bulan"
                };

                var status = new GCMEntity
                {
                    Condition = "MST_Status",
                    CharValue1 = "001",
                    CharDesc1 = "Dokumen diterima"
                };

                var screening = new GCMEntity
                {
                    Condition = "MST_Status",
                    CharValue1 = "002",
                    CharDesc1 = "Screening"
                };

                var onlineTest = new GCMEntity
                {
                    Condition = "MST_Status",
                    CharValue1 = "003",
                    CharDesc1 = "Online Test"
                };

                var logicalTest = new GCMEntity
                {
                    Condition = "MST_Status",
                    CharValue1 = "004",
                    CharDesc1 = "Logical Test"
                };

                var wawancaraUser1 = new GCMEntity
                {
                    Condition = "MST_Status",
                    CharValue1 = "005",
                    CharDesc1 = "Wawancara User 1"
                };

                var wawancaraUser2 = new GCMEntity
                {
                    Condition = "MST_Status",
                    CharValue1 = "006",
                    CharDesc1 = "Wawancara User 2"
                };

                var wawancaraHC = new GCMEntity
                {
                    Condition = "MST_Status",
                    CharValue1 = "007",
                    CharDesc1 = "Wawancara HC"
                };

                var onGoing = new GCMEntity 
                { 
                    Condition = "MST_Step_status",
                    CharValue1 = "001",
                    CharDesc1 = "Ongoing"
                };

                var lolos = new GCMEntity
                {
                    Condition = "MST_Step_status",
                    CharValue1 = "002",
                    CharDesc1 = "Lolos"
                };
                var tidakLolos = new GCMEntity
                {
                    Condition = "MST_Step_status",
                    CharValue1 = "002",
                    CharDesc1 = "Tidak lolos"
                };

                var entitiesToAdd = new List<GCMEntity>
                    {
                        mstHeroContent,
                        mstHeroContent1,
                        mstHeroContent2,
                        mstHeroContent3,
                        mstBenefit,
                        realProject,
                        sertifikat,
                        topikSkripsi,
                        berkarirTechnoCenter,
                        uangSaku,
                        status,
                        screening,
                        onlineTest,
                        logicalTest,
                        wawancaraUser1,
                        wawancaraUser2,
                        wawancaraHC,
                        onGoing,
                        lolos,
                        tidakLolos
                    };
                dbContext.Mst_GCM_Academy.AddRange(entitiesToAdd.ToArray());
                dbContext.SaveChanges();
            }
        }
    }
}
