using Newtonsoft.Json;
using ProjectVenda.Core.DomainObjects;
using ProjectVenda.Core.Notificator;
using ProjectVenda.Core.Response;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVenda.BFF.Api.Services
{
    public abstract class Service
    {
        private INotificator _notificator;

        protected Service(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected StringContent SerializarObjeto(object obj)
            => new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

        protected void TratarErrosResponse<T>(ResponseResult<T> response) where T : class
        {
            response.Errors.ToList().ForEach(x => _notificator.Handle(new Notification(x)));
        }

        protected async Task<T> DeserializarObjeto<T>(HttpResponseMessage response)
        {
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }
    }
}
