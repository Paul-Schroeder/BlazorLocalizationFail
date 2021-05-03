using SprayCalc.Client.Helpers;
using System;
using System.Text;
using static SprayCalc.Client.Consts.ComponentEnums;

namespace SprayCalc.Client.ViewModels
{
    public class MetricReadyToUseViewModel : BaseSprayCalcViewModel
    {
        protected Models.MetricReadyToUse MetricReadyToUse
        {
            get;
        } = new() { CreatedDate = DateTime.UtcNow };

        protected string EmailBody { get; set; } = null;
        protected string EmailSubject { get; set; } = null;
        protected string EmailToAddress { get; set; } = null;

        protected bool IsLocalEmailSelected { get; set; } = true;
        protected bool SendEmailDialogIsOpen { get; set; } = false;

        protected async void OkClick()
        {
            SendEmailDialogIsOpen = false;
            if (IsLocalEmailSelected)
            {
                SendLocalEmail(EmailToAddress, EmailSubject, EmailBody);
            }
            else
            {
                SendOnlineEmailAsync(EmailToAddress, EmailSubject, EmailBody);
            }
        }

        protected void OnLocalEmailClicked()
        {
            IsLocalEmailSelected = true;
            OpenSendEmailDialog();
        }

        protected void OnOnlineEmailClicked()
        {
            IsLocalEmailSelected = false;
            OpenSendEmailDialog();
        }

        private string GetEmailBodyAsString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"SwathSize: \t{EnumHelper<SwathSize>.GetDisplayValue(MetricReadyToUse.SwathSize)}");
            sb.AppendLine($"Product: \t{MetricReadyToUse.ProductName}");
            sb.AppendLine($"Grams ai/liter: \t{MetricReadyToUse.GramsAiPerLiter}");
            sb.AppendLine($"ChemicalCost / Liter ($): \t{MetricReadyToUse.ChemicalCostPerLiter}");
            sb.AppendLine($"Flow Rate (l/hr): \t{MetricReadyToUse.FlowRateLiterPerHour}");
            sb.AppendLine($"Speed (kph): \t{MetricReadyToUse.SpeedKilometerPerHour}");

            return sb.ToString();
        }

        private void OpenSendEmailDialog()
        {
            EmailToAddress = "Paul@MSCTek.com";
            EmailSubject = MetricReadyToUse.Note;
            EmailBody = GetEmailBodyAsString();

            SendEmailDialogIsOpen = true;
        }
    }
}