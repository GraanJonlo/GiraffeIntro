module DomainTypes

type SearchQuery = SearchQuery of string
type SearchHits = SearchHits of int64
type SearchEngine = SearchQuery -> Async<SearchHits>