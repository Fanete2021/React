namespace API.Domain.Enum
{
    public enum StatusCode
    {
        OK = 200,
        InternalServerError = 500,
        
        DataWithErrors = 0,

        MovieNotFound = 1,

        ActorNotFound = 2,

        GenreNotFound = 3
    }
}
