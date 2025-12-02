public static class Nav {}
namespace FindYourHome.Helpers;

public static class Nav
{
    public static Task GoTo(string route, Dictionary<string, object>? parameters = null)
    {
        if (parameters == null)
            return Shell.Current.GoToAsync(route);

        return Shell.Current.GoToAsync(route, parameters);
    }

    public static Task Back()
    {
        return Shell.Current.GoToAsync("..");
    }
}
