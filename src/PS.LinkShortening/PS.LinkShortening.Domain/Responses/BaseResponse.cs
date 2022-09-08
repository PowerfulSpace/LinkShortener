using PS.LinkShortening.Domain.Enums;

namespace PS.LinkShortening.Domain.Responses
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string Description { get; set; } = null!;
        public StatusCode StatusCode { get; set; }
        public T? Data { get; set; }
    }
}
