using Azure;
using Mango.Services.ProductAPI.Model;
using Mango.Services.ProductAPI.Model.Dto;
using Mango.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers
{
    [Route("api/products")]
    public class ProductAPIController : ControllerBase
    {
        protected ResponseDto _response;
        private  IProductRepository _productRepository;

        public ProductAPIController(IProductRepository productRepository)
        {
            
            _productRepository = productRepository;
            this._response = new ResponseDto();
        }
        [HttpGet]
        [Authorize]
        public async Task<ResponseDto> Get()
        {
            try {
                IEnumerable<ProductDto> productDtos = await _productRepository.GetAllProducts();
                _response.Result = productDtos;
            }
            catch (Exception ex) {

                _response.IsSucess = false;
                _response.ErrorMessage = new List<string> { ex.Message };
            }
            return _response;
        }
        [HttpGet]
        [Authorize]
        [Route("{id}")]
        public async Task<ResponseDto> Get(int id)
        {
            try
            {
                ProductDto productDtos = await _productRepository.GetProductById(id);
                _response.Result = productDtos;

            }
            catch (Exception ex)
            {

                _response.IsSucess = false;
                _response.ErrorMessage = new List<string> { ex.Message };
            }
            return _response;
        }
        [HttpPost]
        [Authorize]
        public async Task<ResponseDto> Post([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto productDtos = await _productRepository.CreateUpdateProduct(productDto);
                _response.Result = productDtos;
            }
            catch (Exception ex)
            {

                _response.IsSucess = false;
                _response.ErrorMessage = new List<string> { ex.Message };
            }
            return _response;
        }
        [HttpPut]
        [Authorize]
        public async Task<ResponseDto> Put([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto productDtos = await _productRepository.CreateUpdateProduct(productDto);
                _response.Result = productDtos;
            }
            catch (Exception ex)
            {

                _response.IsSucess = false;
                _response.ErrorMessage = new List<string> { ex.Message };
            }
            return _response;
        }
        [HttpDelete]
        [Authorize(Roles ="Admin")]
        [Route("{id}")]
        public async Task<ResponseDto> Delete(int id)
        {
            try
            {
                bool IsSucess = await _productRepository.DeleteProduct(id);
                _response.Result = IsSucess;
            }
            catch (Exception ex)
            {

                _response.IsSucess = false;
                _response.ErrorMessage = new List<string> { ex.Message };
            }
            return _response;
        }
    }
}
