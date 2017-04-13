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
using Android.Support.V7.Widget;
using ChatKitCSharp.Commons;
using ChatKitCSharp.Utils;
using Android.Util;
using Android.Graphics;
using Android.Graphics.Drawables;
using Java.Util;

namespace ChatKitCSharp.Dialogs
{
    public class DialogsListAdapter<DIALOG> : RecyclerView.Adapter where DIALOG : IDialog<IMessage>
    {
        private List<DIALOG> items = new List<DIALOG>();
        private int itemLayoutId;
        private DialogViewHolder<DIALOG> holderClass;
        public ImageLoader imageLoader { get; set; }
        public OnDialogClickListener<DIALOG> onDialogClickListener { get; set; }
        public OnDialogLongClickListener<DIALOG> onDialogLongClickListener { get; set; }
        public  DialogListStyle DialogStyle { get; set; }
        public DateFormatter.Formatter datesFormatter { get; set; }

        public DialogsListAdapter(ImageLoader imageLoader)
        {
            //SetAttributes(Resource.Layout.item_dialog, , imageLoader);
            this.imageLoader = imageLoader;
        }

        public DialogsListAdapter(int itemLayoutId, ImageLoader imageLoader)
        {
            this.itemLayoutId = itemLayoutId;
            this.imageLoader = imageLoader;
        }

        public DialogsListAdapter(int itemLayoutId, DialogViewHolder<DIALOG> holderClass, ImageLoader imageLoader)
        {
            this.itemLayoutId = itemLayoutId;
            this.holderClass = holderClass;
            this.imageLoader = imageLoader;
        }

        public void SetAttributes(int itemLayoutId, DialogViewHolder<DIALOG> holderClass, ImageLoader imageLoader)
        {
            this.itemLayoutId = itemLayoutId;
            this.holderClass = holderClass;
            this.imageLoader = imageLoader;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            OnBindViewHolder(holder as BaseDialogViewHolder<DIALOG>, position);
        }

        public void OnBindViewHolder(BaseDialogViewHolder<DIALOG> holder, int position)
        {
            holder.SetImageLoader(imageLoader);
            holder.SetOnDialogClickListener(onDialogClickListener);
            holder.SetOnDialogLongClickListener(onDialogLongClickListener);
            holder.SetDatesFormatter(datesFormatter);
            holder.OnBind(items.ElementAt(position));
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            return OnCreateViewHolder(parent, viewType, true);
        }

        public BaseDialogViewHolder<DIALOG> OnCreateViewHolder(ViewGroup parent, int viewType, bool b)
        {
            View v = LayoutInflater.From(parent.Context).Inflate(itemLayoutId, parent, false);
            var holder = new DialogViewHolder<DIALOG>(v);
            holder.DialogStyle = DialogStyle;
            return holder;
        }

        public override int ItemCount => items.Count;

        public void DeleteById(string id)
        {
            var index = items.IndexOf(items.First(i => i.Id == id));
            items.RemoveAt(index);
            NotifyItemRemoved(index);
        }

        public bool IsEmpty => items.Count == 0;

        public void Clear()
        {
            if (items != null)
            {
                items.Clear();
            }
            NotifyDataSetChanged();
        }

        public void SetItems(List<DIALOG> items)
        {
            this.items = items;
            NotifyDataSetChanged();
        }

        public void AddItems(List<DIALOG> newItems)
        {
            if (newItems != null)
            {
                if (items == null)
                {
                    items = new List<DIALOG>();
                }
                int curSize = items.Count;
                items.AddRange(newItems);
                NotifyItemRangeInserted(curSize, items.Count);
            }
        }

        public void AddItem(int position, DIALOG dialog)
        {
            items.Insert(position, dialog);
            NotifyItemInserted(position);
        }

        public void UpdateItem(int position, DIALOG item)
        {
            if (items == null)
            {
                items = new List<DIALOG>();
            }
            items.RemoveAt(position);
            items.Insert(position, item);
            NotifyItemChanged(position);
        }

        public void UpdateItemById(DIALOG item)
        {
            if (items == null)
            {
                items = new List<DIALOG>();
            }
            var index = items.IndexOf(items.First(i => i.Id == item.Id));
            items.RemoveAt(index);
            items.Insert(index, item);
            NotifyItemChanged(index);
        }

        public bool UpdateDialogWithMessage(string dialogId, IMessage message)
        {
            bool dialogExist = false;
            for (int i = 0; i < items.Count; i++)
            {
                if (items.ElementAt(i).Id.Equals(dialogId))
                {
                    items.ElementAt(i).LastMessage = message;
                    NotifyItemChanged(i);
                    if (i != 0)
                    {
                        SwapItems(i, 0);
                        NotifyItemMoved(i, 0);
                    }
                    dialogExist = true;
                    break;
                }
            }
            return dialogExist;
        }

        private void SwapItems(int pos1, int pos2)
        {
            var item1 = items[pos1];
            var item2 = items[pos2];
            items[pos1] = item2;
            items[pos2] = item1;
        }

        public void SortByLastMessageDate()
        {
            items.Sort(new MyComparer<DIALOG>());
            NotifyDataSetChanged();
        }

        public void Sort(MyComparer<DIALOG> comparator)
        {
            items.Sort(comparator);
            NotifyDataSetChanged();
        }

    }

    public class MyComparer<DIALOG> : IComparer<DIALOG> where DIALOG : IDialog<IMessage>
    {
        public int Compare(DIALOG x, DIALOG y)
        {
            if (x.LastMessage.CreatedAt.After(y.LastMessage.CreatedAt))
            {
                return -1;
            }
            else if (x.LastMessage.CreatedAt.Before(y.LastMessage.CreatedAt))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }

    public interface OnDialogClickListener<DIALOG> where DIALOG : IDialog<IMessage>
    {
        void OnDialogClick(DIALOG dialog);
    }

    public interface OnDialogLongClickListener<DIALOG> where DIALOG : IDialog<IMessage>
    {
        void OnDialogLongClick(DIALOG dialog);
    }

    public abstract class BaseDialogViewHolder<DIALOG> : ViewHolder<DIALOG> where DIALOG : IDialog<IMessage>
    {
        protected ImageLoader imageLoader;
        protected OnDialogClickListener<DIALOG> onDialogClickListener;
        protected OnDialogLongClickListener<DIALOG> onDialogLongClickListener;
        protected DateFormatter.Formatter datesFormatter;

        public BaseDialogViewHolder(View itemView) : base(itemView) { }

        public void SetImageLoader(ImageLoader imageLoader)
        {
            this.imageLoader = imageLoader;
        }

        public void SetOnDialogClickListener(OnDialogClickListener<DIALOG> onDialogClickListener)
        {
            this.onDialogClickListener = onDialogClickListener;
        }

        public void SetOnDialogLongClickListener(OnDialogLongClickListener<DIALOG> onDialogLongClickListener)
        {
            this.onDialogLongClickListener = onDialogLongClickListener;
        }

        public void SetDatesFormatter(DateFormatter.Formatter dateHeadersFormatter)
        {
            this.datesFormatter = dateHeadersFormatter;
        }
    }

    public class DialogViewHolder<DIALOG> : BaseDialogViewHolder<DIALOG> where DIALOG : IDialog<IMessage>
    {
        private DialogListStyle _dialogStyle;
        public DialogListStyle DialogStyle
        {
            get
            {
                return _dialogStyle;
            }
            set
            {
                _dialogStyle = value;
                ApplyStyle();
            }
        }
        protected ViewGroup container;
        protected ViewGroup root;
        protected TextView tvName;
        protected TextView tvDate;
        protected ImageView ivAvatar;
        protected ImageView ivLastMessageUser;
        protected TextView tvLastMessage;
        protected TextView tvBubble;
        protected ViewGroup dividerContainer;
        protected View divider;

        public DialogViewHolder(View itemView) : base(itemView)
        {
            root = (ViewGroup)itemView.FindViewById(Resource.Id.dialogRootLayout);
            container = (ViewGroup)itemView.FindViewById(Resource.Id.dialogContainer);
            tvName = (TextView)itemView.FindViewById(Resource.Id.dialogName);
            tvDate = (TextView)itemView.FindViewById(Resource.Id.dialogDate);
            tvLastMessage = (TextView)itemView.FindViewById(Resource.Id.dialogLastMessage);
            tvBubble = (TextView)itemView.FindViewById(Resource.Id.dialogUnreadBubble);
            ivLastMessageUser = (ImageView)itemView.FindViewById(Resource.Id.dialogLastMessageUserAvatar);
            ivAvatar = (ImageView)itemView.FindViewById(Resource.Id.dialogAvatar);
            dividerContainer = (ViewGroup)itemView.FindViewById(Resource.Id.dialogDividerContainer);
            divider = itemView.FindViewById(Resource.Id.dialogDivider);
        }

        private void ApplyStyle()
        {
            if (DialogStyle != null)
            {
                if (tvName != null)
                {
                    tvName.SetTextSize(ComplexUnitType.Px, DialogStyle.DialogTitleTextSize);
                }

                if (tvLastMessage != null)
                {
                    tvLastMessage.SetTextSize(ComplexUnitType.Px, DialogStyle.DialogMessageTextSize);
                }

                if (tvDate != null)
                {
                    tvDate.SetTextSize(ComplexUnitType.Px, DialogStyle.DialogDateSize);
                }

                // Divider
                if (divider != null)
                {
                    divider.SetBackgroundColor(new Color(DialogStyle.DialogDividerColor));
                }

                if (dividerContainer != null)
                {
                    dividerContainer.SetPadding(DialogStyle.DialogDividerLeftPadding, 0, DialogStyle.DialogDividerRightPadding, 0);
                }

                // Avatar
                if (ivAvatar != null)
                {
                    ivAvatar.LayoutParameters.Width = DialogStyle.DialogAvatarWidth;
                    ivAvatar.LayoutParameters.Height = DialogStyle.DialogAvatarHeight;
                }

                // Last message user avatar
                if (ivLastMessageUser != null)
                {
                    ivLastMessageUser.LayoutParameters.Width = DialogStyle.DialogMessageAvatarWidth;
                    ivLastMessageUser.LayoutParameters.Height = DialogStyle.DialogMessageAvatarHeight;
                }

                if (tvBubble != null)
                {
                    GradientDrawable bgShape = (GradientDrawable)tvBubble.Background;
                    bgShape.SetColor(DialogStyle.DialogUnreadBubbleBackgroundColor);
                    tvBubble.Visibility = DialogStyle.DialogDividerEnabled ? ViewStates.Visible : ViewStates.Gone;
                    tvBubble.SetTextSize(ComplexUnitType.Px, DialogStyle.DialogUnreadBubbleTextSize);
                    tvBubble.SetTextColor(new Color(DialogStyle.DialogUnreadBubbleTextColor));
                    tvBubble.SetTypeface(tvBubble.Typeface, TypefaceStyle.Normal);
                }
            }
        }

        private void ApplyDefaultStyle()
        {
            if (DialogStyle != null)
            {
                if (root != null)
                {
                    root.SetBackgroundColor(new Color(DialogStyle.DialogItemBackground));
                }

                if (tvName != null)
                {
                    tvName.SetTextColor(new Color(DialogStyle.DialogTitleTextColor));
                    tvName.SetTypeface(tvName.Typeface, TypefaceStyle.Normal);
                }

                if (tvDate != null)
                {
                    tvDate.SetTextColor(new Color(DialogStyle.DialogDateColor));
                    tvDate.SetTypeface(tvDate.Typeface, TypefaceStyle.Normal);
                }

                if (tvLastMessage != null)
                {
                    tvLastMessage.SetTextColor(new Color(DialogStyle.DialogMessageTextColor));
                    tvLastMessage.SetTypeface(tvLastMessage.Typeface, TypefaceStyle.Normal);
                }
            }
        }

        private void ApplyUnreadStyle()
        {
            if (DialogStyle != null)
            {
                if (root != null)
                {
                    root.SetBackgroundColor(new Color(DialogStyle.DialogUnreadItemBackground));
                }

                if (tvName != null)
                {
                    tvName.SetTextColor(new Color(DialogStyle.DialogUnreadTitleTextColor));
                    tvName.SetTypeface(tvName.Typeface, TypefaceStyle.Normal);
                }

                if (tvDate != null)
                {
                    tvDate.SetTextColor(new Color(DialogStyle.DialogUnreadDateColor));
                    tvDate.SetTypeface(tvDate.Typeface, TypefaceStyle.Normal);
                }

                if (tvLastMessage != null)
                {
                    tvLastMessage.SetTextColor(new Color(DialogStyle.DialogUnreadMessageTextColor));
                    tvLastMessage.SetTypeface(tvLastMessage.Typeface, TypefaceStyle.Normal);
                }
            }
        }

        public override void OnBind(DIALOG dialog)
        {
            if (dialog.UnreadCount > 0)
            {
                ApplyUnreadStyle();
            }
            else
            {
                ApplyDefaultStyle();
            }

            // Set name
            tvName.Text = dialog.DialogName;

            // Set date
            string formattedDate = null;
            Date lastMessageDate = dialog.LastMessage.CreatedAt;
            if (datesFormatter != null) formattedDate = datesFormatter.Format(lastMessageDate);
            tvDate.Text = formattedDate == null ? GetDateString(lastMessageDate) : formattedDate;

            // Set Dialog avatar
            if (imageLoader != null) imageLoader.LoadImage(ivAvatar, dialog.DialogPhoto);

            // Set Last message user avatar
            if (imageLoader != null) imageLoader.LoadImage(ivLastMessageUser, dialog.LastMessage.User.Avatar);
            ivLastMessageUser.Visibility = DialogStyle.DialogMessageAvatarEnabled && dialog.Users.Count > 1 ? ViewStates.Visible : ViewStates.Gone;

            // Set Last message text
            tvLastMessage.Text = dialog.LastMessage.Text;

            // Set unread message count bubble
            tvBubble.Text = dialog.UnreadCount.ToString();
            tvBubble.Visibility = DialogStyle.DialogUnreadBubbleEnabled && dialog.UnreadCount > 0 ? ViewStates.Visible : ViewStates.Gone;

            if (onDialogClickListener != null)
            {
                container.SetOnClickListener(new MyClickListener<DIALOG>(onDialogClickListener, dialog));
            }

            if (onDialogLongClickListener != null)
            {
                container.SetOnLongClickListener(new MyLongClickListener<DIALOG>(onDialogLongClickListener, dialog));
            }
        }

        protected string GetDateString(Date date)
        {
            return DateFormatter.Format(date, DateFormatter.Template.STRING_DAY_MONTH_YEAR_TIME);
        }

    }

    internal class MyClickListener<DIALOG> : View.IOnClickListener where DIALOG : IDialog<IMessage>
    {
        protected OnDialogClickListener<DIALOG> onDialogClickListener;
        protected DIALOG dialog;
        public MyClickListener(OnDialogClickListener<DIALOG> listener, DIALOG dialog)
        {
            this.onDialogClickListener = listener;
            this.dialog = dialog;
        }


        public IntPtr Handle => IntPtr.Zero;

        public void Dispose()
        {
        }

        public void OnClick(View v)
        {
            onDialogClickListener.OnDialogClick(dialog);
        }
    }

    internal class MyLongClickListener<DIALOG> : View.IOnLongClickListener where DIALOG : IDialog<IMessage>
    {
        protected OnDialogLongClickListener<DIALOG> onDialogLongClickListener;
        protected DIALOG dialog;

        public MyLongClickListener(OnDialogLongClickListener<DIALOG> listener, DIALOG dialog)
        {
            this.onDialogLongClickListener = listener;
            this.dialog = dialog;
        }
        public IntPtr Handle => IntPtr.Zero;

        public void Dispose()
        {
        }

        public bool OnLongClick(View v)
        {
            onDialogLongClickListener.OnDialogLongClick(dialog);
            return true;
        }
    }
}