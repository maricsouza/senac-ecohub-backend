﻿using Ecohub._3___Repository.Interfaces;
using Ecohub.Infra.Context;
using Ecohub.Repository.Entidades;

namespace Ecohub._3___Repository.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly AppDbContext _context = new AppDbContext();

        public async Task<List<MaterialEntidade>> GetAll()
        {
            return _context.Material.ToList();
        }

        public async Task<MaterialEntidade> Get(int materialId)
        {
            var material=  await _context.Material.FindAsync(materialId);
            return material;
        }

        public MaterialEntidade Add(MaterialEntidade material)
        {
            var retorno = _context.Material.Add(material);
            _context.SaveChanges();
            
            return retorno.Entity;
        }
        public void Update(MaterialEntidade material)
        {
            _context.Material.Update(material);
            _context.SaveChanges();
        }

        public async void Delete(MaterialEntidade material)
        {
            _context.Material.Remove(material);
            _context.SaveChanges();
        }
    }
}
