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
using Android.Util;

namespace ChatKitLibrary.Messages
{
    public class MessagesList : RecyclerView
    {
        private MessagesListStyle messagesListStyle;

        public MessagesList(Context context) : base(context)
        {
        }

        public MessagesList(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            ParseStyle(context, attrs);
        }

        public MessagesList(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
            ParseStyle(context, attrs);
        }

        //public override void SetAdapter(Adapter adapter)
        //{
        //    base.SetAdapter(adapter);
        //}

        public void SetAdapter(MessagesListAdapter adapter)
        {
            SimpleItemAnimator itemAnimator = new DefaultItemAnimator();
            itemAnimator.SupportsChangeAnimations = false;

            LinearLayoutManager layoutManager = new LinearLayoutManager(Context, LinearLayoutManager.Vertical, true);

            SetItemAnimator(itemAnimator);
            SetLayoutManager(layoutManager);
            adapter.LayoutManager = layoutManager;
            adapter.Style = messagesListStyle;

            AddOnScrollListener(new RecyclerScrollMoreListener(layoutManager, adapter));

            base.SetAdapter(adapter);
        }

        private void ParseStyle(Context context, IAttributeSet attrs)
        {
            messagesListStyle = MessagesListStyle.Parse(context, attrs);
        }
    }
}