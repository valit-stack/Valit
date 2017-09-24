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
		DotNetCoreTest("./tests/Valit.Tests/Valit.Tests.csproj", new DotNetCoreTestSettings
		{
			Configuration = configuration
		});
	});	

Task("Default")
	.IsDependentOn("run-xunit-tests");

RunTarget(target);