using MimeKit;
using MailKit.Net.Smtp;

namespace testMail
{
    public class Correo
    {
        public void EnvMail(string destino, string asunto, string cuerpo)
        {
            var Mens = new MimeMessage();

            // Configurar remitente
            Mens.From.Add(new MailboxAddress("NO-REPLY@barpinguinospa.com", "barpinguinospa@gmail.com"));

            // Configurar destinatario
            Mens.To.Add(new MailboxAddress("", destino));

            // Configurar asunto
            Mens.Subject = asunto;

            // Cuerpo del mensaje
            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = cuerpo
            };
            Mens.Body = bodyBuilder.ToMessageBody();

            // Configuración y envío del correo
            using (var cliente = new SmtpClient())
            {
                try
                {
                    cliente.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    cliente.Authenticate("barpinguinospa@gmail.com", "viqr qiel tynv ndlo");
                    cliente.Send(Mens);
                }
                catch (Exception ex)
                {
                    // Manejar errores
                    Console.WriteLine($"Error al enviar correo: {ex.Message}");
                    throw;
                }
                finally
                {
                    cliente.Disconnect(true);
                }
            }
        }
    }
}
