using BaseCore.Utilities.Enum;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace BaseCore.Utilities.Helpers
{
    public class SweetAlertHelper
    {
        public static string Alert(string messageTitle, string messageDescription, SweetAlertNotificationType notifyType)
        {
            var result = "<script>Swal.fire(" + "'" + messageTitle + "'" + "," + messageDescription + "," + "'" + notifyType + "'" + ")</script>";
            return result;
        }

        public static string Alert(string messageTitle, IEnumerable<ValidationFailure> validationResultsErrors, SweetAlertNotificationType notifyType)
        {
            var message = '\u0022' + validationResultsErrors.Aggregate("", (current, error) => current + ("<p>" + error + " </p>")) + '\u0022';
            var result = "<script>Swal.fire(" + "'" + messageTitle + "'" + "," + message + "," + "'" + notifyType + "'" + ")</script>";
            return result;
        }

    }
}
