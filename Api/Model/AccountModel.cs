namespace Api.Model
{
    public class AccountModel
    {
        public AccountModel()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id{ get; set; }
        public string Name{ get; set; }
        public string Description { get; set; }
    }
}
