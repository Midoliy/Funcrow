namespace Funcrow.Net

module Http =
    open System.Net.Http

    let getAsync (uri:string) = async {
        use client = new HttpClient ()
        let! response = client.GetAsync (uri) |> Async.AwaitTask
        return response }

    let postAsync content (uri:string) = async {
        use client = new HttpClient ()
        let! response = client.PostAsync (uri, content) |> Async.AwaitTask
        return response }