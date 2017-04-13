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

namespace ChatKitCSharp.Commons.Models
{
    public interface IDialog
    {
        string Id { get; }
        string DialogPhoto { get; }
        string DialogName { get; }
        List<IUser> Users { get; }
        MessageData LastMessage { get; set; }
        int UnreadCount { get; }
    }
}