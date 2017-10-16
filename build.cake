#tool "nuget:?package=xunit.runner.console"

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

Task("dotnet-restore")
	.Does(() => 
	{
		DotNetCoreRestore("./Valit.sln");
	});

Task("dotnet-build")
	.IsDependentOn("dotnet-restore")	
	.Does(() => 
	{
		DotNetCoreBuild("./Valit.sln", new DotNetCoreBuildSettings 
		{
			Configuration = configuration,
			MSBuildSettings = new DotNetCoreMSBuildSettings
			{
				TreatAllWarningsAs = MSBuildTreatAllWarningsAs.Error
			}
		});
	});

Task("run-xunit-tests")	
	.IsDependentOn("dotnet-build")
	.Does(() => 
	{
		var settings = new DotNetCoreTestSettings
        {
 			Configuration = configuration,			
            ArgumentCustomization = args => args.Append("--logger \"trx;LogFileName=valit_tests_result.xml\"")
        };
		
		DotNetCoreTest("./tests/Valit.Tests/Valit.Tests.csproj", settings);
	});	

Task("Default")
	.IsDependentOn("run-xunit-tests");

RunTarget(target);