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
using Java.Util;
using ChatKitLibrary.Commons.Models;

namespace ChatKitLibrary.Commons
{
    public class MessageData : IMessage
    {
        public DataType Type { get; set; }
        public string Id { get; set; }

        public string Text { get; set; }

        public IUser User { get; set; }

        public Date CreatedAt { get; set; }
        public string ImageUrl { get; set; }

        public enum DataType
        {
            Message = 1,
            Date = 2,
            Image = 3
        }
    }
}