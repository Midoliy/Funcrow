open System
open System.Runtime.InteropServices
open System.IO
open MaybeComputation
open EitherComputation

module Directory =
    let exists = Directory.Exists

    let getFiles (searchOption:SearchOption) pattern path =
        path
        |> exists
        |> function 
           | true -> Some (Directory.GetFiles (path, pattern, searchOption))
           | false -> None

    let enumrateFiles (searchOption:SearchOption) pattern path =
        path
        |> exists
        |> function 
           | true -> Some (Directory.EnumerateFiles (path, pattern, searchOption))
           | false -> None

    let getDirectories (searchOption:SearchOption) pattern path =
        path
        |> exists
        |> function 
           | true -> Some (Directory.GetDirectories (path, pattern, searchOption))
           | false -> None

    let enumrateDirectories (searchOption:SearchOption) pattern path =
        path
        |> exists
        |> function 
           | true -> Some (Directory.EnumerateDirectories (path, pattern, searchOption))
           | false -> None       

    let createDirectiory path =
        path
        |> exists
        |> function
           | true -> Some (DirectoryInfo path)
           | false -> try Some (Directory.CreateDirectory path) with _ -> None

    let delete path =
        path
        |> exists
        |> function
           | true -> Directory.Delete path
           | false -> ()

Directory.getFiles SearchOption.AllDirectories "*" "./"
|> printfn "%A"


Directory.delete "./hogehoge"
