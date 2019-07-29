module InfrastructureTypes

open FsConfig

type BingEndpoint = BingEndpoint of string
type BingApiKey = BingApiKey of string

[<Convention("MANCFUG")>]
type Config = {
    Endpoint: string
    ApiKey: string
}