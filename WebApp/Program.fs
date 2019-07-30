module WebApp.App

open System
open System.IO
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open FsConfig
open Giraffe

open InfrastructureTypes

// ---------------------------------
// Web app
// ---------------------------------

let webApp = text "Hello world!"

// ---------------------------------
// Config and Main
// ---------------------------------

let config =
    match EnvConfig.Get<Config>() with
    | Ok config -> config
    | Error error ->
        match error with
        | NotFound envVarName ->
            failwithf "Environment variable %s not found" envVarName
        | BadValue (envVarName, value) ->
            failwithf "Environment variable %s has invalid value %s" envVarName value
        | NotSupported msg ->
            failwith msg

let endpoint = BingEndpoint <| sprintf "https://%s.api.cognitive.microsoft.com" config.Endpoint
let apiKey = BingApiKey config.ApiKey

let configureApp (app : IApplicationBuilder) =
    app.UseDeveloperExceptionPage()
        .UseStaticFiles()
        .UseGiraffe(webApp)

let configureServices (services : IServiceCollection) =
    services.AddGiraffe() |> ignore

[<EntryPoint>]
let main _ =
    let contentRoot = Directory.GetCurrentDirectory()

    WebHostBuilder()
        .UseKestrel()
        .UseContentRoot(contentRoot)
        .Configure(Action<IApplicationBuilder> configureApp)
        .ConfigureServices(configureServices)
        .Build()
        .Run()
    0