namespace sigmaBack.Domain.Validation
{
    public class DomainExceptionValidation : Exception
    {
        public DomainExceptionValidation(string error) : base(error)
        { }

        public static void When(bool condition, string errorMessage)
        {
            if (condition)
            {
                throw new DomainExceptionValidation(errorMessage);
            }
        }
    }
}
