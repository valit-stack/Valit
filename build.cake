#tool "nuget:?package=xunit.runner.console"
#tool nuget:?package=Codecov
#addin nuget:?package=Cake.Codecov

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
            ArgumentCustomization = args => args.Append("--logger \"trx;LogFileName=TestResults.xml\"")
        };

		DotNetCoreTest("./tests/Valit.Tests/Valit.Tests.csproj", settings);
	});	

Task("upload-codecov-report")
	.IsDependentOn("run-xunit-tests")
	.Does(() => 
	{
		Codecov("./tests/Valit.Tests/TestResults/TestResults.xml", "be5bdd32-07b0-40f5-aafe-4ef957c7f946");
	});

Task("Default")
	.IsDependentOn("upload-codecov-report");

RunTarget(target);