namespace GithubSearcherTest.Application.Search.Responses
{
    public class RemoteSearchQueryResponse
    {
        public string JsonResult { get; set; }

        public RemoteSearchQueryResponse(string jsonResult)
        {
            JsonResult = jsonResult;
        }
    }
}
