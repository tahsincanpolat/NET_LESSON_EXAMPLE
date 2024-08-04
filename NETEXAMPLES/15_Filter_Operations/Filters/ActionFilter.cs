using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace _15_Filter_Operations.Filters
{
    public class ActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Debug.WriteLine("Action Executed"); // Action (View) çalıştıktan sonra tetiklenir.
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Debug.WriteLine("Action Executing");  // Action (View) çalıştırken sonra tetiklenir.
        }
    }
}
