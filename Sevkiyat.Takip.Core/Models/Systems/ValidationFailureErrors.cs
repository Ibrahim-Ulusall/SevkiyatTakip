using FluentValidation.Results;
using Newtonsoft.Json;

namespace Sevkiyat.Takip.Core.Models.Systems;

public class ValidationFailureErrors
{
    public int StatusCode { get; set; }
    public IEnumerable<ValidationExceptionModel> Errors { get; set; }
    public ValidationFailureErrors()
    {
        Errors = new List<ValidationExceptionModel>();
    }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}
