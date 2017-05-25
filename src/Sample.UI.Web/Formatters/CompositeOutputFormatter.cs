using System.Threading.Tasks;
using MessagePack.AspNetCoreMvcFormatter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Sample.UI.Web.Formatters
{
    public class CompositeOutputFormatter : IOutputFormatter
    {
        public CompositeOutputFormatter(JsonOutputFormatter jsonFormatter, MessagePackOutputFormatter messagePackFormatter)
        {
            _jsonFormatter = jsonFormatter;
            _messagePackFormatter = messagePackFormatter;
        }

        private readonly JsonOutputFormatter _jsonFormatter;
        private readonly MessagePackOutputFormatter _messagePackFormatter;

        public bool CanWriteResult(OutputFormatterCanWriteContext context)
        {
            return true;
        }

        public Task WriteAsync(OutputFormatterWriteContext context)
        {
            return context.HttpContext.Request.Path.StartsWithSegments(new PathString("/test"))
                ? _jsonFormatter.WriteAsync(context)
                : _messagePackFormatter.WriteAsync(context);
        }
    }
}
