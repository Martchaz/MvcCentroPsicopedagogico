using Microsoft.AspNetCore.Mvc;
using MvcCentroPsicopedagogico.Models.ChatBot;
using MvcCentroPsicopedagogico.Services;
using MvcCentroPsicopedagogico.Models;

public class ChatBotController : Controller
{
    private readonly ChatBotService _chat;
    public ChatBotController(ChatBotService chat) => _chat = chat;

    [HttpPost]
    public async Task<IActionResult> Send([FromBody] ChatRequest req)
    {
        var userContext = new UserContext { UserId = req.SessionId }; // Simulado
        var resp = await _chat.ProcessMessageAsync(req.Message, userContext);
        return Json(resp);
    }

    [HttpGet]
    public IActionResult Index() => View();
}