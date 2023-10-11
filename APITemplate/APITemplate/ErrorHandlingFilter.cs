using ExceptionsLibrary;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace APITemplate
{

    /// <summary>
    /// Global way to handel exceptions so redundent exception handeling is not done in the controllers or the referencing projects.
    /// </summary>
    public class ErrorHandlingFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.Result = context.Exception.GetObjectResult();
        }
    }
}
