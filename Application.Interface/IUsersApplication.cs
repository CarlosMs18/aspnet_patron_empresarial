using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.DTO;
using Transversal.Common;

namespace Application.Interface
{
    public interface  IUsersApplication
    {
        Response<UsersDto> Authenticate(string username, string password);      
    }
}
