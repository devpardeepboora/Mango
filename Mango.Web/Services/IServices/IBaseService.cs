using Mango.Web.Models;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Mango.Web.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        ResponseDto responseModel { get; set; }

        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
