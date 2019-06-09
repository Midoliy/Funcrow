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
                | true -> Right (DirectoryInfo (path))
                | false -> try Right (Directory.CreateDirectory path) with exn as e -> Left e
    let deleteWithRecursive recursive path =
        path |> exists
             |> function
                | true -> try Directory.Delete (path, recursive); Right true with exn as e -> Left e
                | false -> Right true 
    let deleteAll path = deleteWithRecursive true path
    let delete path = deleteWithRecursive false path
    let getFilesWithOptions pattern (depth:SearchOption) path =
        path |> exists
             |> function
                | true -> try Right (Directory.GetFiles (path, pattern, depth)) with exn as e -> Left e
                | false -> Left (Exception "")
    let getFilesWithSearchDepth (depth:SearchOption) path = getFilesWithOptions "*" depth path
    let getFiles path = getFilesWithSearchDepth SearchOption.TopDirectoryOnly path
    let enumerateFilesWithOptions pattern (depth:SearchOption) path =
        path |> exists
             |> function
                | true -> try Right (Directory.EnumerateFiles (path, pattern, depth)) with exn as e -> Left e
                | false -> Left (Exception "")
    let enumerateFilesWithSearchDepth (depth:SearchOption) path = enumerateFilesWithOptions "*" depth path
    let enumerateFiles path = enumerateFilesWithSearchDepth SearchOption.TopDirectoryOnly path
    let getDirectoriesWithOptions pattern (depth:SearchOption) path =
        path |> exists
             |> function
                | true -> try Right (Directory.GetDirectories (path, pattern, depth)) with exn as e -> Left e
                | false -> Left (Exception "")
    let getDirectoriesWithSearchDepth (depth:SearchOption) path = getDirectoriesWithOptions "*" depth path
    let getDirectories path = getDirectoriesWithSearchDepth SearchOption.TopDirectoryOnly path
    let enumerateDirectoriesWithOptions pattern (depth:SearchOption) path =
        path |> exists
             |> function
                | true -> try Right (Directory.EnumerateDirectories (path, pattern, depth)) with exn as e -> Left e
                | false -> Left (Exception "")
    let enumerateDirectoriesWithSearchDepth (depth:SearchOption) path = enumerateDirectoriesWithOptions "*" depth path
    let enumerateDirectories path = enumerateDirectoriesWithSearchDepth SearchOption.TopDirectoryOnly path