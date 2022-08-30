using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVenda.Core.Response
{
    public class ResponseResult<T> where T : class
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public T Data { get; set; }
        public IEnumerable<string> Errors { get; set; } = new List<string>();
    }
}
