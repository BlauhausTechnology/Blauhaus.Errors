namespace Blauhaus.Errors
{
    public static class Errors
    {
        public static Error Undefined = Error.Create("No definition exists for this error");
        public static Error Unexpected(string errorMessage = "") => Error.Create("An unexpected error has occured" + errorMessage == "" ? "" : ": " + errorMessage);
    }
}