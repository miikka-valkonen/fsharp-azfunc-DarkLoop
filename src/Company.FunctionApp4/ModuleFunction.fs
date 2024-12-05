namespace Company.FunctionApp4

open DarkLoop.Azure.Functions.Authorization
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Mvc
open Microsoft.Azure.Functions.Worker
open Microsoft.Extensions.Logging

module ModuleFunction =

    [<FunctionAuthorize>]
    [<Function("modulefunction")>]
    let run
        ([<HttpTrigger("get", Route = null)>] req: HttpRequest)
        =
        let user = req.HttpContext.User
        OkObjectResult(user.Identity.Name)