namespace Client.Models
{
    public class ResponseAccountModel
    {
        public List<AccountModel> data { get; set; }
        public List<string> erros { get; set; }
    }
}
