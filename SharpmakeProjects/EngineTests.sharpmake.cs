using System.IO;

using Sharpmake;

[module: Sharpmake.Include("BaseProject.sharpmake.cs")]
[module: Sharpmake.Include("Engine.sharpmake.cs")]
[module: Sharpmake.Include("GoogleTest.sharpmake.cs")]

[Generate]
public class EngineTests : BaseProject
{
    public EngineTests() : base()
    {
        //The directory that contains the source code that we want include to the project
        SourceRootPath = Path.Combine(MyOptions.RootPath, "Tests");

        AddTargets(MyOptions.GetCommonTarget());
    }

    public override void ConfigureAll(Configuration conf, Target target)
    {
        base.ConfigureAll(conf, target);

        conf.Output = Configuration.OutputType.Exe;

        conf.IncludePaths.Add(SourceRootPath);

        conf.VcxprojUserFile = new Configuration.VcxprojUserFileSettings();
        conf.VcxprojUserFile.LocalDebuggerWorkingDirectory = MyOptions.RootPath;

        // For inherited properties such as include paths and library paths,
        // Sharpmake provides the option to choose between public and private dependencies.
        // Private dependencies are not propagated to dependent projects
        conf.AddPublicDependency<Engine>(target);
        conf.AddPrivateDependency<GoogleTest>(target);

        conf.PrecompHeader = Path.Combine("Tests", "pch.h");
        conf.PrecompSource = Path.Combine("Tests", "pch.cpp");
    }
}
