using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ChatKitCSharp.Messages;
using ChatKitCSharp.Sample;
using ChatKitCSharp.Commons;

namespace ChatKitCSharp
{
    [Activity(Label = "ChatActivity")]
    public class ChatActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Chat);
            MessagesListAdapter<Sample.Message> adapter = new MessagesListAdapter<Sample.Message>("1", new MyImageLoader());
            adapter.addToStart(new Sample.Message { CreatedAt = new Java.Util.Date(2017, 4, 12, 16, 6), Id = "100", Text = "Sample Text!!", User = new Author { Name = "Tim" } }, false);
            FindViewById<MessagesList>(Resource.Id.messagesList).SetAdapter<Sample.Message>(adapter);
        }

        public class MyImageLoader : ImageLoader
        {
            public void LoadImage(ImageView imageView, string url)
            {
                imageView.SetImageResource(Resource.Drawable.Icon);
            }
        }
    }
}