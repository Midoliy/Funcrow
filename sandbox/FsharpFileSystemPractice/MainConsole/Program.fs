open System
open System.Runtime.InteropServices
open System.IO
open MaybeComputation
open EitherComputation
open StateComputation
open System.Collections.Generic
open System.Runtime.CompilerServices
open System.Collections

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


let a : Either<exn, _> =
    either {
        let! ans = Right (6 / 3)
        return ans
    }

let b : Either<exn, _> =
    either {
        let! ans = a
        return ans + 50;
    }

let f = state { let! a = get
                do! put (a * 3)
                let! b = get
                do! put (b * 3)
                let! c = get
                do! put (c * 3)
                return (b, c) }

printfn "%A" (f 3)
printfn "%A" (evalState f 3)

let result : Either<exn, _> =
    either {
        let! ans = failwith "fail!!!"
        return 0
    }

result |> function
            | Right (r) -> printfn "%d" r
            | Left (l) -> printfn "%s" l.Message 

let f1 v = Some v

maybe {
    let! a9 = f1 20
    return a9
}
|> function
    | Some v -> printfn "%d" v
    | None -> printfn " --- "