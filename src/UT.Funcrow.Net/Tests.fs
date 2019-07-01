module UT_Http

open System
open Xunit
open Funcrow.Tasks
open Funcrow.Net
open System.Net
open System.Net.Http
open System.Threading.Tasks
open System.IO

[<Theory>]
[<InlineData("https://www.google.com")>]
[<InlineData("https://midoliy.com")>]
let ``GET async`` url = 
    async { let! response = url |> Http.getAsync
            let! body = response.Content.ReadAsStringAsync() |> await
            return body }
    |> Async.RunSynchronously
    |> Assert.NotEmpty

[<Theory>]
[<InlineData("https://www.google.com")>]
[<InlineData("https://midoliy.com")>]
let ``POST async`` url = 
    let param = Map [ ("", ""); ]
    let content = new FormUrlEncodedContent (param)

    Async.StartWithContinuations(
        async { let! response = (content, url) ||> Http.postAsync
                let! body = response.Content.ReadAsStringAsync () |> await
                return body },
        (fun r -> r |> Assert.Empty; printfn "Operation completed."),
        (fun _ -> printfn "Operation failed."),
        (fun _ -> printfn "Operation canceled.") )
