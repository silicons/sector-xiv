namespace Content.Citadel.Client.Test;

/**
 * Placeholder, and to verify that shared projects work.
 */
public static class Test
{
    public const string ProjectName = "Content.Citadel.Client";

    public static string OtherString => Content.Shared._Citadel.Test.Test.ProjectName;
}
