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
using ChatKitCSharp.Commons.Models;
using Java.Util;

namespace ChatKitCSharp.Sample
{
    public class Message : IMessage
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public IUser User { get; set; }

        public Date CreatedAt { get; set; }
    }
}