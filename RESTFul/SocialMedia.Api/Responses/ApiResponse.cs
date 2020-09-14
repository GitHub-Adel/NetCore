using System;
using SocialMedia.Core.CustomEntities;

namespace SocialMedia.Api.Responses
{
    //convierte a Data en el object que reciba por el constructor
    //debe crear un object y pasarlo ApiResponse<Object>    
    public class ApiResponse<T>
    {
        public T Data { get; }
        public Paged Pagination { get; }
        public ApiResponse(T data, Paged pagination = null)
        {
            this.Data = data;
            this.Pagination = pagination == null ? default(Paged) : pagination;
        }

    }
}
