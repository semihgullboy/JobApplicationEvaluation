namespace JobApplicationEvaluation.Business.Constants
{
    public static class UserMessages
    {
        public static string UserNotFoundError { get; } = "Kullanıcı bulunamadı";
        public static string LoginFailed { get; } = "Giriş başarısız. Lütfen kullanıcı adı ve şifrenizi kontrol edin.";
        public static string LoginSuccessful { get; } = "Giriş başarılı. Hoş geldiniz!";
        public static string UserAlreadyExists { get; } = "Bu email adresi zaten kayıtlı.";
        public static string UserCreated { get; } = "Kullanıcı başarıyla oluşturuldu";
    }
}
