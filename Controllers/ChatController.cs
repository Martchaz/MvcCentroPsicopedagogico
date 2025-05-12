using Microsoft.AspNetCore.Mvc;
using MvcCentroPsicopedagogico.Services;
using Microsoft.AspNetCore.Mvc;
using MvcCentroPsicopedagogico.Services;

namespace MvcCentroPsicopedagogico.Controllers
{
    public class ChatController : Controller
    {
        private readonly ChatBotService _chatBotService;

        public ChatController(ChatBotService chatBotService)
        {
            _chatBotService = chatBotService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetResponse(string message)
        {
            var response = _chatBotService.GetResponse(message);
            return Json(new { response });
        }
    }
}
