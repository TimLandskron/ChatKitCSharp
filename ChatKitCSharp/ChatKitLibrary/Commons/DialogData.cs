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
using ChatKitLibrary.Commons.Models;

namespace ChatKitLibrary.Commons
{
    public class DialogData : IDialog
    {
        public string Id { get; set; }

        public string DialogPhoto { get; set; }

        public string DialogName { get; set; }

        public List<IUser> Users { get; set; }

        public MessageData LastMessage { get; set; }

        public int UnreadCount { get; set; }
    }
}