using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entity;
using Domain.Interface;
using Infraestructure.Interface;

namespace Domain.Core
{
    public class UsersDomain : IUsersDomain
    {

        private readonly IUsersRepository _usersRepository;

        public UsersDomain(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository; 
        }
        public Users Authenticate(string username, string password)
        {
            return _usersRepository.Authenticate(username, password);   
        }
    }
}
