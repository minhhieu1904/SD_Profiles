namespace API.Helpers.Params
{
    public class UserForLoginParam
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public bool RememberMe { get; set; }
    }
}