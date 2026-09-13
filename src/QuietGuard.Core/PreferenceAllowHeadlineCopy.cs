namespace QuietGuard;

public static class PreferenceAllowHeadlineCopy
{
    public static bool IsAllow(int actionId) => PreferenceAllowCopy.IsAllow(actionId);

    public static string Name(int actionId) => PreferenceAllowCopy.Name(actionId);

    public static int AllowId => PreferenceAllowCopy.AllowId;
}
