using Sharpmake;

[module: Sharpmake.Include("EngineTestsSolution.sharpmake.cs")]

public static class Main
{
    [Sharpmake.Main]
    public static void SharpmakeMain(Arguments arguments)
    {
        arguments.Generate<EngineTestsSolution>();
    }
}
