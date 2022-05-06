using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace MJ.Solutions.Core.SpecificationResult.Result
{
  public class SpecificationValidationResult
  {
    public bool IsValid { get; protected set; }
    public IReadOnlyList<ValidationFailure> Errors { get; protected set; }

    public SpecificationValidationResult(bool isValid, IEnumerable<ValidationFailure> errors)
    {
      IsValid = isValid;
      Errors = errors?.ToList().AsReadOnly() ?? new List<ValidationFailure>().AsReadOnly();
    }
  }
}