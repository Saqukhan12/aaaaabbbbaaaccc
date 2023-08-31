// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AlertNotification.cs" company="">
//   
// </copyright>
// <summary>
//   The alert notification.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotNetCoreBoilerplate.Common
{
    using DotNetCoreBoilerplate.Common.Enum;

    /// <summary>
    /// The alert notification.
    /// </summary>
    public class AlertNotification
    {

        public AlertNotification()
        {

        }

        public AlertNotification(AlertNotification alertNotification)
        {
            this.NotificationMessage = alertNotification.NotificationMessage;
            this.Title = alertNotification.Title;
            this.PageAlertType = alertNotification.PageAlertType;
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the alert type.
        /// </summary>
        public PageAlertType PageAlertType { get; set; }

        /// <summary>
        /// Gets or sets the notification message.
        /// </summary>
        public string NotificationMessage { get; set; }
    }
}