namespace TicketBooking.Email
{
    public interface IEmailSender
    {
        Task SendConfirmationAsync(Message message);
    }
}
