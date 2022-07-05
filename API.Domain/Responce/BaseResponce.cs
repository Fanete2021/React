using API.Domain.Enum;

namespace API.Domain.Responce
{
    public class BaseResponce<T>
    {
        public string DescriptionError { get; set; }

        public StatusCode StatusCode { get; set; }

        public T Data { get; set; }
    }
}
