namespace apbd_cw3_s33536.Mod.Exceptions;

public class ItemNotAvailableException : Exception
{
    public ItemNotAvailableException(string message) : base(message) { }
}

public class UserLimitExceededException : Exception
{
    public UserLimitExceededException(string message) : base(message) { }
}

public class RentalNotFoundException : Exception
{
    public RentalNotFoundException(string message) : base(message) { }
}