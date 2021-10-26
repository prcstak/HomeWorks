namespace hw6

open System
open Calculator
open Giraffe
open System.Collections.Generic
open System.IO
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open Calculator.Calculate

module Program =
    
    let calculateHandler (arg1:string, op: string, arg2:string) : HttpHandler =
        fun (next : HttpFunc) (ctx : HttpContext) ->
           let oper = match op with
            | "plus" -> "+"
            | "subtract" -> "-"
            | "multiply"  -> "*"
            | "divide"  -> "/"
            | _ -> "?"
           (arg1+ " " + oper + " " + arg2 + " " + "="+ " " + go [|arg1; op; arg2|]|> text) next ctx
            
    let webApp: HttpFunc -> Http.HttpContext -> HttpFuncResult =
        choose [
            route "/ping"   >=> text "pong"
            route "/"       >=> htmlFile "/pages/index.html"
            routef "/calculate/arg1=%s&op=%s&arg2=%s" calculateHandler
            ]
    
    type Startup() =
        member __.ConfigureServices (services : IServiceCollection) =
            // Register default Giraffe dependencies
            services.AddGiraffe() |> ignore

        member __.Configure (app : IApplicationBuilder)
                            (env : IHostingEnvironment)
                            (loggerFactory : ILoggerFactory) =
            // Add Giraffe to the ASP.NET Core pipeline
            app.UseGiraffe webApp
    
    [<EntryPoint>]
    let main _ =
        Host.CreateDefaultBuilder()
            .ConfigureWebHostDefaults(
                fun webHostBuilder ->
                    webHostBuilder
                        .UseStartup<Startup>()
                        |> ignore)
            .Build()
            .Run()
        0