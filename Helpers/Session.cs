public static class Session {}
using FindYourHome.Models;

namespace FindYourHome.Helpers;

public static class Session
{
    public static User? CurrentUser { get; set; }
}
