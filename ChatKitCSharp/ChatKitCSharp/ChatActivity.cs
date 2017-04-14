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
using static ChatKitCSharp.Messages.MessagesListAdapter;
using static ChatKitCSharp.Messages.MessageInput;

namespace ChatKitCSharp
{
    [Activity(Label = "ChatActivity")]
    public class ChatActivity : Activity, SelectionListener, OnLoadMoreListener, OnMessageClickListener, OnMessageLongClickListener, InputListener, AttachmentsListener
    {
        private const int TOTAL_MESSAGE_COUNT = 100;
        private List<MessageData> list;
        private Date lastLoadedDate;
        private int selectionCount;
        MessagesListAdapter adapter;
        private string myId;
        private string friendId;

        public void onLoadMore(int page, int totalItemsCount)
        {
            if (totalItemsCount < TOTAL_MESSAGE_COUNT)
            {
                LoadMessages();
            }
        }

        protected void LoadMessages()
        {
            // Get messages from lastLoadedDate from VM
            // adapter.addToEnd(messages, true)
        }

        public void onSelectionChanged(int count)
        {
            this.selectionCount = count;

        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Chat);

            myId = Intent.GetStringExtra("my_id");
            friendId = Intent.GetStringExtra("sender_id");

            adapter = new MessagesListAdapter(myId, new MyImageLoader());
           // adapter.addToStart(new MessageData { CreatedAt = new Java.Util.Date(2017, 4, 12, 16, 6), Id = "100", Text = "Hello from ChatKitCSharp! You're welcome.", User = new Author { Name = "Tim", Avatar = "@drawable/icon" }, Type = MessageData.DataType.Message }, false);
            adapter.DateHeadersFormatter = new MyDateFormatter();
            GenerateSampleMessages();
            adapter.addToEnd(list, true);
            adapter.setOnMessageClickListener(this);
            adapter.setOnMessageLongClickListener(this);
            adapter.enableSelectionMode(this);
            
            FindViewById<MessagesList>(Resource.Id.messagesList).SetAdapter(adapter);
            FindViewById<MessageInput>(Resource.Id.input).SetInputListener(this);
            lastLoadedDate = list[0].CreatedAt;
        }

        public override void OnBackPressed()
        {
            if (selectionCount == 0)
            {
                base.OnBackPressed();
            }
            else
            {
                adapter.unselectAllItems();
            }
        }

        private void GenerateSampleMessages()
        {
            list = new List<MessageData>() {
                new MessageData()
                {
                    CreatedAt = new Date(2017 - 1900, 4, 1, 4, 23),
                    Text = "This is a sample message Nr. 1",
                    Id = friendId,
                    User = new Author
                    {
                        Name = "Tim",
                        Avatar = "@drawable/icon",
                        Id = "1"
                    },
                    Type = MessageData.DataType.Message
                },
                new MessageData()
                {
                    CreatedAt = new Date(2017- 1900, 4, 2, 4, 52),
                    Text = "This is a sample message Nr. 2",
                    Id = friendId,
                    User = new Author
                    {
                        Name = "Tim",
                        Avatar = "@drawable/icon",
                        Id = "1"
                    },
                    Type = MessageData.DataType.Message
                },new MessageData()
                {
                    CreatedAt = new Date(2017- 1900, 4, 3, 4, 52),
                    Text = "This is a sample message Nr. 3",
                    Id = myId,
                    User = new Author
                    {
                        Name = "Tim",
                        Avatar = "@drawable/icon",
                        Id = "1"
                    },
                    Type = MessageData.DataType.Message
                },new MessageData()
                {
                    CreatedAt = new Date(2017- 1900, 4, 4, 4, 52),
                    Text = "This is a sample message Nr. 4",
                    Id = friendId,
                    User = new Author
                    {
                        Name = "Tim",
                        Avatar = "@drawable/icon",
                        Id = "1"
                    },
                    Type = MessageData.DataType.Message
                },new MessageData()
                {
                    CreatedAt = new Date(2017- 1900, 4, 5, 4, 52),
                    Text = "This is a sample message Nr. 5",
                    Id = myId,
                    User = new Author
                    {
                        Name = "Tim",
                        Avatar = "@drawable/icon",
                        Id = "1"
                    },
                    Type = MessageData.DataType.Message
                }
            };
        }

        public void onMessageLongClick(MessageData message)
        {
        }

        public void onMessageClick(MessageData message)
        {
        }

        public void OnAddAttachments()
        {

        }

        public bool OnSubmit(string input)
        {
            adapter.addToStart(new MessageData { CreatedAt = new Date(), Id = myId, Text = input, Type = MessageData.DataType.Message, User = new Author { Avatar = "@drawable/icon"} }, true);
            return true;
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