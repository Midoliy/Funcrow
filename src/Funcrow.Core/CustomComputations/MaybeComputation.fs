namespace Funcrow.Core

module MaybeComputation =
    type MaybeBuilder () =
        member __.Bind (opt, expr) = Option.bind
        member __.Return (x) = Some (x)
        member __.Delay (f) : option<_> = f ()

    let option = MaybeBuilder ()