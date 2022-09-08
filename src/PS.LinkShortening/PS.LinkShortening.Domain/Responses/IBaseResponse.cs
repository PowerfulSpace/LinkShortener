using PS.LinkShortening.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.LinkShortening.Domain.Responses
{
    public interface IBaseResponse<T>
    {
        public string Description { get; }
        public StatusCode StatusCode { get; }
        public T? Data { get; }


    }
}
