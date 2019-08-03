namespace Funcrow.IO

open System.IO
open Funcrow.EitherComputation

module Directory =
    let exists = Directory.Exists

    let create path : Either<exn, _> =
        if exists path then Right (DirectoryInfo path)
                       else either { return Directory.CreateDirectory path }

    let deleteWithRecursive recursive path : Either<exn, _> =
        if exists path then either { return Directory.Delete (path, recursive) }
                       else Right ()

    let deleteAll path = 
        deleteWithRecursive true path

    let delete path = 
        deleteWithRecursive false path

    let getFilesWithOptions pattern depth path =
        if exists path then try Some (Directory.GetFiles (path, pattern, depth)) with _ -> None
                       else None

    let getFilesWithSearchDepth depth path = 
        getFilesWithOptions "*" depth path

    let getFiles path = 
        getFilesWithSearchDepth SearchOption.TopDirectoryOnly path

    let enumerateFilesWithOptions pattern depth path =
        if exists path then try Some (Directory.EnumerateFiles (path, pattern, depth)) with _ -> None
                       else None

    let enumerateFilesWithSearchDepth depth path = 
        enumerateFilesWithOptions "*" depth path

    let enumerateFiles path = 
        enumerateFilesWithSearchDepth SearchOption.TopDirectoryOnly path

    let getDirectoriesWithOptions pattern depth path =
        if exists path then try Some (Directory.GetDirectories (path, pattern, depth)) with _ -> None
                       else None

    let getDirectoriesWithSearchDepth depth path = 
        getDirectoriesWithOptions "*" depth path

    let getDirectories path = 
        getDirectoriesWithSearchDepth SearchOption.TopDirectoryOnly path

    let enumerateDirectoriesWithOptions pattern depth path =
        if exists path then try Some (Directory.EnumerateDirectories (path, pattern, depth)) with _ -> None
                       else None

    let enumerateDirectoriesWithSearchDepth depth path = 
        enumerateDirectoriesWithOptions "*" depth path

    let enumerateDirectories path = 
        enumerateDirectoriesWithSearchDepth SearchOption.TopDirectoryOnly path

    let getCreationTime path =
        if exists path then try Some (Directory.GetCreationTime path) with _ -> None
                       else None

    let getCreationTimeUtc path =
        if exists path then try Some (Directory.GetCreationTimeUtc path) with _ -> None
                       else None

    let getCurrentDirectory = 
        try Some (Directory.GetCurrentDirectory) with _ -> None

    let getLastAccessTime path =
        if exists path then try Some (Directory.GetLastAccessTime path) with _ -> None
                       else None

    let getLastAccessTimeUtc path =
        if exists path then try Some (Directory.GetLastAccessTimeUtc path) with _ -> None
                       else None

    let getLastWriteTime path =
        if exists path then try Some (Directory.GetLastWriteTime path) with _ -> None
                       else None

    let getLastWriteTimeUtc path =
        if exists path then try Some (Directory.GetLastWriteTimeUtc path) with _ -> None
                       else None

    let getLogicalDrives =
        try Some (Directory.GetLogicalDrives) with _ -> None

    let getParent path =
        try Some (Directory.GetParent path) with _ -> None

    let move dstDirName srcDirName : Either<exn, _> =
        either { return Directory.Move (srcDirName, dstDirName) }

    let setCreationTime creationTime path : Either<exn, _> =
        either { return Directory.SetCreationTime (path, creationTime) }

    let setCreationTimeUtc creationTime path : Either<exn, _> =
        either { return Directory.SetCreationTimeUtc (path, creationTime) }

    let setCurrentDirectory path : Either<exn, _> =
        either { return Directory.SetCurrentDirectory path }

    let setLastAccessTime lastAccessTime path : Either<exn, _> =
        either { return Directory.SetCreationTime (path, lastAccessTime) }

    let setLastAccessTimeUtc lastAccessTime path : Either<exn, _> =
        either { return Directory.SetCreationTimeUtc (path, lastAccessTime) }

    let setLastWriteTime lastWriteTime path : Either<exn, _> =
        either { return Directory.SetCreationTime (path, lastWriteTime) }

    let setLastWriteTimeUtc lastWriteTimeUtc path : Either<exn, _> =
        either { return Directory.SetCreationTimeUtc (path, lastWriteTimeUtc) }
