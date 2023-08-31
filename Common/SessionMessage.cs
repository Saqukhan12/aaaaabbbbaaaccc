// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SessionMessage.cs" company="">
//   
// </copyright>
// <summary>
//   The session message.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DotNetCoreBoilerplate.Common
{
    using DotNetCoreBoilerplate.Common.Enum;

    /// <summary>
    /// The session message.
    /// </summary>
    public static class SessionMessage
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public static string Message { get; set; }

        /// <summary>
        /// Gets or sets the page alert type.
        /// </summary>
        public static PageAlertType PageAlertType { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public static string Title { get; set; }

        public static void InitiateSessionMessage(PageAlertType pageAlertType, string title, string message)
        {
            PageAlertType = pageAlertType;
            Message = message;
            Title = title;
        }
    }
}