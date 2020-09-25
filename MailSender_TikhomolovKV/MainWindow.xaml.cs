using System;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace MailSender_TikhomolovKV
{
    public partial class MainWindow
    {
        public MainWindow() => InitializeComponent();

        private void btnSend_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var to = new MailAddress(txbReceiverAddress.Text);      //кому отправляем
            var from = new MailAddress(txbLogin.Text, "Робот");     //от кого отправляем

            var message = new MailMessage(from, to);    //создаем почтовое отправление

            message.Subject = txbTopic.Text;            //тема письма
            message.Body = txbLetterText.Text;          //текст письма

            //создаем клиента SMTP почты, через который будет отправляться почта
            //var client = new SmtpClient("smtp.mail.ru", 465);
            var client = new SmtpClient("smtp.yandex.ru", 25);
            client.EnableSsl = true;

            //указываем учетные данные почты клиента
            client.Credentials = new NetworkCredential
            {
                UserName = txbLogin.Text,
                SecurePassword = txbPassword.SecurePassword
            };

            //отправляем сообщение
            client.Send(message);
            MessageBox.Show("Ура, письмо отправлено!");
        }
    }
}
