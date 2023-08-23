using System;
using System.Collections.Generic;
using System.Linq;
using TechnoAcademyApi.Data;
using TechnoAcademyApi.Models;

namespace TechnoAcademyApi.Services
{
    public class FormRegisterService : IFormRegisterService
    {
        private readonly ApplicationDbContext _context;

        public FormRegisterService(ApplicationDbContext context)
        {
            _context = context;
        }

        public ResBase<FormRegister> CreateFormRegister(FormRegister formRegister)
        {
            try
            {
                formRegister.UUID = Guid.NewGuid().ToString(); // Generate UUID for the form register
                _context.FormRegisters.Add(formRegister);
                _context.SaveChanges();

                return new ResBase<FormRegister>
                {
                    Success = true,
                    Message = "Form register created successfully",
                    Data = formRegister
                };
            }
            catch (Exception ex)
            {
                return new ResBase<FormRegister>
                {
                    Success = false,
                    Message = $"Failed to create form register: {ex.Message}",
                    Data = null
                };
            }
        }

        // Implement other CRUD operations (Read, Update, Delete) as needed
    }
}
