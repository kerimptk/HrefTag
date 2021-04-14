using BaseCore.Utilities.Enum;
using BaseCore.Utilities.Helpers;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;


namespace BaseCore.Controllers.MVC
{
    public class BaseController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BaseController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void Alert(string messageTitle, string messageDescription, SweetAlertNotificationType notifyType)
        {
            new AlertCore(_httpContextAccessor).Alert(messageTitle, messageDescription, notifyType);
        }

        public void Alert(string messageTitle, IList<ValidationFailure> validationResultsErrors, SweetAlertNotificationType notifyType)
        {
            new AlertCore(_httpContextAccessor).Alert(messageTitle, validationResultsErrors, notifyType);
        }

        public int GetUserId()
        {
            var result = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            return Convert.ToInt32(result);
        }

    }
}
