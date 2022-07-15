
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProjectVenda.Core.DomainObjects;
using ProjectVenda.Core.Notificator;
using System.Collections.Generic;
using System.Linq;

namespace ProjectVenda.Core.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        protected INotificator _notificator;

        public MainController(INotificator notificator)
        {
            _notificator = notificator;

        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (Validate()) return Ok(new
            {
                success = true,
                data = result
            });

            return BadRequest(new
            {
                success = false,
                errors = _notificator.GetNotifications().Select(e => e.Message)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);

            errors.ToList().ForEach(x => AddError(x.ErrorMessage));

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            validationResult.Errors.ForEach(e => AddError(e.ErrorMessage));

            return CustomResponse();
        }

        protected void AddError(string error)
        {
            _notificator.Handle(new Notification(error));
        }

        protected bool Validate()
        {
            return !_notificator.ExistsNotification();
        }

        protected void ClearErrors()
        {
            _notificator.Clear();
        }
    }
}
