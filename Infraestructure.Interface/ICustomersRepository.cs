using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entity;

namespace Infraestructure.Interface
{
    public interface ICustomersRepository
    {
        #region metodos Sincronos
        bool Insert(Customers customer);

        bool Update(Customers customer);


        bool Delete(string CustomerId);

        Customers Get(string CustomerId);   

        IEnumerable<Customers> GetAll();

        #endregion



        #region metodos Asincronos

        Task<bool> InsertAsync(Customers customer);

        Task<bool> UpdateAsync(Customers customer);


        Task<bool> DeleteAsync(string CustomerId);

        Task<Customers> GetAsync(string CustomerId);

        Task<IEnumerable<Customers>> GetAllAsync();

        #endregion

    }
}
