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

namespace ChatKitCSharp.Commons
{
    public abstract class ViewHolder<DATA> : RecyclerView.ViewHolder
    {
        public abstract void OnBind(DATA data);
        public ViewHolder(View itemView) : base(itemView) { }
    }
}