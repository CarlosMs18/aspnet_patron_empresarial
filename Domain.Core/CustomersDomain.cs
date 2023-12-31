﻿using Domain.Entity;
using Domain.Interface;
using Infraestructure.Interface;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Domain.Core
{
    public class CustomersDomain : ICustomersDomain 
    {
        private readonly ICustomersRepository _customersRepository;  

        public CustomersDomain(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        #region Metodos Sincronos

        public bool Insert(Customers customers)
        {
            //por lo general en el core va la logica de negocio, como estamos en una clase practica pues no
            return _customersRepository.Insert(customers);
        }

        public bool Update(Customers customers)
        {
            return _customersRepository.Update(customers);
        }

        public bool Delete(string customerId)
        {
            return _customersRepository.Delete(customerId); 
        }

        public Customers Get(string customerId)
        {
            return _customersRepository.Get(customerId);    
        }

        public IEnumerable<Customers> GetAll()
        {
            return _customersRepository.GetAll();
        }
        #endregion


        #region Metodos Asincronos

        public async Task<bool> InsertAsync(Customers customers)
        {
            return await _customersRepository.InsertAsync(customers);
        }

        public async Task<bool> UpdateAsync(Customers customers)
        {
            return await _customersRepository.UpdateAsync(customers);
        }

        public async Task<bool> DeleteAsync(string customerId)
        {
            return await _customersRepository.DeleteAsync(customerId);
        }

        public async Task<Customers> GetAsync(string customerId)
        {
            return await _customersRepository.GetAsync(customerId);
        }

        public async Task<IEnumerable<Customers>>  GetAllAsync()
        {
            return await _customersRepository.GetAllAsync();
        }
        #endregion
    }
}