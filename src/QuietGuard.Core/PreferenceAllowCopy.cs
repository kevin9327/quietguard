namespace QuietGuard;

public static class PreferenceAllowCopy
{
    public static bool IsAllow(int actionId) => PreferenceActionText.IsAllow(actionId);
    public static string Name(int actionId) => PreferenceActionText.Name(actionId);
    public static int AllowId => PreferenceActionText.AllowId;
}
