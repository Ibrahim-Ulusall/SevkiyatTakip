using Newtonsoft.Json;

namespace Sevkiyat.Takip.Core.Models.Systems;

public class SecurityExceptionModel : Exception
{
    public SecurityExceptionModel() { }
    public SecurityExceptionModel(string message) : base(message) { }
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}