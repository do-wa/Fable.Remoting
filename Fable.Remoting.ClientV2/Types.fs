namespace Fable.Remoting.Client 

type HttpMethod = GET | POST 

type RequestBody = 
    | Empty
    | Json of string 
    | Binary of byte[] 

type HttpRequest = {
    HttpMethod: HttpMethod
    Url: string 
    Headers: (string * string) list  
    RequestBody : RequestBody 
}
 
type HttpResponse = {
    StatusCode: int 
    ResponseBody: string
}

type RemoteBuilderOptions = {
    CustomHeaders : (string * string) list
    BaseUrl  : string option
    Authorization : string option
    RouteBuilder : (string -> string -> string)
    IsBinary : bool
}

type ProxyRequestException(response: HttpResponse, errorMsg, reponseText: string) = 
    inherit System.Exception(errorMsg)
    member this.Response = response 
    member this.StatusCode = response.StatusCode
    member this.ResponseText = reponseText 