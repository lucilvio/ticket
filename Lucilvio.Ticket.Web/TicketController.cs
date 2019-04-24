using Microsoft.AspNetCore.Mvc;
namespace Lucilvio.Ticket.Web
{
    public class TicketController : Controller
    {
        public IActionResult RedirecionarComSucesso(string action, string mensagemDeSucesso)
        {
            TempData.Add("MensagemDeSucesso", mensagemDeSucesso);
            return RedirectToAction(action);
        }

        public IActionResult RedirecionarComErro(string action, string mensagemDeErro)
        {
            TempData.Add("MensagemDeErro", mensagemDeErro);
            return RedirectToAction(action);
        }
    }
}
