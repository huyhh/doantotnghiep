using System;

namespace HospitalAppoimentSolution.Services.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        EntitiesDbContext Init();
    }
}
