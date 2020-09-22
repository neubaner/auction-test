using System;
using System.Threading.Tasks;
using totvs_test.Dtos;

namespace totvs_test.Services
{
    public interface IUserService
    {
        public Task<User> Create(CreateUserDto userDto);

        public Task<User> FindById(Guid id);

        public Task<User> FindUserByEmailAndPassword(string email, string password);
    }
}