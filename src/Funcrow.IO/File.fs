namespace Funcrow.IO

module File =
    open System.IO
    open System.Text
    open Funcrow.EitherComputation

    let exists path = File.Exists path
    
    let appendAllLinesWith encoding contents path =
        path
        |> exists
        |> function
           | true -> either { return File.AppendAllLines (path, contents, encoding) }
           | false -> Left (exn ("File not found. [" + path + "]"))

    let appendAllLines contents path  =
        appendAllLinesWith Encoding.UTF8 contents path
           
    let appendAllTextWith encoding contents path = 
        path
        |> exists
        |> function
           | true -> either { return File.AppendAllText (path, contents, encoding) }
           | false -> Left (exn ("File not found. [" + path + "]"))

    let appendAllText contents path =
        appendAllTextWith Encoding.UTF8 contents path

    let appendText path = 
        path
        |> exists
        |> function
           | true -> either { return File.AppendText path }
           | false -> Left (exn ("File not found. [" + path + "]"))
    
    let copyWith overwrite src dst = 
        src
        |> exists
        |> function
           | true -> dst
                     |> exists
                     |> function
                        | true -> Left(exn ("File exists already. [" + dst + "]"))
                        | false -> either { return File.Copy (src, dst, overwrite) }
           | false -> Left (exn ("File not found. [" + src + "]"))

    let copy src dst =
        copyWith false src dst 
        
    let createWithOpt options bufferSize path : Either<exn,_> =
        either { return File.Create (path, bufferSize, options) }

    let createWith bufferSize path : Either<exn,_> =
        either { return File.Create (path, bufferSize) }

    let create path =
        createWith 4096 path

    let createText path : Either<exn,_> =
        either { return File.CreateText path }

    let decrypt path : Either<exn,_> = 
        either { return File.Decrypt path }

    let delete path : Either<exn,_> = 
        either { return File.Delete path }

    let encrypt path : Either<exn,_> = 
        either { return File.Encrypt path }

    let getAttributes path : Either<exn,_> = 
        either { return File.GetAttributes path }

    let getCreationTime path : Either<exn,_> = 
        either { return File.GetCreationTime path }

    let getCreationTimeUtc path : Either<exn,_> = 
        either { return File.GetCreationTimeUtc path }

    let getLastAccessTime path : Either<exn,_> = 
        either { return File.GetLastAccessTime path }

    let getLastAccessTimeUtc path : Either<exn,_> = 
        either { return File.GetLastAccessTimeUtc path }

    let getLastWriteTime path : Either<exn,_> = 
        either { return File.GetLastWriteTime path }

    let getLastWriteTimeUtc path : Either<exn,_> = 
        either { return File.GetLastWriteTimeUtc path }
        
    let move dst src : Either<exn,_> = 
        src
        |> exists
        |> function
           | true -> dst
                     |> exists
                     |> function
                        | true -> Left(exn ("File exists already. [" + dst + "]"))
                        | false -> either { return File.Move (src, dst) }
           | false -> Left (exn ("File not found. [" + src + "]"))
           
