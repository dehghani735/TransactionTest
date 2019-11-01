using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TransactionTest.Event.youtubeMosh
{
  public class VideoEventArgs : EventArgs
  {
    public Video Video { get; set; }
  }

  public class VideoEncoder
  {
    // 1- Define a delegate
    // 2- Define an event based on that delegate
    // 3- Raise the event

    //public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);  // name of Event is 'VideoEncoded' plus 'EventHandler'
    //public event VideoEncodedEventHandler VideoEncoded;

    // instead of two lines above, .NET propose the new way below
    // EventHandler
    // EventHandler<TEventArgs>

    public event EventHandler<VideoEventArgs> VideoEncoded;
    // if there is no args then
    // public event EventHandler VideoEncoded;

    public void Encode(Video video)
    {
      Console.WriteLine("Encoding Video...");
      Thread.Sleep(3000);

      OnVideoEncoded(video);
    }

    // the publisher method
    protected virtual void OnVideoEncoded(Video video)
    {
      if (VideoEncoded != null)
      {
        VideoEncoded(this, new VideoEventArgs() { Video = video}); // was EventArgs.Empty
      }

    }
  }
}
