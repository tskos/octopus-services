using System;
using System.Collections.Generic;
using Microsoft.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class EnumerableStringInputFormatter : TextInputFormatter
{
    public EnumerableStringInputFormatter()
    {
        // This formatter supports JSON.
        SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/json"));
        SupportedEncodings.Add(Encoding.UTF8);
        SupportedEncodings.Add(Encoding.Unicode);
    }

    protected override bool CanReadType(Type type)
    {
        return typeof(IEnumerable<string>).IsAssignableFrom(type);
    }

    public override Task<InputFormatterResult> ReadRequestBodyAsync(
        InputFormatterContext context,Encoding encoding)
    {
        var reqServices = context.HttpContext.RequestServices;
        ILogger logger = reqServices.GetService(typeof(ILogger<EnumerableStringInputFormatter>)) as ILogger;

        var request = context.HttpContext.Request;
        using(var reader = context.ReaderFactory(request.Body, encoding))
        using(var jsonReader = new JsonTextReader(reader))
        {
            // Important: Don't close the request stream 
            // because you many need it in other middleware or controllers.
            jsonReader.CloseInput = false;

            try
            {
                var myWordsKey = "myWords";

                // Load the body and determine if it's an array or single object.
                var token = JToken.Load(jsonReader);
                if((token.Type == JTokenType.Object) && (token[myWordsKey] != null) &&
                    (token[myWordsKey].Type == JTokenType.Array))
                {
                    var myWordsArray = token[myWordsKey];
                    var model = myWordsArray.ToObject<IEnumerable<string>>();
                    return InputFormatterResult.SuccessAsync(model);
                }
            }
            catch(Exception ex)
            {
                // Serialization failed, probably because it wasn't correct JSON.
                logger.LogError(0, ex, "Error parsing JSON.");
            }
            return InputFormatterResult.FailureAsync();
        }
    }
}