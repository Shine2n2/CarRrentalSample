using System;
using System.Threading.Tasks;

namespace CarRentalsApp_WEB.Models
{
    public interface IHttpCommandHandler
    {
        Task<TRes> DeleteRequest<TRes>(Guid id) where TRes : class;
        Task<TRes> GetRequest<TRes>(string requestUrl) where TRes : class;
        Task<TRes> PostRequest<TRes, TReq>(TReq requestModel, string requestUrl) where TRes : class where TReq : class;
        Task<TRes> UpdateRequest<TRes, TReq>(TReq requestModel, string requestUrl) where TRes : class where TReq : class;
    }
}