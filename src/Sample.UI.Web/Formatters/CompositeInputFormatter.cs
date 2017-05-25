using System.Threading.Tasks;
using MessagePack.AspNetCoreMvcFormatter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Sample.UI.Web.Formatters
{
    public class CompositeInputFormatter : IInputFormatter
    {
        public CompositeInputFormatter(JsonInputFormatter jsonFormatter, MessagePackInputFormatter messagePackFormatter)
        {
            _jsonFormatter = jsonFormatter;
            _messagePackFormatter = messagePackFormatter;
        }

        private readonly JsonInputFormatter _jsonFormatter;
        private readonly MessagePackInputFormatter _messagePackFormatter;

        public bool CanRead(InputFormatterContext context)
        {
            return true;
        }

        public Task<InputFormatterResult> ReadAsync(InputFormatterContext context)
        {
            return context.HttpContext.Request.Path.StartsWithSegments(new PathString("/test"))
                ? _jsonFormatter.ReadAsync(context)
                : _messagePackFormatter.ReadAsync(context);
        }
    }
}
