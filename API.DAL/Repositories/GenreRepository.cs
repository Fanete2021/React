using Microsoft.EntityFrameworkCore;
using API.DAL.Interfaces;
using API.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace API.DAL.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext db;

        public GenreRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> CreateAsync(Genre entity)
        {
            await db.Genres.AddAsync(entity);
            await db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(Genre entity)
        {
            db.Genres.Remove(entity);
            await db.SaveChangesAsync();

            return true;
        }

        public async Task<Genre> GetAsync(int id)
        {
            return await db.Genres.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Genre>> SelectAsync()
        {
            return await db.Genres.ToListAsync();
        }

        public async Task<List<Genre>> SelectAsync(int limit, int page)
        {
            return await db.Genres.Skip(limit * (page - 1)).Take(limit).ToListAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await db.Genres.CountAsync();
        }

        public async Task<Genre> GetLastAsync()
        {
            var count = await GetCountAsync();
            return db.Genres.Skip(count - 1).First();
        }

        public async Task<Genre> UpdateAsync(Genre entity)
        {
            db.Genres.Update(entity);
            await db.SaveChangesAsync();

            return entity;
        }
    }
}
