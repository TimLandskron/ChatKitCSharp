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
    public interface IDialog<MESSAGE> where MESSAGE : IMessage
    {
        string Id { get; }
        string DialogPhoto { get; }
        string DialogName { get; }
        List<IUser> Users { get; }
        MESSAGE LastMessage { get; set; }
        int UnreadCount { get; }
    }
}