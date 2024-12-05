namespace Company.FunctionApp4

open Microsoft.AspNetCore.Authentication.JwtBearer
open Microsoft.Azure.Functions.Worker
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting

module Main =

    let host =
        HostBuilder()
            .ConfigureFunctionsWebApplication(fun builder -> builder.UseFunctionsAuthorization() |> ignore)
            .ConfigureServices(fun services ->
                services
                    .AddFunctionsAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtFunctionsBearer(fun options ->
                        options.Authority <- "AUTHORITY"
                        options.Audience <- "AUDIENCE")
                |> ignore

                services.AddFunctionsAuthorization() |> ignore)
            .Build()

    host.Run()