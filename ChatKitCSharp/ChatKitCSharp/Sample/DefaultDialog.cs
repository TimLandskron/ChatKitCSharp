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

namespace ChatKitCSharp.Sample
{
    public class DefaultDialog : IDialog<IMessage>
    {
        public string Id { get; set; }

        public string DialogPhoto { get; set; }

        public string DialogName { get; set; }

        public List<IUser> Users { get; set; }

        public IMessage LastMessage { get; set; }

        public int UnreadCount { get; set; }
    }
}