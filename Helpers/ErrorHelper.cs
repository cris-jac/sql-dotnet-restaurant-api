namespace RestaurantAPI.Helpers;

public static class ErrorHelper
{
    public static List<string> ExtractErrorMessages(Exception ex)
    {
        var errorMessages = new List<string>();

        while (ex != null)
        {
            errorMessages.Add(ex.Message);
            ex = ex.InnerException;
        }

        return errorMessages;
    }
}