using Microsoft.EntityFrameworkCore;
using API.DAL.Interfaces;
using API.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace API.DAL.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private readonly ApplicationDbContext db;

        public ActorRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> CreateAsync(Actor entity)
        {
            await db.Actors.AddAsync(entity);
            await db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(Actor entity)
        {
            db.Actors.Remove(entity);
            await db.SaveChangesAsync();

            return true;
        }

        public async Task<Actor> GetAsync(int id)
        {
            return await db.Actors.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Actor>> GetAsync(string substr, int limit, int page, int[] bannedId)
        {
            return await db.Actors.
                Where(actor => bannedId.Contains(actor.Id) == false && (actor.Name + ' ' + actor.Surname).ToLower()
                .Contains(substr.ToLower()))
                .Skip(limit * (page - 1))
                .Take(limit)
                .ToListAsync();
        }

        public async Task<List<Actor>> SelectAsync()
        {
            return await db.Actors.ToListAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await db.Actors.CountAsync();
        }

        public async Task<Actor> GetLastAsync()
        {
            var count = await GetCountAsync();
            return db.Actors.Skip(count - 1).First();
        }


        public async Task<Actor> UpdateAsync(Actor entity)
        {
            db.Actors.Update(entity);
            await db.SaveChangesAsync();

            return entity;
        }
    }
}
