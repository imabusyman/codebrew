var builder = DistributedApplication.CreateBuilder(args);




builder.AddProject<Projects.CodeBrew_LetsTravelIt_Api>("codebrew.letstravelit.api");




builder.Build().Run();