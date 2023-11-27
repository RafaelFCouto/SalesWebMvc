using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWeb.Data;
using SalesWeb.Models;
using Microsoft.EntityFrameworkCore;
using SalesWeb.Services.Exceptions;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace SalesWeb.Services
{
    public class SellerService
    {


        private readonly SalesWebContext _context;

        public SellerService (SalesWebContext context)
        {
            _context = context;
        }


        public async Task<List<Seller>> FindAllAsync()
        {

            return await _context.Seller.ToListAsync();


        }

        public async Task InsertAsync (Seller obj)
        {

            
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }




        
        public async Task<Seller> FindByIdAsync(int id)
        {

            return await _context.Seller.Include(obj => obj.Departament).FirstOrDefaultAsync(obj => obj.Id == id);

        }

        public async Task RemoveAsync (int id)
        {
            try
            {
                var obj = await _context.Seller.FindAsync(id);
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e) {

                throw new IntegrityException(e.Message);
            
            }
            
        }

        public async Task UpdateAsync (Seller obj)
        {


            var hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {

                _context.Update(obj);
                _context.SaveChanges();

            }
            catch(DbConcurrencyException e) //camada de acesso a dados
            {
                throw new DbConcurrencyException(e.Message); //camada de serviço
            }

        }










    }
}
