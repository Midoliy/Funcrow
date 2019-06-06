module StateComputation
    let private ret x = fun s -> (x, s)
    let private (>>=) m f = fun s -> let (x, s') = m s
                                     f x s'

    type StateBuilder () =
        member __.Bind (m, f) = m >>= f
        member __.Return (x) = ret x

    let state = StateBuilder ()
    let evalState m s = fst (m s)
    let get = fun s -> (s, s)
    let put s = fun _ -> ((), s)
