module MaybeComputation
    type public MaybeBuilder () =
        member __.Bind (opt, expr) = Option.bind expr opt
        member __.Return (x) = Some (x)
        member __.Delay (f) : option<_> = f ()

    let public maybe = MaybeBuilder ()
