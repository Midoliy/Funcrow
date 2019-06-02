module EitherComputation
    type Either<'L, 'R> = Left of 'L | Right of 'R

    type EitherBuilder () =
        member __.Bind (either, expr) =
            either
            |> function
                | Right v -> expr v
                | Left s -> Left s
        member __.Return (x) = Right x
        member __.Delay (f) : Either<'L, _> =
            if typeof<exn>.IsAssignableFrom (typeof<'L>) then
                try f () with ex ->
                    let catching = typeof<'L>.IsAssignableFrom (ex.GetType())
                    if catching then Left (unbox<'L> (box ex)) else reraise ()
            else
                f ()

    let either = EitherBuilder ()
