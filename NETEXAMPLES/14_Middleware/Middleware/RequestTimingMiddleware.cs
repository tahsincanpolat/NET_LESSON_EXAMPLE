using System.Diagnostics;

namespace _14_Middleware.Middleware
{
    public class RequestTimingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestTimingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var watch = Stopwatch.StartNew(); // zaman ölçümü başlat

            await _next(context); // bir sonraki middleware i çağır.

            watch.Stop(); // zaman ölçümünü durdur

            var elapsed = watch.ElapsedMilliseconds; // Geçen süreyi al

            // Geçen süreyi yazdır.

            Debug.WriteLine($"İstek yolu: {context.Request.Path} - İşleme süresi: {elapsed} ms");
        }
    }
}
