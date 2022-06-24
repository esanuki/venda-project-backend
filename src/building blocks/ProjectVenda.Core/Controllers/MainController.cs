
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProjectVenda.Core.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        protected ICollection<string> Errors = new List<string>();

        protected ActionResult CustomResponse(object result = null)
        {
            if (Validate()) return Ok(result);

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "errors", Errors.ToArray() }
            }));
        }

        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            validationResult.Errors.ForEach(e => AddError(e.ErrorMessage));

            return CustomResponse();
        }

        protected void AddError(string error)
        {
            Errors.Add(error);
        }

        protected bool Validate()
        {
            return !Errors.Any();
        }

        protected void ClearErrors()
        {
            Errors.Clear();
        }
    }
}
