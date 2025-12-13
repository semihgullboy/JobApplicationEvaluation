namespace JobApplicationEvaluation.Business.Constants
{
    public static class RecourseMessages
    {
        public static string RecourseCreated { get; } = "Kayıt başarılı bir şekilde oluşturuldu.";
        public static string RecourseCreationError { get; } = "Kayıt oluşturulurken bir hata oluştu.";
        public static string RecourseUpdated { get; } = "Kayıt başarılı bir şekilde güncellendi.";
        public static string RecourseUpdateError { get; } = "Kayıt güncellenirken bir hata oluştu.";
        public static string RecourseNotFound { get; } = "Herhangi bir kayıt bulunamadı.";
        public static string UnauthorizedUpdate { get; } = "Bu kaydı güncelleme yetkiniz bulunmamaktadır.";
        public static string UnauthorizedDelete { get; } = "Bu kaydı silme yetkiniz bulunmamaktadır.";
        public static string RecourseDeleted { get; } = "Kayıt başarılı bir şekilde silindi.";
        public static string RecourseDeleteError { get; } = "Kayıt silinirken bir hata oluştu.";

    }
}
