using HiperAPI.Application.DTO.Products;
using HiperAPI.Application.Interfaces;
using HiperAPI.Domain.Exceptions;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;

namespace HiperAPI.Controllers
{

    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IApplicationServiceProduct _applicationServiceProduct;

        public ProductController(IApplicationServiceProduct applicationServiceProduct)
        {
            _applicationServiceProduct = applicationServiceProduct;
        }

        // GET: api/<ProductController>
        [HttpGet]
        [ProducesResponseType(statusCode: 200, Type = typeof(IList<ProductDTO>))]
        [ProducesResponseType(statusCode: 404)]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_applicationServiceProduct.GetAll());
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(statusCode: 200, Type = typeof(ProductDTO))]
        [ProducesResponseType(statusCode: 404)]
        [ProducesResponseType(statusCode: 500)]
        public ActionResult<string> Get(int id)
        {
            try
            {
                return Ok(_applicationServiceProduct.GetById(id));
            }
            catch (ProductNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        [ProducesResponseType(statusCode: 200)]
        [ProducesResponseType(statusCode: 404)]
        [ProducesResponseType(statusCode: 500)]
        public ActionResult Post([FromBody] ProductDTO productDTO)
        {
            try
            {
                if (productDTO == null)
                    return NotFound();

                _applicationServiceProduct.Add(productDTO);
                return Ok("Product successfully registered!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut()]
        [ProducesResponseType(statusCode: 200)]
        [ProducesResponseType(statusCode: 404)]
        [ProducesResponseType(statusCode: 500)]
        public ActionResult Put([FromBody] ProductDTO productDTO)
        {
            try
            {
                if (productDTO == null)
                    return NotFound();

                _applicationServiceProduct.Update(productDTO);
                return Ok("Product updated successfully!");
            }
            catch (ProductNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(statusCode: 200)]
        [ProducesResponseType(statusCode: 404)]
        [ProducesResponseType(statusCode: 500)]
        public IActionResult Delete(int id)
        {
            try
            {
                _applicationServiceProduct.Remove(id);
                return Ok("Product successfully removed!");
            }
            catch (ProductNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
