namespace JWTAspNet.DTO
{
    public class RefreshTokenRequestDto
    {

        public int UserID { get; set; }

        public required string RefreshToken { get; set; }
    }
}
