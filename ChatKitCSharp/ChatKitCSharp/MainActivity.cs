using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using ChatKitCSharp.Commons.Models;
using ChatKitCSharp.Sample;
using ChatKitCSharp.Dialogs;
using ChatKitCSharp.Commons;
using System;
using Java.Util;
using ChatKitCSharp.Utils;

namespace ChatKitCSharp
{
    [Activity(Label = "ChatKitCSharp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        List<IDialog<IMessage>> dialogs = new List<IDialog<IMessage>>();       

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            SampleData();
            DialogsListAdapter<IDialog<IMessage>> adapter = new DialogsListAdapter<IDialog<IMessage>>(Resource.Layout.item_dialog, new MyImageLoader());
            adapter.SetItems(dialogs);
            adapter.datesFormatter = new MyDateFormatter();
            FindViewById<DialogsList>(Resource.Id.dialogsList).SetAdapter<IDialog<IMessage>>(adapter);
            StartActivity(typeof(ChatActivity));
        }

        private void SampleData()
        {
            dialogs.Add(new DefaultDialog
            {
                DialogName = "Dialog1",
                Id = "1",
                LastMessage = new ChatKitCSharp.Sample.Message
                {
                    CreatedAt = new Date(2017, 4, 12, 6, 43),
                    Id = "1",
                    User = new Author
                    {
                        Name = "Ich :P",
                        Id = "1"
                    },
                    Text = "Message 1!!!!"
                },
                UnreadCount = 3,
                Users = new List<IUser>
                {

                    new Author
                    {
                        Id = "1",
                        Name = "Ich nochmal :P",

                    }
                }
            });
        }
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

