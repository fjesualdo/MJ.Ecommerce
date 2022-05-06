namespace MJ.Solutions.Core.Specification
{
	public class Rule<T>
	{
		private readonly Specification<T> _specificationSpec;

		public string ErrorMessage { get; }


		public Rule(Specification<T> spec, string errorMessage)
		{
			_specificationSpec = spec;
			ErrorMessage = errorMessage;
		}

		public bool Validate(T obj)
		{
			return _specificationSpec.IsSatisfiedBy(obj);
		}
	}
}
