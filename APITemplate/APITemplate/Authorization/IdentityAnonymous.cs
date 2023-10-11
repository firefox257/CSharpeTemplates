using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace APITemplate.Authorization
{
    /// <summary>
    /// This method sets the end point to allow anonymous public connections.
    /// It is empty at this will override the IdentityAuthrorization implementation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class IdentityAnonymous : Attribute
    {
    }
}
