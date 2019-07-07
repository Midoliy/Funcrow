namespace Funcrow.IO

open System.IO
open Funcrow.EitherComputation

module File =
    let appendAllLines contents path = File.AppendAllLines (path, contents)

    let appendAllLinesWith encoding contents path = File.AppendAllLines (path, contents, encoding)

    let appendAllText contents path = File.AppendAllText (path, contents)

    let appendAllTextWith encoding contents path = File.AppendAllText (path, contents, encoding)

    let appendText path = File.AppendText path

    let copy src dst = File.Copy (src, dst)
    
    let copyWith overwrite src dst = File.Copy (src, dst, overwrite)

    let create path = File.Create path

    let createWith bufferSize path = File.Create (path, bufferSize)

    let createWithOpt options bufferSize path = File.Create (path, bufferSize, options)

    let createText path = File.CreateText path

    let decrypt path = File.Decrypt path

    let delete path = File.Delete path

    let encrypt path = File.Encrypt path

    let exists path = File.Exists path

    let getAttributes path = File.GetAttributes path

    let getCreationTime path = File.GetCreationTime path

    let getCreationTimeUtc path = File.GetCreationTimeUtc path

    let getLastAccessTime path = File.GetLastAccessTime path

    let getLastAccessTimeUtc path = File.GetLastAccessTimeUtc path

    let getLastWriteTime path = File.GetLastWriteTime path

    let getLastWriteTimeUtc path = File.GetLastWriteTimeUtc path

    let move dst src = File.Move (src, dst)

