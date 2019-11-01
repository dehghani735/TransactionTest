using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionTest.Event.youtubeMosh
{
  class Program
  {
    static void Main(string [] args)
    {
      var video = new Video() { Title = "Video 1"};
      var videoEncoder = new VideoEncoder(); // publisher
      var mailService = new MailService(); // subscriber
      var messageService = new MessageService(); // subscriber

      videoEncoder.VideoEncoded += mailService.OnVideoEncoded; // subscribe to the event
      // videoEncoder.VideoEncoded is a list of pointers to methods. when the videoEncoder wants to publish that event (VideoEncoded), it looks at that list ( with if VideoEncoded != null)
      // and when it is not empty it means that someone is subscribing to that event, which means it has pointer to event handler, and then we call it;
      // mailService.OnVideoEncoded this is a reference or pointer to that method
      videoEncoder.VideoEncoded += messageService.OnVideoEncoded;

      // then we call this method
      videoEncoder.Encode(video);
      
    }
  }
}
