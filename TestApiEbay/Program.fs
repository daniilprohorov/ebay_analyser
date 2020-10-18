// Learn more about F# at http://fsharp.org

open System
open FSharp.Data
//https://svcs.ebay.com/services/search/FindingService/v1?
//   OPERATION-NAME=findItemsByKeywords&
//   SERVICE-VERSION=1.0.0&
//   SECURITY-APPNAME=YourAppID&
//   RESPONSE-DATA-FORMAT=XML&
//   REST-PAYLOAD&
//   keywords=harry%20potter%20phoenix&
//   paginationInput.entriesPerPage=2
let getDataFromApi: HttpResponse =
    let baseUrl = "https://svcs.ebay.com/services/search/FindingService/v1"
    let appid = "-FindingD-PRD-fc9062648-8a125721"
    let keywords = "blackberry keyone"
    Http.Request
        ( baseUrl,
          query=
              [
                "OPERATION-NAME", "findItemsByKeywords";
                "SERVICE-VERSION", "1.0.0";
                "SECURITY-APPNAME", appid;
                "RESPONSE-DATA-FORMAT", "JSON";
                "REST-PAYLOAD", ""
                "itemFilter.name", "ListingType";
                "itemFilter.value", "Auction";
                "keywords", keywords;
                "paginationInput.entriesPerPage", "1";
                "sortOrder", "BidCountFewest"
              ],
          httpMethod="GET"
        )
    
    
[<EntryPoint>]
let main (argv: string []): int =
    Console.Write (JsonValue.Parse(getDataFromApi.Body.ToString().Split("\n").[1].[3..] |> (fun s -> s.[..(s.Length - 2)]))) 
    0
    
