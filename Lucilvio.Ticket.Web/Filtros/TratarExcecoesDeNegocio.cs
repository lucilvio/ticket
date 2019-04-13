using Lucilvio.Ticket.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucilvio.Ticket.Web.Filtros
{
    public class TratarExcecoesDeNegocio : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType().BaseType != typeof(ExcecaoDeNegocio))
            {
                context.ExceptionHandled = false;
                return;
            }

            
            context.ExceptionHandled = true;

            context.Result = new ViewResult();
        
            base.OnException(context);
        }
    }
}
