using Newtonsoft.Json;

namespace Sevkiyat.Takip.Core.Models.Systems;
public class ErrorDetail
{
    public string? Message { get; set; }
    public int StatusCode { get; set; }
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}
