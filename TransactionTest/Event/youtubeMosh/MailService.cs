using System;

namespace TransactionTest.Event.youtubeMosh
{
    public class MailService
    {
        public void OnVideoEncoded(object source, VideoEventArgs e)
        {
            Console.WriteLine("Mail Service: Sending an email..." + e.Video.Title);
        }
    }
}