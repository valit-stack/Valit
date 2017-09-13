var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

Task("dotnet-restore")
	.Does(() => 
	{
		NuGetRestore("./Valit.sln");
	});

Task("dotnet-build")
	.IsDependentOn("dotnet-restore")	
	.Does(() => 
	{
		MSBuild("./Valit.sln", new MSBuildSettings()
			.SetConfiguration(configuration)
			.WithProperty("TreatWarningsAsErrors", "True"));
	});

Task("run-xunit-tests")
	.IsDependentOn("dotnet-build")
	.Does(() => 
	{
		XUnit2("./tests/**/bin/" + configuration + "/*.Valit.Tests.dll", new XUnit2Settings
		{
			OutputDirectory = "./.build/ValitTestResults",
			XmlReportV1 = true,
			NoAppDomain = true
		});
	});	

Task("Default")
	.IsDependentOn("run-xunit-tests");

RunTarget(target);