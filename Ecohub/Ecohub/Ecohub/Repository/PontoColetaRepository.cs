﻿using Ecohub.Infra.Context;
using Ecohub.Repository.Interfaces;

namespace Ecohub.Repository
{
    public class PontoColetaRepository : IPontoColetaRepository
    {
        private readonly AppDbContext _context = new AppDbContext();

    }
}
