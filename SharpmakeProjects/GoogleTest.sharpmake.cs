using System.IO;

using Sharpmake;

[module: Sharpmake.Include("BaseProject.sharpmake.cs")]

[Generate]
public class GoogleTest : BaseProject
{
    public GoogleTest() : base()
    {
        //The directory that contains the source code that we want include to the project
        SourceRootPath = Path.Combine(LibRootPath, "googletest", "src");
        SourceFilesFilters = new Strings
        {
            Path.Combine(SourceRootPath, "gtest-all.cc"),
            Path.Combine(SourceRootPath, "gtest_main.cc")
        };
        //SourceFilesFilters.Add("gtest_main.cc");
        //SourceFilesExclude.Add(Path.Combine(SourceRootPath, "gtest-all.cc"));

        AddTargets(MyOptions.GetCommonTarget());
    }

    public override void ConfigureAll(Project.Configuration conf, Target target)
    {
        base.ConfigureAll(conf, target);

        conf.Output = Configuration.OutputType.Lib;

        //conf.Output = Configuration.OutputType.Dll;
        // define is needed to build gtest as a .dll
        //conf.Defines.Add("GTEST_CREATE_SHARED_LIBRARY=1");

        conf.IncludePaths.Add(Path.Combine(LibRootPath, "googletest", "include"));
        conf.IncludePaths.Add(Path.Combine(LibRootPath, "googletest"));

        
    }

    private string LibRootPath
    {
        get { return Path.Combine(MyOptions.ExternPath, "googletest-1.13.0"); }
    }
}
