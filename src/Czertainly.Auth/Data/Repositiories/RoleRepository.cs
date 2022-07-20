﻿using Czertainly.Auth.Common.Data.Repositories;
using Czertainly.Auth.Data.Contracts;
using Czertainly.Auth.Models.Entities;

namespace Czertainly.Auth.Data.Repositiories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(AuthDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
