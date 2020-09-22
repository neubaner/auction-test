using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using totvs_test.Dtos;

namespace totvs_test.Services
{
    public class UserService : IUserService
    {
        public TotvsDbContext _dbContext;

        public UserService(TotvsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private string EncryptPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);

        private bool DoesPasswordMatch(string encryptedPassword, string plainPassword) =>
            BCrypt.Net.BCrypt.Verify(plainPassword, encryptedPassword);

        public async Task<User> Create(CreateUserDto userDto)
        {
            var user = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Password = EncryptPassword(userDto.Password),
                Enabled = true,
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<User> FindUserByEmailAndPassword(string email, string password)
        {
            var user = await _dbContext.Users
                .AsQueryable()
                .Where(x => x.Email == email)
                .SingleOrDefaultAsync();

            if (user == null || !DoesPasswordMatch(user.Password, password))
            {
                return null;
            }

            return user;
        }

        public async Task<User> FindById(Guid id)
        {
            return await _dbContext.Users.FindAsync(id);
        }
    }
}