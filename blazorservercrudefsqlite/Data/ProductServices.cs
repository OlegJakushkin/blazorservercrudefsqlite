using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace blazorservercrudefsqlite.Data
{
    public class ProductServices
    {
        private readonly ProductDbContext dbContext;

        public ProductServices(ProductDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //------------ Orgs ------------

        public async Task<List<Org>> GetOrgsAsync()
        {
            return await dbContext.Orgs.ToListAsync();
        }

        public async Task<Org> AddOrgAsync(Org org)
        {
            dbContext.Orgs.Add(org);
            await dbContext.SaveChangesAsync();
            return org;
        }

        public async Task<Org> UpdateOrgAsync(Org org)
        {
            var productExist = dbContext.Orgs.FirstOrDefault(p => p.Id == org.Id);
            if (productExist != null)
            {
                dbContext.Update(org);
                await dbContext.SaveChangesAsync();
            }

            return org;
        }

        public async Task DeleteOrgAsync(Org org)
        {
            dbContext.Orgs.Remove(org);
            await dbContext.SaveChangesAsync();
        }

        //------------ Users ------------
        public async Task<List<User>> GetUsersAsync()
        {
            return await dbContext.Users.ToListAsync();
        }

        public async Task<User> AddUserAsync(User org)
        {
            dbContext.Users.Add(org);
            await dbContext.SaveChangesAsync();
            return org;
        }

        public async Task<User> UpdateUserAsync(User org)
        {
            var productExist = dbContext.Users.FirstOrDefault(p => p.Id == org.Id);
            if (productExist != null)
            {
                dbContext.Update(org);
                await dbContext.SaveChangesAsync();
            }

            return org;
        }


        public async Task<User> UpdateUserOrgAsync(User usr, Org org)
        {
            var userExist = dbContext
                .Users
                .FirstOrDefault(p => p.Id == usr.Id);

            var orgExist = dbContext
                .Orgs
                .FirstOrDefault(p => p.Id == usr.Id);

            if (userExist != null && orgExist != null)
            {
                var rel = new Relation()
                {
                    UserId = usr.Id,
                    OrgId = org.Id,
                    Org = org,
                    User = usr

                };
                dbContext.Relations.Add(rel);
                await dbContext.SaveChangesAsync();
            }

            return usr;
        }

        public async Task DeleteUserAsync(User org)
        {
            dbContext.Users.Remove(org);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Relation>> GetRelationsAsync()
        {
            return await dbContext.Relations.ToListAsync();
        }
    }
}