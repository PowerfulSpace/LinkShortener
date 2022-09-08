using PS.LinkShortening.Domain.Enums;

namespace PS.LinkShortening.Domain.Responses
{
    public interface IBaseResponse<T>
    {
        public string Description { get; }
        public StatusCode StatusCode { get; }
        public T? Data { get; }


    }
}
