namespace _27_FrontToBackSqlConnection.Services
{
    public class EmailService : IEmailService
    {
        public string OffEmail { get; set; }

        public EmailService()
        {
            throw new Exception();
        }
        public void SendEmail()
        {
            Console.WriteLine("Send");
        }
    }
}
