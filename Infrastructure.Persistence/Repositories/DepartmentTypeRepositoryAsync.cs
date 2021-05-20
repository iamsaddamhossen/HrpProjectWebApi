using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class DepartmentTypeRepositoryAsync : GenericRepositoryAsync<DepartmentType>, IDepartmentTypeRepositoryAsync
    {
        private readonly DbSet<DepartmentType> _departmentTypes;  

        public DepartmentTypeRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _departmentTypes = dbContext.Set<DepartmentType>();
        }

        //public Task<bool> IsUniqueBarcodeAsync(string barcode)
        //{
        //    return _departmentTypes
        //        .AllAsync(p => p.Barcode != barcode);
        //}
    }
}
