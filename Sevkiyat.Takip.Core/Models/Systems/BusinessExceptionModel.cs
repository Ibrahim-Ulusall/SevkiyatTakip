using Newtonsoft.Json;

namespace Sevkiyat.Takip.Core.Models.Systems;

public class BusinessExceptionModel : Exception
{
    public BusinessExceptionModel() { }
    public BusinessExceptionModel(string message) : base(message) { }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}