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
    public class WorkingHourRepositoryAsync : GenericRepositoryAsync<WorkingHour>, IWorkingHourRepositoryAsync
    {
        private readonly DbSet<WorkingHour> _workingHours; 

        public WorkingHourRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _workingHours = dbContext.Set<WorkingHour>();
        }

        //public Task<bool> IsUniqueBarcodeAsync(string barcode)
        //{
        //    return _departmentTypes
        //        .AllAsync(p => p.Barcode != barcode);
        //}
    }
}
