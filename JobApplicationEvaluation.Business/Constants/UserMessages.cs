namespace JobApplicationEvaluation.Business.Constants
{
    public static class UserMessages
    {
        public const string UserNotFoundError  = "Kullanıcı bulunamadı";
        public const string LoginFailed  = "Giriş başarısız. Lütfen kullanıcı adı ve şifrenizi kontrol edin.";
        public const string LoginSuccessful  = "Giriş başarılı. Hoş geldiniz!";
        public const string UserAlreadyExists  = "Bu email adresi zaten kayıtlı.";
        public const string UserCreated  = "Kullanıcı başarıyla oluşturuldu";
        public const string UserUnexpectedError  = "Kullanıcı işlemi sırasında beklenmeyen bir hata oluştu";
        public const string UserSuccessfullyFetched  = "Kullanıcı başarılı bir şekilde getirildi";
    }
}
