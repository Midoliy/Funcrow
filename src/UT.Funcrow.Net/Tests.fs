module UT_Http

open System
open Xunit

[<Theory>]
[<InlineData("https://www.google.com", "")>]
let ``Get async`` url = 
    url
    |> (Http.GetAsync >> Async.RunSynchronously)
    |> Assert.NotEmpty


