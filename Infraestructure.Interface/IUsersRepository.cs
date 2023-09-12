using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Domain.Entity;


namespace Infraestructure.Interface

{
    public interface IUsersRepository
    {
        Users Authenticate(string username, string password);   
    }
}
