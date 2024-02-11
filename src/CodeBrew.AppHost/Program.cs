var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.CodeBrew_Store_Api>("codebrew.store.api");

builder.Build().Run();