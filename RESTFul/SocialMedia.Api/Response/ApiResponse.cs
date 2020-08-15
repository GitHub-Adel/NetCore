using System;

namespace SocialMedia.Api.Response
{
    //convierte a Data en el object que reciba por el constructor
    //debe crear un object y pasarlo ApiResponse<Object>    
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            this.Data=data;
        }

        public T Data { get; set; }
    }
}
