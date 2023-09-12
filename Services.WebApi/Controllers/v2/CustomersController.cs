using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Application.DTO;
using Application.Interface;
using Microsoft.AspNetCore.Authorization;

namespace Services.WebApi.Controllers.v2
{
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")] //USANDO VERSIONADO URL SEMANTICO
    [ApiController]
    [ApiVersion("2.0")]
    public class CustomersController : Controller //Internamente este hereda de contgrollerbase
    {
        private readonly ICustomersApplication _customersApplication;

        public CustomersController(ICustomersApplication customersApplication)
        {
            _customersApplication = customersApplication;
        }

        #region "Metodos Sincronos"

        [HttpPost("Insert")]
        public IActionResult Insert([FromBody] CustomersDTO customersDTO)
        {
            if (customersDTO == null) return BadRequest();

            var response = _customersApplication.Insert(customersDTO);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }


        [HttpPut("Update/{customerId}")]
        public IActionResult Update(string customerId, [FromBody] CustomersDTO customersDTO)
        {
            var customerDto = _customersApplication.Get(customerId);
            if(customerDto.Data == null)
            {
                return NotFound(customerDto.Message);
            }

            if (customersDTO == null) return BadRequest();

            var response = _customersApplication.Update(customersDTO);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }



        [HttpDelete("Delete/{customerId}")]
        public IActionResult Delete(string customerId)
        {
            if (string.IsNullOrEmpty(customerId)) return BadRequest();

            var response = _customersApplication.Delete(customerId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }

        [HttpGet("Get/{customerId}")]
        public IActionResult Get(string customerId)
        {
            if (string.IsNullOrEmpty(customerId)) return BadRequest();

            var response = _customersApplication.Get(customerId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {


            var response = _customersApplication.GetAll();
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }
        #endregion

        #region Metodos Asinccronos

        [HttpPost("InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody] CustomersDTO customersDTO)
        {
            if (customersDTO == null) return BadRequest();

            var response = await _customersApplication.InsertAsync(customersDTO);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }


        [HttpPut("UpdateAsync/{customerId}")]
        public async Task<IActionResult> UpdateAsync(string customerId, [FromBody] CustomersDTO customersDTO)
        {
            var customerDto = await _customersApplication.GetAsync(customerId);
            if(customerDto.Data == null) return NotFound(customerDto.Message);

            if (customersDTO == null) return BadRequest();

            var response = await _customersApplication.UpdateAsync(customersDTO);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }



        [HttpDelete("DeleteAsync/{customerId}")]
        public async Task<IActionResult> DeleteAsync(string customerId)
        {
            if (string.IsNullOrEmpty(customerId)) return BadRequest();

            var response = await _customersApplication.DeleteAsync(customerId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }


        [HttpGet("GetAsync/{customerId}")]
        public async Task<IActionResult> GetAsync(string customerId)
        {
            if (string.IsNullOrEmpty(customerId)) return BadRequest();

            var response = await _customersApplication.GetAsync(customerId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }


        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {


            var response = await _customersApplication.GetAllAsync();
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }


        #endregion

    }
}
