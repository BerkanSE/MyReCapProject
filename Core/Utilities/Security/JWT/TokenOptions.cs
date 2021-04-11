namespace Core.Utilities.Security.JWT
{
    public class TokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; } //İmzalayan
        public int AccessTokenExpiration { get; set; } 
        //Dakika cinsinden o yüzden int
        public string SecurityKey { get; set; }
    }
    //WebAPI -> appsetting.json 'ın içerisinde tutulur
    //fakat nesne olarak map edip daha sonra nesnel bir şekilde kullanmaya yarar.

}
