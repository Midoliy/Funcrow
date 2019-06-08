namespace Funcrow.Core

open System
open System.IO
open EitherComputation
open MaybeComputation

module Directory =
    let exists = Directory.Exists
    let create path = 
        path |> exists
             |> function
                | true -> Some (DirectoryInfo (path))
                | false -> try Some (Directory.CreateDirectory path) with _ -> None
    let delete path =
        path |> exists
             |> function
                | true -> try Directory.Delete path; Right true with | exn as e -> Left e
                | false -> Right true 
    let getFilesWithOptions pattern (depth:SearchOption) path =
        path |> exists
             |> function
                | true -> Some (Directory.GetFiles (path, pattern, depth))
                | false -> None
    let getFilesWithSearchDepth (depth:SearchOption) path = getFilesWithOptions "*" depth path
    let getFiles path = getFilesWithSearchDepth SearchOption.TopDirectoryOnly path
    let enumerateFilesWithOptions pattern (depth:SearchOption) path =
        path |> exists
             |> function
                | true -> Some (Directory.EnumerateFiles (path, pattern, depth))
                | false -> None
    let enumerateFilesWithSearchDepth (depth:SearchOption) path = enumerateFilesWithOptions "*" depth path
    let enumerateFiles path = enumerateFilesWithSearchDepth SearchOption.TopDirectoryOnly path
    let getDirectoriesWithOptions pattern (depth:SearchOption) path =
        path |> exists
             |> function
                | true -> Some (Directory.GetDirectories (path, pattern, depth))
                | false -> None
    let getDirectoriesWithSearchDepth (depth:SearchOption) path = getDirectoriesWithOptions "*" depth path
    let getDirectories path = getDirectoriesWithSearchDepth SearchOption.TopDirectoryOnly path
    let enumerateDirectoriesWithOptions pattern (depth:SearchOption) path =
        path |> exists
             |> function
                | true -> Some (Directory.EnumerateDirectories (path, pattern, depth))
                | false -> None
    let enumerateDirectoriesWithSearchDepth (depth:SearchOption) path = enumerateDirectoriesWithOptions "*" depth path
    let enumerateDirectories path = enumerateDirectoriesWithSearchDepth SearchOption.TopDirectoryOnly path