using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.DTO;
using Transversal.Common;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface ICustomersApplication
    {
        #region metodos Sincronos
        Response<bool> Insert(CustomersDTO customersDTO);

        Response<bool> Update(CustomersDTO customersDTO);


        Response<bool>  Delete(string CustomerId);

        Response<CustomersDTO> Get(string CustomerId);

        Response<IEnumerable<CustomersDTO>> GetAll();

        #endregion



        #region metodos Asincronos

        Task<Response<bool>> InsertAsync(CustomersDTO customer);

        Task<Response<bool>> UpdateAsync(CustomersDTO customer);


        Task<Response<bool>> DeleteAsync(string CustomerId);

        Task<Response<CustomersDTO>> GetAsync(string CustomerId);

        Task<Response<IEnumerable<CustomersDTO>>> GetAllAsync();

        #endregion
    }
}
