namespace Funcrow.IO

open System.IO
open Funcrow.EitherComputation

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

    let deleteAll path = 
        deleteWithRecursive true path

    let delete path = 
        deleteWithRecursive false path

    let getFilesWithOptions pattern depth path =
        path |> exists
             |> function
                | true -> try Some (Directory.GetFiles (path, pattern, depth)) with _ -> None
                | false -> None

    let getFilesWithSearchDepth depth path = 
        getFilesWithOptions "*" depth path

    let getFiles path = 
        getFilesWithSearchDepth SearchOption.TopDirectoryOnly path

    let enumerateFilesWithOptions pattern depth path =
        path |> exists
             |> function
                | true -> try Some (Directory.EnumerateFiles (path, pattern, depth)) with _ -> None
                | false -> None

    let enumerateFilesWithSearchDepth depth path = 
        enumerateFilesWithOptions "*" depth path

    let enumerateFiles path = 
        enumerateFilesWithSearchDepth SearchOption.TopDirectoryOnly path

    let getDirectoriesWithOptions pattern depth path =
        path |> exists
             |> function
                | true -> try Some (Directory.GetDirectories (path, pattern, depth)) with _ -> None
                | false -> None

    let getDirectoriesWithSearchDepth depth path = 
        getDirectoriesWithOptions "*" depth path

    let getDirectories path = 
        getDirectoriesWithSearchDepth SearchOption.TopDirectoryOnly path

    let enumerateDirectoriesWithOptions pattern depth path =
        path |> exists
             |> function
                | true -> try Some (Directory.EnumerateDirectories (path, pattern, depth)) with _ -> None
                | false -> None

    let enumerateDirectoriesWithSearchDepth depth path = 
        enumerateDirectoriesWithOptions "*" depth path

    let enumerateDirectories path = 
        enumerateDirectoriesWithSearchDepth SearchOption.TopDirectoryOnly path

    let getCreationTime path = 
        path |> exists 
             |> function 
                | true -> try Some (Directory.GetCreationTime path) with _ -> None
                | false -> None

    let getCreationTimeUtc path = 
        path |> exists 
             |> function 
                | true -> try Some (Directory.GetCreationTimeUtc path) with _ -> None
                | false -> None

    let getCurrentDirectory = 
        try Some (Directory.GetCurrentDirectory) with _ -> None

    let getLastAccessTime path =
        path |> exists 
             |> function 
                | true -> try Some (Directory.GetLastAccessTime path) with _ -> None
                | false -> None

    let getLastAccessTimeUtc path =
        path |> exists 
             |> function 
                | true -> try Some (Directory.GetLastAccessTimeUtc path) with _ -> None
                | false -> None

    let getLastWriteTime path =
        path |> exists 
             |> function 
                | true -> try Some (Directory.GetLastWriteTime path) with _ -> None
                | false -> None

    let getLastWriteTimeUtc path =
        path |> exists 
             |> function 
                | true -> try Some (Directory.GetLastWriteTimeUtc path) with _ -> None
                | false -> None

    let getLogicalDrives =
        try Some (Directory.GetLogicalDrives) with _ -> None

    let getParent path =
        try Some (Directory.GetParent path) with _ -> None

    let move dstDirName srcDirName =
        try Right (Directory.Move (srcDirName, dstDirName)) with exn as e -> Left e

    let setCreationTime creationTime path =
        try Right (Directory.SetCreationTime (path, creationTime)) with exn as e -> Left e

    let setCreationTimeUtc creationTime path =
        try Right (Directory.SetCreationTimeUtc (path, creationTime)) with exn as e -> Left e

    let setCurrentDirectory path =
        try Right (Directory.SetCurrentDirectory path) with exn as e -> Left e

    let setLastAccessTime lastAccessTime path =
        try Right (Directory.SetCreationTime (path, lastAccessTime)) with exn as e -> Left e

    let setLastAccessTimeUtc lastAccessTime path =
        try Right (Directory.SetCreationTimeUtc (path, lastAccessTime)) with exn as e -> Left e

    let setLastWriteTime lastWriteTime path =
        try Right (Directory.SetCreationTime (path, lastWriteTime)) with exn as e -> Left e

    let setLastWriteTimeUtc lastWriteTimeUtc path =
        try Right (Directory.SetCreationTimeUtc (path, lastWriteTimeUtc)) with exn as e -> Left e