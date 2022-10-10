namespace GithubSearcherTest.Application.Search.Responses
{
    public class FindQueryResponse
    {
        public string JsonResult { get; set; }

        public FindQueryResponse(string jsonResult)
        {
            JsonResult = jsonResult;
        }
    }
}
