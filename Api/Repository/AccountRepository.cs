using Api.Data;
using Api.Interfaces;
using Api.Model;
using Api.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DataBaseContext _context;

        public AccountRepository(DataBaseContext context){
            _context = context;
        }

        public async Task<List<AccountModel>> GetAll()
        {
            return await _context.Accounts.AsNoTracking().ToListAsync();
        }

        public async Task<AccountModel> GetById(Guid id)
        {
            return await _context.Accounts.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<AccountModel> GetByName(string name)
        {
            return await _context.Accounts.Where(x => x.Name == name).FirstOrDefaultAsync();
        }

        public async Task<AccountModel> Insert(EditAccountViewModel account)
        {
            var data = new AccountModel();
            data.Name = account.Name;
            data.Description = account.Description;
            
            await _context.Accounts.AddAsync(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<AccountModel> Update(Guid id, EditAccountViewModel account)
        {

            var data = await _context.Accounts.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data == null) return null;

            data.Name = account.Name;
            data.Description = account.Description;

            _context.Accounts.Update(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<bool> Delete(Guid id)
        {
            var data = await _context.Accounts.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data == null) return false;

            _context.Accounts.Remove(data);
            await _context.SaveChangesAsync();

            return true;
        }

       
    }
}
