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
using Android.Support.V7.Widget;
using ChatKitLibrary.Commons.Models;

namespace ChatKitLibrary.Commons
{
    public abstract class DialogViewHolder : RecyclerView.ViewHolder
    {
        public abstract void OnBind(IDialog data);
        public DialogViewHolder(View itemView) : base(itemView) { }
    }
}