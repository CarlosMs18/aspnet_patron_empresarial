using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Application.DTO;
using Application.Interface;
using Domain.Entity;
using Domain.Interface;
using Transversal.Common;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace Application.Main
{
    public class CustomersApplication : ICustomersApplication
    {
        private readonly ICustomersDomain _customersDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<CustomersApplication> _logger;

        public CustomersApplication(
            ICustomersDomain customersDomain, 
            IMapper mapper,
            IAppLogger<CustomersApplication> logger
            
            )
        {
            _customersDomain = customersDomain;
            _mapper = mapper;
            _logger = logger;

        }

        #region metodos Sincronos
        public Response<bool> Insert(CustomersDTO customersDTO)
        {
            var response = new Response<bool>();
            try 
            { 
                var customer = _mapper.Map<Customers>(customersDTO);
                response.Data = _customersDomain.Insert(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!!!";
                }

            }catch (Exception e)
            {
                response.Message = e.Message;
                
            }
            return response;
        }

        public Response<bool> Update(CustomersDTO customersDTO)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customersDTO);
                response.Data = _customersDomain.Update(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualizacion Exitoso!!!";
                }

            }
            catch (Exception e)
            {
                response.Message = e.Message;
                
            }
            return response;
        }


        public Response<bool> Delete(string CustomerId)
        {
            var response = new Response<bool>();
            try
            {
                
                response.Data = _customersDomain.Delete(CustomerId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminacion Exitoso!!!";
                }

            }
            catch (Exception e)
            {
                response.Message = e.Message;
                
            }
            return response;
        }

        public Response<CustomersDTO> Get(string CustomerId)
        {
            var response = new Response<CustomersDTO>();    
            try
            {
                var customer = _customersDomain.Get(CustomerId);
                
                response.Data = _mapper.Map<CustomersDTO>(customer);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitoso!!!";
                }

            }
            catch (Exception e)
            {
                response.Message = e.Message;
               
            }
            return response;
        }

        public Response<IEnumerable<CustomersDTO>> GetAll()
        {
            var response = new Response<IEnumerable<CustomersDTO>>();
            try
            {
                var customers = _customersDomain.GetAll();

                response.Data = _mapper.Map<IEnumerable<CustomersDTO>>(customers);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitoso!!!";
                    _logger.LogInformation("Consulta Exitoso!!!");
                }

            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);

            }
            return response;
        }

        #endregion



        #region metodos Asincronos

        public async Task<Response<bool>> InsertAsync(CustomersDTO customersDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customersDto);
                response.Data = await _customersDomain.InsertAsync(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!!!";
                }

            }
            catch (Exception e)
            {
                response.Message = e.Message;

            }
            return response;
        }

        public async Task<Response<bool>> UpdateAsync(CustomersDTO customersDTO)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customersDTO);
                response.Data = await _customersDomain.UpdateAsync(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualizacion Exitoso!!!";
                }

            }
            catch (Exception e)
            {
                response.Message = e.Message;

            }
            return response;
        }


        public async Task<Response<bool>> DeleteAsync(string CustomerId)
        {
            var response = new Response<bool>();
            try
            {

                response.Data = await _customersDomain.DeleteAsync(CustomerId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminacion Exitoso!!!";
                }

            }
            catch (Exception e)
            {
                response.Message = e.Message;

            }
            return response;
        }

        public async Task<Response<CustomersDTO>> GetAsync(string CustomerId)
        {
            var response = new Response<CustomersDTO>();
            try
            {
                var customer = await _customersDomain.GetAsync(CustomerId);

                response.Data = _mapper.Map<CustomersDTO>(customer);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitoso!!!";
                }

            }
            catch (Exception e)
            {
                response.Message = e.Message;

            }
            return response;
        }

        public async Task<Response<IEnumerable<CustomersDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CustomersDTO>>();
            try
            {
                var customers = await _customersDomain.GetAllAsync();

                response.Data = _mapper.Map<IEnumerable<CustomersDTO>>(customers);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitoso!!!";
                }

            }
            catch (Exception e)
            {
                response.Message = e.Message;

            }
            return response;
        }

        #endregion
    }


}
