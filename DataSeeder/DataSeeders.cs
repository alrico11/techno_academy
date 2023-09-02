using TechnoAcademyApi.Data;
using TechnoAcademyApi.Models;

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
                    Domicile = "City"
                };
                dbContext.FormRegisters.AddRange(formRegister1);
                dbContext.SaveChanges();
                var programCategory1 = new ProgramCategory
                {
                      Name = "Bootcamp",
                      DateStart = DateTime.Now,
                      DateEnd = DateTime.Now.AddMonths(4),
                      Flag = false
                };

                dbContext.ProgramCategories.AddRange(programCategory1);
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

                dbContext.ProgramEntities.Add(programEntity2);
                dbContext.SaveChanges();
                //var appliedProgram1 = new AppliedProgram
                //{
                //    Last_Status = "Screening",
                //    IdProgramEntity = new string[] { programEntity1.UUID, programEntity2.UUID },
                //    IdRegister = formRegister1.UUID
                //};

                //dbContext.AppliedPrograms.Add(appliedProgram1);
                dbContext.SaveChanges();
            }
        }
    }
}
