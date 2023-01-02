using Microsoft.Extensions.Options;

namespace Platform
{
    public class LocationMiddleWare
    {
        private RequestDelegate _next;
        private MessagOptions _opts;
        public LocationMiddleWare(RequestDelegate requestDelegate, 
            IOptions<MessagOptions> opts)
        {
            _next = requestDelegate;
            _opts = opts.Value;
        }

        public async Task Invoke(HttpContxt context)
        {
            if (context.Request.Path == "/location") {
                await context.Response
                    .WriteAsync($"{_opts.CityName}, {_opts.CountryName}");
            }
            else
            {
                await _next(context);
            }
        }
    }
    public class QueryStringMiddleWare
    {
        private RequestDelegate? _next;
        public QueryStringMiddleWare()
        {
            //do nothing
        }
        public QueryStringMiddleWare(RequestDelegate nextDelegate)
        {
            _next = nextDelegate;
        }
        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Method == HttpMethods.Get
                    && context.Request.Query["custom"] == "true")
            {
                if (!context.Response.HasStarted)
                {
                    context.Response.ContentType = "text/plain";
                }
                await context.Response.WriteAsync("Class-based Middleware \n");
            }
            if(_next != null)
            {
                await _next(context);
            }
        }
    }
}
