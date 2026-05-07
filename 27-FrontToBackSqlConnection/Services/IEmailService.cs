namespace _27_FrontToBackSqlConnection.Services
{
    public interface IEmailService
    {
        string OffEmail { get; set; }

        public void SendEmail();

    }
}
