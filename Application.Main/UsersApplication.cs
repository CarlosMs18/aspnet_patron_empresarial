using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.DTO;
using Application.Interface;
using Application.Validator;
using AutoMapper;
using Domain.Interface;
using Transversal.Common;



namespace Application.Main
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IUsersDomain _usersDomain;
        private readonly IMapper _mapper;
        private readonly UsersDtoValidator _usersDtoValidator;

        public UsersApplication(
            IUsersDomain usersDomain,
            IMapper mapper,
            UsersDtoValidator usersDtoValidator
            )
        {
            _usersDomain = usersDomain;
            _mapper = mapper;
            _usersDtoValidator = usersDtoValidator; 
        }

        public Response<UsersDto> Authenticate(string username, string password)
        {
            var response = new Response<UsersDto>();

            var validation = _usersDtoValidator.Validate(new UsersDto() { UserName = username, Password = password }); //Almacenara la rpta del ValidatorFluent


            if(!validation.IsValid) {
                response.Message = "Errores de validación";
                response.Errors = validation.Errors;
                return response;
            }
            try
            {
                var user = _usersDomain.Authenticate(username, password);
                response.Data = _mapper.Map<UsersDto>(user);    
                response.IsSuccess = true;
                response.Message = "Autenticacion Exitosa";

            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = true;
                response.Message = "Usuario no existe";
            }
            catch(Exception e)
            
            {
                response.Message = e.Message;
            }
            return response;
        }
    }
}
