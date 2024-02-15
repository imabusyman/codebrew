var builder = DistributedApplication.CreateBuilder(args);


builder.AddProject<CodeBre>("codebrew.letstravelit.api");

builder.Build().Run();