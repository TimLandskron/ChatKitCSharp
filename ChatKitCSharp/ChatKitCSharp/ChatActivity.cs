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
using ChatKitCSharp.Utils;
using Java.Util;

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
            MessagesListAdapter adapter = new MessagesListAdapter("1", new MyImageLoader());
            adapter.addToStart(new MessageData { CreatedAt = new Java.Util.Date(2017, 4, 12, 16, 6), Id = "100", Text = "Sample Text!!", User = new Author { Name = "Tim" }, Type = MessageData.DataType.Date }, false);
            adapter.DateHeadersFormatter = new MyDateFormatter();
            FindViewById<MessagesList>(Resource.Id.messagesList).SetAdapter(adapter);
        }

        public class MyImageLoader : ImageLoader
        {
            public void LoadImage(ImageView imageView, string url)
            {
                imageView.SetImageResource(Resource.Drawable.Icon);
            }
        }
        public class MyDateFormatter : DateFormatter.Formatter
        {
            public string Format(Date date)
            {
                if (DateFormatter.IsToday(date))
                {
                    return DateFormatter.Format(date, DateFormatter.Template.TIME);
                }
                else if (DateFormatter.IsYesterday(date))
                {
                    return "Yesterday";
                }
                else
                {
                    return DateFormatter.Format(date, DateFormatter.Template.STRING_DAY_MONTH_YEAR_TIME);
                }
            }
        }
    }
}