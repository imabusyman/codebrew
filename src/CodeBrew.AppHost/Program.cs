var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.CodeBrew_Store_Api>("codebrew.store.api");

builder.AddProject<Projects.CodeBrew_LetsTravelIt_Api>("codebrew.letstravelit.api");

builder.Build().Run();