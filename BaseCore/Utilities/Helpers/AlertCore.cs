using BaseCore.Utilities.Enum;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace BaseCore.Utilities.Helpers
{
    public class AlertCore
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AlertCore(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void Alert(string messageTitle, IList<ValidationFailure> validationResultsErrors, SweetAlertNotificationType notifyType)
        {
            var results = '\u0022' + validationResultsErrors.Aggregate("", (current, error) => current + ("<p>" + error + " </p>")) + '\u0022';
            _httpContextAccessor.HttpContext?.Session.SetString("PopupMessage",
                SweetAlertHelper.Alert(messageTitle, results, notifyType));
        }

        public void Alert(string messageTitle, string messageDescription, SweetAlertNotificationType notifyType)
        {
            _httpContextAccessor.HttpContext?.Session.SetString("PopupMessage",
                SweetAlertHelper.Alert(messageTitle, "'" + messageDescription + "'", notifyType));
        }


    }
}
