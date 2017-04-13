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
using ChatKitCSharp.Commons.Models;

namespace ChatKitCSharp.Dialogs
{
    public class DialogsList : RecyclerView
    {
        private DialogListStyle dialogStyle;

        public DialogsList(Context context) : base(context) { }

        public DialogsList(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            ParseStyle(context, attrs);
        }

        public DialogsList(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
            ParseStyle(context, attrs);
        }

        protected override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();

            LinearLayoutManager layout = new LinearLayoutManager(Context, LinearLayoutManager.Vertical, false);
            SimpleItemAnimator animator = new DefaultItemAnimator();

            SetLayoutManager(layout);
            SetItemAnimator(animator);
        }

        public override void SetAdapter(Adapter adapter)
        {
            base.SetAdapter(adapter);
        }

        public void SetAdapter<DIALOG>(DialogsListAdapter<DIALOG> adapter) where DIALOG : IDialog<IMessage>
        {
            SimpleItemAnimator itemAnimator = new DefaultItemAnimator();
            itemAnimator.SupportsChangeAnimations = false;

            LinearLayoutManager layoutManager = new LinearLayoutManager(Context, LinearLayoutManager.Vertical, true);

            SetItemAnimator(itemAnimator);
            SetLayoutManager(layoutManager);

            adapter.DialogStyle = dialogStyle;
            
            base.SetAdapter(adapter);
        }

        private void ParseStyle(Context context, IAttributeSet attrs)
        {
            dialogStyle = DialogListStyle.Parse(context, attrs);
        }
    }
}