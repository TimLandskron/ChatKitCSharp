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
using Android.Text.Method;
using Android.Text;
using ChatKitLibrary.Utils;
using Android.Graphics;
using ChatKitLibrary.Commons.Models;
using ChatKitLibrary.Commons;

namespace ChatKitLibrary.Messages
{
    public class MessageHolders
    {
        private const short VIEW_TYPE_DATE_HEADER = 130;
        private const short VIEW_TYPE_TEXT_MESSAGE = 131;
        private const short VIEW_TYPE_IMAGE_MESSAGE = 132;

        private Type dateHeaderHolder;
        private int dateHeaderLayout;

        private HolderConfig incomingTextConfig;
        private HolderConfig outcomingTextConfig;
        private HolderConfig incomingImageConfig;
        private HolderConfig outcomingImageConfig;

        private List<ContentTypeConfig> customContentTypes = new List<ContentTypeConfig>();
        private ContentChecker<IMessage> contentChecker;

        public MessageHolders()
        {
            this.dateHeaderHolder = typeof(DefaultDateHeaderViewHolder);
            this.dateHeaderLayout = Resource.Layout.item_date_header;

            this.incomingTextConfig = new HolderConfig(this, typeof(DefaultIncomingTextMessageViewHolder), Resource.Layout.item_incoming_text_message);
            this.outcomingTextConfig = new HolderConfig(this, typeof(DefaultOutcomingTextMessageViewHolder), Resource.Layout.item_outcoming_text_message);
            this.incomingImageConfig = new HolderConfig(this, typeof(DefaultIncomingImageMessageViewHolder), Resource.Layout.item_incoming_image_message);
            this.outcomingImageConfig = new HolderConfig(this, typeof(DefaultOutcomingImageMessageViewHolder), Resource.Layout.item_outcoming_image_message);
        }

        /// <summary>
        /// Sets both of custom view holder class and layout resource for incoming text message.
        /// </summary>
        /// <param name="holder"> holder class. </param>
        /// <param name="layout"> layout resource. </param>
        /// <returns> <seealso cref="MessageHolders"/> for subsequent configuration. </returns>
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: public MessageHolders setIncomingTextConfig(@NonNull Class holder, @LayoutRes int layout)
        public virtual MessageHolders setIncomingTextConfig(Type holder, int layout)
        {
            this.incomingTextConfig.holder = holder;
            this.incomingTextConfig.layout = layout;
            return this;
        }

        /// <summary>
        /// Sets custom view holder class for incoming text message.
        /// </summary>
        /// <param name="holder"> holder class. </param>
        /// <returns> <seealso cref="MessageHolders"/> for subsequent configuration. </returns>
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: public MessageHolders setIncomingTextHolder(@NonNull Class holder)
        public virtual MessageHolders setIncomingTextHolder(Type holder)
        {
            this.incomingTextConfig.holder = holder;
            return this;
        }

        /// <summary>
        /// Sets custom layout resource for incoming text message.
        /// </summary>
        /// <param name="layout"> layout resource. </param>
        /// <returns> <seealso cref="MessageHolders"/> for subsequent configuration. </returns>
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: public MessageHolders setIncomingTextLayout(@LayoutRes int layout)
        public virtual MessageHolders setIncomingTextLayout(int layout)
        {
            this.incomingTextConfig.layout = layout;
            return this;
        }

        /// <summary>
        /// Sets both of custom view holder class and layout resource for outcoming text message.
        /// </summary>
        /// <param name="holder"> holder class. </param>
        /// <param name="layout"> layout resource. </param>
        /// <returns> <seealso cref="MessageHolders"/> for subsequent configuration. </returns>
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: public MessageHolders setOutcomingTextConfig(@NonNull Class holder, @LayoutRes int layout)
        public virtual MessageHolders setOutcomingTextConfig(Type holder, int layout)
        {
            this.outcomingTextConfig.holder = holder;
            this.outcomingTextConfig.layout = layout;
            return this;
        }

        /// <summary>
        /// Sets custom view holder class for outcoming text message.
        /// </summary>
        /// <param name="holder"> holder class. </param>
        /// <returns> <seealso cref="MessageHolders"/> for subsequent configuration. </returns>
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: public MessageHolders setOutcomingTextHolder(@NonNull Class holder)
        public virtual MessageHolders setOutcomingTextHolder(Type holder)
        {
            this.outcomingTextConfig.holder = holder;
            return this;
        }

        /// <summary>
        /// Sets custom layout resource for outcoming text message.
        /// </summary>
        /// <param name="layout"> layout resource. </param>
        /// <returns> <seealso cref="MessageHolders"/> for subsequent configuration. </returns>
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: public MessageHolders setOutcomingTextLayout(@LayoutRes int layout)
        public virtual MessageHolders setOutcomingTextLayout(int layout)
        {
            this.outcomingTextConfig.layout = layout;
            return this;
        }

        /// <summary>
        /// Sets both of custom view holder class and layout resource for incoming image message.
        /// </summary>
        /// <param name="holder"> holder class. </param>
        /// <param name="layout"> layout resource. </param>
        /// <returns> <seealso cref="MessageHolders"/> for subsequent configuration. </returns>
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: public MessageHolders setIncomingImageConfig(@NonNull Class holder, @LayoutRes int layout)
        public virtual MessageHolders setIncomingImageConfig(Type holder, int layout)
        {
            this.incomingImageConfig.holder = holder;
            this.incomingImageConfig.layout = layout;
            return this;
        }

        /// <summary>
        /// Sets custom view holder class for incoming image message.
        /// </summary>
        /// <param name="holder"> holder class. </param>
        /// <returns> <seealso cref="MessageHolders"/> for subsequent configuration. </returns>
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: public MessageHolders setIncomingImageHolder(@NonNull Class holder)
        public virtual MessageHolders setIncomingImageHolder(Type holder)
        {
            this.incomingImageConfig.holder = holder;
            return this;
        }

        /// <summary>
        /// Sets custom layout resource for incoming image message.
        /// </summary>
        /// <param name="layout"> layout resource. </param>
        /// <returns> <seealso cref="MessageHolders"/> for subsequent configuration. </returns>
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: public MessageHolders setIncomingImageLayout(@LayoutRes int layout)
        public virtual MessageHolders setIncomingImageLayout(int layout)
        {
            this.incomingImageConfig.layout = layout;
            return this;
        }

        /// <summary>
        /// Sets both of custom view holder class and layout resource for outcoming image message.
        /// </summary>
        /// <param name="holder"> holder class. </param>
        /// <param name="layout"> layout resource. </param>
        /// <returns> <seealso cref="MessageHolders"/> for subsequent configuration. </returns>
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: public MessageHolders setOutcomingImageConfig(@NonNull Class holder, @LayoutRes int layout)
        public virtual MessageHolders setOutcomingImageConfig(Type holder, int layout)
        {
            this.outcomingImageConfig.holder = holder;
            this.outcomingImageConfig.layout = layout;
            return this;
        }

        /// <summary>
        /// Sets custom view holder class for outcoming image message.
        /// </summary>
        /// <param name="holder"> holder class. </param>
        /// <returns> <seealso cref="MessageHolders"/> for subsequent configuration. </returns>
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: public MessageHolders setOutcomingImageHolder(@NonNull Class holder)
        public virtual MessageHolders setOutcomingImageHolder(Type holder)
        {
            this.outcomingImageConfig.holder = holder;
            return this;
        }

        /// <summary>
        /// Sets custom layout resource for outcoming image message.
        /// </summary>
        /// <param name="layout"> layout resource. </param>
        /// <returns> <seealso cref="MessageHolders"/> for subsequent configuration. </returns>
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: public MessageHolders setOutcomingImageLayout(@LayoutRes int layout)
        public virtual MessageHolders setOutcomingImageLayout(int layout)
        {
            this.outcomingImageConfig.layout = layout;
            return this;
        }

        /// <summary>
        /// Sets both of custom view holder class and layout resource for date header.
        /// </summary>
        /// <param name="holder"> holder class. </param>
        /// <param name="layout"> layout resource. </param>
        /// <returns> <seealso cref="MessageHolders"/> for subsequent configuration. </returns>
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: public MessageHolders setDateHeaderConfig(@NonNull Class holder, @LayoutRes int layout)
        public virtual MessageHolders setDateHeaderConfig(Type holder, int layout)
        {
            this.dateHeaderHolder = holder;
            this.dateHeaderLayout = layout;
            return this;
        }

        /// <summary>
        /// Sets custom view holder class for date header.
        /// </summary>
        /// <param name="holder"> holder class. </param>
        /// <returns> <seealso cref="MessageHolders"/> for subsequent configuration. </returns>
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: public MessageHolders setDateHeaderHolder(@NonNull Class holder)
        public virtual MessageHolders setDateHeaderHolder(Type holder)
        {
            this.dateHeaderHolder = holder;
            return this;
        }

        /// <summary>
        /// Sets custom layout reource for date header.
        /// </summary>
        /// <param name="layout"> layout resource. </param>
        /// <returns> <seealso cref="MessageHolders"/> for subsequent configuration. </returns>
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: public MessageHolders setDateHeaderLayout(@LayoutRes int layout)
        public virtual MessageHolders setDateHeaderLayout(int layout)
        {
            this.dateHeaderLayout = layout;
            return this;
        }

        /*
		* INTERFACES
		* */

        /// <summary>
        /// The interface, which contains logic for checking the availability of content.
        /// </summary>
        public interface ContentChecker<MESSAGE> where MESSAGE : IMessage
        {

            /// <summary>
            /// Checks the availability of content.
            /// </summary>
            /// <param name="message"> current message in list. </param>
            /// <param name="type">    content type, for which content availability is determined. </param>
            /// <returns> weather the message has content for the current message. </returns>
            bool hasContentFor(MESSAGE message, sbyte type);
        }

        /*
		* PRIVATE METHODS
		* */

        internal virtual ViewHolder getHolder(ViewGroup parent, int viewType, MessagesListStyle messagesListStyle)
        {
            switch (viewType)
            {
                case VIEW_TYPE_DATE_HEADER:
                    return getDateHolder(parent, dateHeaderLayout, dateHeaderHolder, messagesListStyle);
                case VIEW_TYPE_TEXT_MESSAGE:
                    var tmp = getHolder(parent, incomingTextConfig, messagesListStyle);
                    //var tmp2 = tmp as ViewHolder<T>;
                    return tmp;
                case -VIEW_TYPE_TEXT_MESSAGE:
                    return getHolder(parent, outcomingTextConfig, messagesListStyle);
                case VIEW_TYPE_IMAGE_MESSAGE:
                // return getHolder<MESSAGE>(parent, incomingImageConfig, messagesListStyle) as ViewHolder<T>;
                case -VIEW_TYPE_IMAGE_MESSAGE:
                // return getHolder<MESSAGE>(parent, outcomingImageConfig, messagesListStyle) as ViewHolder<T>;
                default:
                    foreach (ContentTypeConfig typeConfig in customContentTypes)
                    {
                        if (Math.Abs(typeConfig.type) == Math.Abs(viewType))
                        {
                            if (viewType > 0)
                            {
                                return getHolder(parent, typeConfig.incomingConfig, messagesListStyle);
                            }
                            else
                            {
                                return getHolder(parent, typeConfig.outcomingConfig, messagesListStyle);
                            }
                        }
                    }
                    break;
            }
            return null;
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @SuppressWarnings("unchecked") void bind(com.stfalcon.chatkit.commons.ViewHolder holder, Object item, boolean isSelected, com.stfalcon.chatkit.commons.ImageLoader imageLoader, android.view.View.OnClickListener onMessageClickListener, android.view.View.OnLongClickListener onMessageLongClickListener, com.stfalcon.chatkit.utils.DateFormatter.Formatter dateHeadersFormatter)
        internal virtual void bind(ViewHolder holder, object item, bool isSelected, ImageLoader imageLoader, MessagesListAdapter.MyOnClickListener onMessageClickListener, View.IOnLongClickListener onMessageLongClickListener, DateFormatter.Formatter dateHeadersFormatter)
        {
            if (item is MessageData)
            {
                var tmp = item as MessageData;
                if (tmp.Type == MessageData.DataType.Message)
                {

                    var tmpHolder = holder as BaseMessageViewHolder;
                    tmpHolder.isSelected = isSelected;
                    tmpHolder.imageLoader = imageLoader;
                    tmpHolder.ItemView.SetOnLongClickListener(onMessageLongClickListener);
                    tmpHolder.ItemView.SetOnClickListener(onMessageClickListener);
                    tmpHolder.OnBind(tmp);
                }
                else if (tmp.Type == MessageData.DataType.Date)
                {
                    var tmpHolder = holder as DefaultDateHeaderViewHolder;
                    tmpHolder.dateHeadersFormatter = dateHeadersFormatter;
                    tmpHolder.OnBind(tmp);
                }
            }
        }


        internal virtual int getViewType(object item, string senderId)
        {
            bool isOutcoming = false;
            int viewType;

            var tmp = item as MessageData;
            switch (tmp.Type)
            {
                case MessageData.DataType.Message:
                    isOutcoming = tmp.Id.Equals(senderId);
                    viewType = getContentViewType(tmp);
                    break;
                case MessageData.DataType.Date:
                    viewType = VIEW_TYPE_DATE_HEADER;
                    break;
                case MessageData.DataType.Image:
                    isOutcoming = tmp.Id.Equals(senderId);
                    viewType = getContentViewType(tmp);
                    break;
                default:
                    viewType = 0;
                    break;
            }

            return isOutcoming ? viewType * -1 : viewType;
        }

        private ViewHolder getHolder(ViewGroup parent, HolderConfig holderConfig, MessagesListStyle style)
        {
            var tmp = getHolder(parent, holderConfig.layout, holderConfig.holder, style);
            return tmp;
        }

        private ViewHolder getDateHolder(ViewGroup parent, int layout, Type holderClass, MessagesListStyle style)
        {
            View v = LayoutInflater.From(parent.Context).Inflate(layout, parent, false);
            var result = new DefaultDateHeaderViewHolder(v);
            result.applyStyle(style);
            return result;
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: private <HOLDER extends com.stfalcon.chatkit.commons.ViewHolder> com.stfalcon.chatkit.commons.ViewHolder getHolder(android.view.ViewGroup parent, @LayoutRes int layout, Class<HOLDER> holderClass, MessagesListStyle style)
        private ViewHolder getHolder(ViewGroup parent, int layout, Type holderClass, MessagesListStyle style)
        {

            View v = LayoutInflater.From(parent.Context).Inflate(layout, parent, false);
            try
            {
                if (holderClass == typeof(DefaultIncomingTextMessageViewHolder))
                {
                    var result = new IncomingTextMessageViewHolder(v);
                    result.applyStyle(style);
                    return result;
                }
                else if (holderClass == typeof(DefaultOutcomingTextMessageViewHolder))
                {
                    var result = new OutcomingTextMessageViewHolder(v);
                    result.applyStyle(style);
                    return result;
                }
                else if (holderClass == typeof(DefaultIncomingImageMessageViewHolder))
                {
                    var result = new IncomingImageMessageViewHolder(v);
                    result.applyStyle(style);
                    return result;
                }
                else if (holderClass == typeof(DefaultOutcomingImageMessageViewHolder))
                {
                    var result = new OutcomingImageMessageViewHolder(v);
                    result.applyStyle(style);
                    return result;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @SuppressWarnings("unchecked") private short getContentViewType(com.stfalcon.chatkit.commons.models.IMessage message)
        private short getContentViewType(MessageData message)
        {
            if (message.Type == MessageData.DataType.Image && !string.IsNullOrEmpty(message.ImageUrl))
            {
                return VIEW_TYPE_IMAGE_MESSAGE;
            }

            // other default types will be here

            //if (message is IMessageContentType)
            //{
            //    for (int i = 0; i < customContentTypes.Count; i++)
            //    {
            //        ContentTypeConfig config = customContentTypes[i];
            //        if (contentChecker == null)
            //        {
            //            throw new System.ArgumentException("ContentChecker cannot be null when using custom content types!");
            //        }
            //        bool hasContent = contentChecker.hasContentFor(message, config.type);
            //        if (hasContent)
            //        {
            //            return config.type;
            //        }
            //    }
            //}

            return VIEW_TYPE_TEXT_MESSAGE;
        }

        /*
		* HOLDERS
		* */

        /// <summary>
        /// The base class for view holders for incoming and outcoming message.
        /// You can extend it to create your own holder in conjuction with custom layout or even using default layout.
        /// </summary>
        public abstract class BaseMessageViewHolder : ViewHolder
        {

            internal bool isSelected;

            /// <summary>
            /// Callback for implementing images loading in message list
            /// </summary>
            internal ImageLoader imageLoader;

            public BaseMessageViewHolder(View itemView) : base(itemView)
            {
            }

            /// <summary>
            /// Returns whether is item selected
            /// </summary>
            /// <returns> weather is item selected. </returns>
            public virtual bool Selected
            {
                get
                {
                    return isSelected;
                }
            }

            /// <summary>
            /// Returns weather is selection mode enabled
            /// </summary>
            /// <returns> weather is selection mode enabled. </returns>
            public virtual bool SelectionModeEnabled
            {
                get
                {
                    return MessagesListAdapter.isSelectionModeEnabled;
                }
            }

            /// <summary>
            /// Getter for <seealso cref="#imageLoader"/>
            /// </summary>
            /// <returns> image loader interface. </returns>
            public virtual ImageLoader ImageLoader
            {
                get
                {
                    return imageLoader;
                }
            }

            //JAVA TO C# CONVERTER WARNING: 'final' parameters are not available in .NET:
            //ORIGINAL LINE: protected void configureLinksBehavior(final android.widget.TextView text)
            protected internal virtual void configureLinksBehavior(TextView text)
            {
                text.LinksClickable = false;
                text.MovementMethod = new LinkMovementMethodAnonymousInnerClass(this);
            }

            private class LinkMovementMethodAnonymousInnerClass : LinkMovementMethod
            {
                private readonly BaseMessageViewHolder outerInstance;

                public LinkMovementMethodAnonymousInnerClass(BaseMessageViewHolder outerInstance)
                {
                    this.outerInstance = outerInstance;
                }

                public override bool OnTouchEvent(TextView widget, ISpannable buffer, MotionEvent e)
                {
                    bool result = false;
                    if (!MessagesListAdapter.isSelectionModeEnabled)
                    {
                        result = base.OnTouchEvent(widget, buffer, e);
                    }
                    widget.OnTouchEvent(e);
                    return result;
                }
            }

        }

        /// <summary>
        /// Default view holder implementation for incoming text message
        /// </summary>
        public class IncomingTextMessageViewHolder : BaseIncomingMessageViewHolder
        {

            protected internal ViewGroup bubble;
            protected internal TextView text;

            public IncomingTextMessageViewHolder(View itemView) : base(itemView)
            {
                bubble = (ViewGroup)itemView.FindViewById(Resource.Id.bubble);
                text = (TextView)itemView.FindViewById(Resource.Id.messageText);
            }

            public override void OnBind(MessageData message)
            {
                base.OnBind(message);
                if (bubble != null)
                {
                    bubble.Selected = Selected;
                }

                if (text != null)
                {
                    text.Text = message.Text;
                }
            }

            public new void applyStyle(MessagesListStyle style)
            {
                base.applyStyle(style);
                if (bubble != null)
                {
                    bubble.SetPadding(style.getIncomingDefaultBubblePaddingLeft(), style.getIncomingDefaultBubblePaddingTop(), style.getIncomingDefaultBubblePaddingRight(), style.getIncomingDefaultBubblePaddingBottom());
                    bubble.Background = style.getIncomingBubbleDrawable();
                }

                if (text != null)
                {
                    text.SetTextColor(new Color(style.getIncomingTextColor()));
                    text.SetTextSize(Android.Util.ComplexUnitType.Px, style.getIncomingTextSize());
                    text.SetTypeface(text.Typeface, TypefaceStyle.Normal);
                    text.AutoLinkMask = Android.Text.Util.MatchOptions.All;
                    text.SetLinkTextColor(new Color(style.getIncomingTextLinkColor()));
                    //configureLinksBehavior(text);
                }
            }
        }

        /// <summary>
        /// Default view holder implementation for outcoming text message
        /// </summary>
        public class OutcomingTextMessageViewHolder : BaseOutcomingMessageViewHolder
        {

            protected internal ViewGroup bubble;
            protected internal TextView text;

            public OutcomingTextMessageViewHolder(View itemView) : base(itemView)
            {
                bubble = (ViewGroup)itemView.FindViewById(Resource.Id.bubble);
                text = (TextView)itemView.FindViewById(Resource.Id.messageText);
            }

            public override void OnBind(MessageData message)
            {
                base.OnBind(message);
                if (bubble != null)
                {
                    bubble.Selected = Selected;
                }

                if (text != null)
                {
                    text.Text = message.Text;
                }
            }

            public new void applyStyle(MessagesListStyle style)
            {
                base.applyStyle(style);
                if (bubble != null)
                {
                    bubble.SetPadding(style.getOutcomingDefaultBubblePaddingLeft(), style.getOutcomingDefaultBubblePaddingTop(), style.getOutcomingDefaultBubblePaddingRight(), style.getOutcomingDefaultBubblePaddingBottom());
                    bubble.Background = style.getOutcomingBubbleDrawable();
                }

                if (text != null)
                {
                    text.SetTextColor(new Color(style.getOutcomingTextColor()));
                    text.SetTextSize(Android.Util.ComplexUnitType.Px, style.getOutcomingTextSize());
                    text.SetTypeface(text.Typeface, TypefaceStyle.Normal);
                    text.AutoLinkMask = Android.Text.Util.MatchOptions.All;
                    text.SetLinkTextColor(new Color(style.getOutcomingTextLinkColor()));
                    //configureLinksBehavior(text);
                }
            }
        }

        /// <summary>
        /// Default view holder implementation for incoming image message
        /// </summary>
        public class IncomingImageMessageViewHolder : BaseIncomingMessageViewHolder
        {

            protected internal ImageView image;
            protected internal View imageOverlay;

            public IncomingImageMessageViewHolder(View itemView) : base(itemView)
            {
                image = (ImageView)itemView.FindViewById(Resource.Id.image);
                imageOverlay = itemView.FindViewById(Resource.Id.imageOverlay);

                if (image != null && image is RoundedImageView)
                {
                    ((RoundedImageView)image).SetCorners(Resource.Dimension.message_bubble_corners_radius, Resource.Dimension.message_bubble_corners_radius, Resource.Dimension.message_bubble_corners_radius, 0);
                }
            }

            public override void OnBind(MessageData message)
            {
                base.OnBind(message);
                if (image != null && imageLoader != null)
                {
                    imageLoader.LoadImage(image, message.ImageUrl);
                }

                if (imageOverlay != null)
                {
                    imageOverlay.Selected = Selected;
                }
            }

            public new void applyStyle(MessagesListStyle style)
            {
                base.applyStyle(style);
                if (time != null)
                {
                    time.SetTextColor(new Color(style.getIncomingImageTimeTextColor()));
                    time.SetTextSize(Android.Util.ComplexUnitType.Px, style.getIncomingImageTimeTextSize());
                    time.SetTypeface(time.Typeface, TypefaceStyle.Normal);
                }

                if (imageOverlay != null)
                {
                    imageOverlay.Background = style.getIncomingImageOverlayDrawable();
                }
            }
        }

        /// <summary>
        /// Default view holder implementation for outcoming image message
        /// </summary>
        public class OutcomingImageMessageViewHolder : BaseOutcomingMessageViewHolder
        {

            protected internal ImageView image;
            protected internal View imageOverlay;

            public OutcomingImageMessageViewHolder(View itemView) : base(itemView)
            {
                image = (ImageView)itemView.FindViewById(Resource.Id.image);
                imageOverlay = itemView.FindViewById(Resource.Id.imageOverlay);

                if (image != null && image is RoundedImageView)
                {
                    ((RoundedImageView)image).SetCorners(Resource.Dimension.message_bubble_corners_radius, Resource.Dimension.message_bubble_corners_radius, 0, Resource.Dimension.message_bubble_corners_radius);
                }
            }

            public override void OnBind(MessageData message)
            {
                base.OnBind(message);
                if (image != null && imageLoader != null)
                {
                    imageLoader.LoadImage(image, message.ImageUrl);
                }

                if (imageOverlay != null)
                {
                    imageOverlay.Selected = Selected;
                }
            }

            public new void applyStyle(MessagesListStyle style)
            {
                base.applyStyle(style);
                if (time != null)
                {
                    time.SetTextColor(new Color(style.getOutcomingImageTimeTextColor()));
                    time.SetTextSize(Android.Util.ComplexUnitType.Px, style.getOutcomingImageTimeTextSize());
                    time.SetTypeface(time.Typeface, TypefaceStyle.Normal);
                }

                if (imageOverlay != null)
                {
                    imageOverlay.Background = style.getOutcomingImageOverlayDrawable();
                }
            }
        }

        /// <summary>
        /// Default view holder implementation for date header
        /// </summary>
        public class DefaultDateHeaderViewHolder : ViewHolder, DefaultMessageViewHolder
        {

            protected internal TextView text;
            protected internal string dateFormat;
            protected internal DateFormatter.Formatter dateHeadersFormatter;

            public DefaultDateHeaderViewHolder(View itemView) : base(itemView)
            {
                text = (TextView)itemView.FindViewById(Resource.Id.messageText);
            }

            public override void OnBind(MessageData date)
            {
                if (text != null)
                {
                    string formattedDate = null;
                    if (dateHeadersFormatter != null)
                    {
                        formattedDate = dateHeadersFormatter.Format(date.CreatedAt);
                    }
                    text.Text = string.ReferenceEquals(formattedDate, null) ? DateFormatter.Format(date.CreatedAt, dateFormat) : formattedDate;
                }
            }

            public void applyStyle(MessagesListStyle style)
            {
                if (text != null)
                {
                    text.SetTextColor(new Color(style.getDateHeaderTextColor()));
                    text.SetTextSize(Android.Util.ComplexUnitType.Px, style.getDateHeaderTextSize());
                    text.SetTypeface(text.Typeface, TypefaceStyle.Normal);
                    text.SetPadding(style.getDateHeaderPadding(), style.getDateHeaderPadding(), style.getDateHeaderPadding(), style.getDateHeaderPadding());
                }
                dateFormat = style.getDateHeaderFormat();
                dateFormat = string.ReferenceEquals(dateFormat, null) ? DateFormatter.GetFormatString(DateFormatter.Template.TIME) : dateFormat;
            }
        }

        /// <summary>
        /// Base view holder for incoming message
        /// </summary>
        public abstract class BaseIncomingMessageViewHolder : BaseMessageViewHolder, DefaultMessageViewHolder
        {

            protected internal TextView time;
            protected internal ImageView userAvatar;

            public BaseIncomingMessageViewHolder(View itemView) : base(itemView)
            {
                time = (TextView)itemView.FindViewById(Resource.Id.messageTime);
                userAvatar = (ImageView)itemView.FindViewById(Resource.Id.messageUserAvatar);
            }

            public void applyStyle(MessagesListStyle style)
            {
                if (time != null)
                {
                    time.SetTextColor(new Color(style.getIncomingTimeTextColor()));
                    time.SetTextSize(Android.Util.ComplexUnitType.Px, style.getIncomingTimeTextSize());
                    time.SetTypeface(time.Typeface, TypefaceStyle.Normal);
                }

                if (userAvatar != null)
                {
                    userAvatar.LayoutParameters.Width = style.getIncomingAvatarWidth();
                    userAvatar.LayoutParameters.Height = style.getIncomingAvatarHeight();
                }
            }

            public override void OnBind(MessageData message)
            {
                if (time != null)
                {
                    time.Text = DateFormatter.Format(message.CreatedAt, DateFormatter.Template.TIME);
                }

                if (userAvatar != null)
                {
                    bool isAvatarExists = imageLoader != null && message.User.Avatar != null && !string.IsNullOrEmpty(message.User.Avatar);

                    userAvatar.Visibility = isAvatarExists ? ViewStates.Visible : ViewStates.Gone;
                    if (isAvatarExists)
                    {
                        imageLoader.LoadImage(userAvatar, message.User.Avatar);
                    }
                }
            }
        }

        /// <summary>
        /// Base view holder for outcoming message
        /// </summary>
        public abstract class BaseOutcomingMessageViewHolder : BaseMessageViewHolder, DefaultMessageViewHolder
        {

            protected internal TextView time;

            public BaseOutcomingMessageViewHolder(View itemView) : base(itemView)
            {
                time = (TextView)itemView.FindViewById(Resource.Id.messageTime);
            }

            public override void OnBind(MessageData message)
            {
                if (time != null)
                {
                    time.Text = DateFormatter.Format(message.CreatedAt, DateFormatter.Template.TIME);
                }
            }

            public void applyStyle(MessagesListStyle style)
            {
                if (time != null)
                {
                    time.SetTextColor(new Color(style.getOutcomingTimeTextColor()));
                    time.SetTextSize(Android.Util.ComplexUnitType.Px, style.getOutcomingTimeTextSize());
                    time.SetTypeface(time.Typeface, TypefaceStyle.Normal);
                }
            }
        }

        /*
		* DEFAULTS
		* */

        internal interface DefaultMessageViewHolder
        {
            void applyStyle(MessagesListStyle style);
        }

        private class DefaultIncomingTextMessageViewHolder : IncomingTextMessageViewHolder
        {

            public DefaultIncomingTextMessageViewHolder(View itemView) : base(itemView)
            {
            }
        }

        private class DefaultOutcomingTextMessageViewHolder : OutcomingTextMessageViewHolder
        {

            public DefaultOutcomingTextMessageViewHolder(View itemView) : base(itemView)
            {
            }
        }

        private class DefaultIncomingImageMessageViewHolder : IncomingImageMessageViewHolder
        {

            public DefaultIncomingImageMessageViewHolder(View itemView) : base(itemView)
            {
            }
        }

        private class DefaultOutcomingImageMessageViewHolder : OutcomingImageMessageViewHolder
        {

            public DefaultOutcomingImageMessageViewHolder(View itemView) : base(itemView)
            {
            }
        }

        private class ContentTypeConfig
        {

            internal sbyte type;
            internal HolderConfig incomingConfig;
            internal HolderConfig outcomingConfig;

            internal ContentTypeConfig(sbyte type, HolderConfig incomingConfig, HolderConfig outcomingConfig)
            {

                this.type = type;
                this.incomingConfig = incomingConfig;
                this.outcomingConfig = outcomingConfig;
            }
        }

        private class HolderConfig
        {
            private readonly MessageHolders outerInstance;


            internal Type holder;
            internal int layout;

            internal HolderConfig(MessageHolders outerInstance, Type holder, int layout)
            {
                this.outerInstance = outerInstance;
                this.holder = holder;
                this.layout = layout;
            }
        }
    }
}