using System;

namespace CatalogCave.Common.Helpers;

public static class AppMessages
{
    // Success Messages

    public const string RetrieveAll = "successfully retrieved {0}s.";
    public const string RetrievedById = "Successfully retrieved  {0}.";

    //Error Messaged 
    public const string NotFound = "No matching {0} found.";
    public const string Unsuccessful = " {0} unsuccessful.";


    public static string FormatMessage(string template, string resourceName)
    {
        return string.Format(template, resourceName);
    }

}
