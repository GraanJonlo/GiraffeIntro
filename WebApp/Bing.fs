module Bing

open Microsoft.Azure.CognitiveServices.Search.WebSearch

open InfrastructureTypes
open DomainTypes

let bingQuery (BingApiKey apiKey) (BingEndpoint endpoint) (SearchQuery query) =
    let client = new WebSearchClient(ApiKeyServiceClientCredentials(apiKey))
    client.Endpoint <- endpoint

    async {
        let! webData = Async.AwaitTask <| client.Web.SearchAsync(query=query)

        let count = webData.WebPages.TotalEstimatedMatches
        if count.HasValue then
            return SearchHits count.Value
        else
            return SearchHits <| int64 0
    }