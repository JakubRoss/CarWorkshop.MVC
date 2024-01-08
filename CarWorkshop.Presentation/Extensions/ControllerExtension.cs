using CarWorkshop.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarWorkshop.Presentation.Extensions
{
    public static class ControllerExtension
    {
        public static void SetNotification(this Controller controller, string type, string message )
        {
            var notification = new Notification($"{type}", $"{message}");
            controller.TempData["Notification"] = JsonConvert.SerializeObject(notification);
        }
    }
}
