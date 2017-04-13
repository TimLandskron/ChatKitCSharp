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
using ChatKitCSharp.Commons;
using ChatKitCSharp.Commons.Models;
using Android.Text.Method;
using Android.Text;
using ChatKitCSharp.Utils;
using Android.Graphics;

namespace ChatKitCSharp.Messages
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
            this.dateHeaderHolder = typeof(DefaultDateHeaderViewHolder<Date>);
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

        /// <summary>
        /// Registers custom content type (e.g. multimedia, events etc.)
        /// </summary>
        /// <param name="type">            unique id for content type </param>
        /// <param name="holder">          holder class for incoming and outcoming messages </param>
        /// <param name="incomingLayout">  layout resource for incoming message </param>
        /// <param name="outcomingLayout"> layout resource for outcoming message </param>
        /// <param name="contentChecker">  <seealso cref="ContentChecker"/> for registered type </param>
        /// <returns> <seealso cref="MessageHolders"/> for subsequent configuration. </returns>
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: public <TYPE extends com.stfalcon.chatkit.commons.models.MessageContentType> MessageHolders registerContentType(byte type, @NonNull Class holder, @LayoutRes int incomingLayout, @LayoutRes int outcomingLayout, @NonNull ContentChecker contentChecker)
        public virtual MessageHolders registerContentType<TYPE>(sbyte type, Type holder, int incomingLayout, int outcomingLayout, ContentChecker<IMessage> contentChecker) where TYPE : IMessageContentType
        {

            return registerContentType<TYPE>(type, holder, incomingLayout, holder, outcomingLayout, contentChecker);
        }

        /// <summary>
        /// Registers custom content type (e.g. multimedia, events etc.)
        /// </summary>
        /// <param name="type">            unique id for content type </param>
        /// <param name="incomingHolder">  holder class for incoming message </param>
        /// <param name="outcomingHolder"> holder class for outcoming message </param>
        /// <param name="incomingLayout">  layout resource for incoming message </param>
        /// <param name="outcomingLayout"> layout resource for outcoming message </param>
        /// <param name="contentChecker">  <seealso cref="ContentChecker"/> for registered type </param>
        /// <returns> <seealso cref="MessageHolders"/> for subsequent configuration. </returns>
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: public <TYPE extends com.stfalcon.chatkit.commons.models.MessageContentType> MessageHolders registerContentType(byte type, @NonNull Class incomingHolder, @LayoutRes int incomingLayout, @NonNull Class outcomingHolder, @LayoutRes int outcomingLayout, @NonNull ContentChecker contentChecker)
        public virtual MessageHolders registerContentType<TYPE>(sbyte type, Type incomingHolder, int incomingLayout, Type outcomingHolder, int outcomingLayout, ContentChecker<IMessage> contentChecker) where TYPE : IMessageContentType
        {

            if (type == 0)
            {
                throw new System.ArgumentException("content type must be greater or less than '0'!");
            }
            var holder1 = new HolderConfig(this, incomingHolder, incomingLayout);
            var holder2 = new HolderConfig(this, outcomingHolder, outcomingLayout);
            var contentTypeConfig = new ContentTypeConfig(type, holder1, holder2);

            customContentTypes.Add(contentTypeConfig);

            this.contentChecker = contentChecker;
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

        internal virtual ViewHolder<TYPE> getHolder<TYPE>(ViewGroup parent, int viewType, MessagesListStyle messagesListStyle)
        {
            switch (viewType)
            {
                case VIEW_TYPE_DATE_HEADER:
                    return getDateHolder(parent, dateHeaderLayout, dateHeaderHolder, messagesListStyle) as ViewHolder<TYPE>;
                case VIEW_TYPE_TEXT_MESSAGE:
                    return getHolder(parent, incomingTextConfig, messagesListStyle) as ViewHolder<TYPE>;
                case -VIEW_TYPE_TEXT_MESSAGE:
                    return getHolder(parent, outcomingTextConfig, messagesListStyle) as ViewHolder<TYPE>;
                case VIEW_TYPE_IMAGE_MESSAGE:
                    return getHolder(parent, incomingImageConfig, messagesListStyle) as ViewHolder<TYPE>;
                case -VIEW_TYPE_IMAGE_MESSAGE:
                    return getHolder(parent, outcomingImageConfig, messagesListStyle) as ViewHolder<TYPE>;
                default:
                    foreach (ContentTypeConfig typeConfig in customContentTypes)
                    {
                        if (Math.Abs(typeConfig.type) == Math.Abs(viewType))
                        {
                            if (viewType > 0)
                            {
                                return getHolder(parent, typeConfig.incomingConfig, messagesListStyle) as ViewHolder<TYPE>;
                            }
                            else
                            {
                                return getHolder(parent, typeConfig.outcomingConfig, messagesListStyle) as ViewHolder<TYPE>;
                            }
                        }
                    }
                    break;
            }
            return null;
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @SuppressWarnings("unchecked") void bind(com.stfalcon.chatkit.commons.ViewHolder holder, Object item, boolean isSelected, com.stfalcon.chatkit.commons.ImageLoader imageLoader, android.view.View.OnClickListener onMessageClickListener, android.view.View.OnLongClickListener onMessageLongClickListener, com.stfalcon.chatkit.utils.DateFormatter.Formatter dateHeadersFormatter)
        internal virtual void bind<T>(ViewHolder<T> holder, object item, bool isSelected, ImageLoader imageLoader, View.IOnClickListener onMessageClickListener, View.IOnLongClickListener onMessageLongClickListener, DateFormatter.Formatter dateHeadersFormatter)
        {
            if (item is IMessage)
            {
                (holder as BaseMessageViewHolder<IMessage>).isSelected = isSelected;
                (holder as BaseMessageViewHolder<IMessage>).imageLoader = imageLoader;
                holder.ItemView.SetOnLongClickListener(onMessageLongClickListener);
                holder.ItemView.SetOnClickListener(onMessageClickListener);
            }
            else if (item is Date)
            {
                (holder as DefaultDateHeaderViewHolder<Date>).dateHeadersFormatter = dateHeadersFormatter;
            }
            holder.OnBind((T)item);
        }


        internal virtual int getViewType(object item, string senderId)
        {
            bool isOutcoming = false;
            int viewType;

            if (item is IMessage)
            {
                IMessage message = (IMessage)item;
                isOutcoming = message.Id.Equals(senderId);
                viewType = getContentViewType(message);
            }
            else
            {
                viewType = VIEW_TYPE_DATE_HEADER;
            }

            return isOutcoming ? viewType * -1 : viewType;
        }

        private ViewHolder<IMessage> getHolder(ViewGroup parent, HolderConfig holderConfig, MessagesListStyle style)
        {
            return getHolder<IMessage>(parent, holderConfig.layout, holderConfig.holder, style);
        }

        private ViewHolder<Date> getDateHolder(ViewGroup parent, int layout, Type holderClass, MessagesListStyle style)
        {
            View v = LayoutInflater.From(parent.Context).Inflate(layout, parent, false);
            return new DefaultDateHeaderViewHolder<Date>(v);
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: private <HOLDER extends com.stfalcon.chatkit.commons.ViewHolder> com.stfalcon.chatkit.commons.ViewHolder getHolder(android.view.ViewGroup parent, @LayoutRes int layout, Class<HOLDER> holderClass, MessagesListStyle style)
        private ViewHolder<T> getHolder<T>(ViewGroup parent, int layout, Type holderClass, MessagesListStyle style)
        {

            View v = LayoutInflater.From(parent.Context).Inflate(layout, parent, false);
            try
            {
                if (holderClass == typeof(DefaultIncomingTextMessageViewHolder))
                {
                    return new IncomingTextMessageViewHolder<IMessage>(v) as ViewHolder<T>;
                }
                else if (holderClass == typeof(DefaultOutcomingTextMessageViewHolder))
                {
                    return new OutcomingTextMessageViewHolder<IMessage>(v) as ViewHolder<T>;
                }
                else if (holderClass == typeof(DefaultDateHeaderViewHolder<Date>))
                {
                    return new DefaultDateHeaderViewHolder<Date>(v) as ViewHolder<T>;
                }
                else if (holderClass == typeof(DefaultIncomingImageMessageViewHolder))
                {
                    return new IncomingImageMessageViewHolder<IMessageContentType>(v) as ViewHolder<T>;
                }
                return null;
                //Constructor<HOLDER> constructor = holderClass.getDeclaredConstructor(typeof(View));
                //constructor.Accessible = true;
                //HOLDER holder = constructor.newInstance(v);
                //if (holder is DefaultMessageViewHolder && style != null)
                //{
                //    ((DefaultMessageViewHolder)holder).applyStyle(style);
                //}
                //return holder;
            }
            catch (Exception)
            {
                return null;
            }
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @SuppressWarnings("unchecked") private short getContentViewType(com.stfalcon.chatkit.commons.models.IMessage message)
        private short getContentViewType(IMessage message)
        {
            if (message is IMessageContentType && ((IMessageContentType)message).ImageUrl != null)
            {
                return VIEW_TYPE_IMAGE_MESSAGE;
            }

            // other default types will be here

            if (message is IMessageContentType)
            {
                for (int i = 0; i < customContentTypes.Count; i++)
                {
                    ContentTypeConfig config = customContentTypes[i];
                    if (contentChecker == null)
                    {
                        throw new System.ArgumentException("ContentChecker cannot be null when using custom content types!");
                    }
                    bool hasContent = contentChecker.hasContentFor(message, config.type);
                    if (hasContent)
                    {
                        return config.type;
                    }
                }
            }

            return VIEW_TYPE_TEXT_MESSAGE;
        }

        /*
		* HOLDERS
		* */

        /// <summary>
        /// The base class for view holders for incoming and outcoming message.
        /// You can extend it to create your own holder in conjuction with custom layout or even using default layout.
        /// </summary>
        public abstract class BaseMessageViewHolder<MESSAGE> : ViewHolder<MESSAGE> where MESSAGE : IMessage
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
                    return MessagesListAdapter<MESSAGE>.isSelectionModeEnabled;
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
                private readonly BaseMessageViewHolder<MESSAGE> outerInstance;

                public LinkMovementMethodAnonymousInnerClass(BaseMessageViewHolder<MESSAGE> outerInstance)
                {
                    this.outerInstance = outerInstance;
                }

                public override bool OnTouchEvent(TextView widget, ISpannable buffer, MotionEvent e)
                {
                    bool result = false;
                    if (!MessagesListAdapter<MESSAGE>.isSelectionModeEnabled)
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
        public class IncomingTextMessageViewHolder<MESSAGE> : BaseIncomingMessageViewHolder<MESSAGE> where MESSAGE : IMessage
        {

            protected internal ViewGroup bubble;
            protected internal TextView text;

            public IncomingTextMessageViewHolder(View itemView) : base(itemView)
            {
                bubble = (ViewGroup)itemView.FindViewById(Resource.Id.bubble);
                text = (TextView)itemView.FindViewById(Resource.Id.messageText);
            }

            public override void OnBind(MESSAGE message)
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
                    configureLinksBehavior(text);
                }
            }
        }

        /// <summary>
        /// Default view holder implementation for outcoming text message
        /// </summary>
        public class OutcomingTextMessageViewHolder<MESSAGE> : BaseOutcomingMessageViewHolder<MESSAGE> where MESSAGE : IMessage
        {

            protected internal ViewGroup bubble;
            protected internal TextView text;

            public OutcomingTextMessageViewHolder(View itemView) : base(itemView)
            {
                bubble = (ViewGroup)itemView.FindViewById(Resource.Id.bubble);
                text = (TextView)itemView.FindViewById(Resource.Id.messageText);
            }

            public override void OnBind(MESSAGE message)
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
                    configureLinksBehavior(text);
                }
            }
        }

        /// <summary>
        /// Default view holder implementation for incoming image message
        /// </summary>
        public class IncomingImageMessageViewHolder<MESSAGE> : BaseIncomingMessageViewHolder<MESSAGE> where MESSAGE : IMessageContentType
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

            public override void OnBind(MESSAGE message)
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
        public class OutcomingImageMessageViewHolder<MESSAGE> : BaseOutcomingMessageViewHolder<MESSAGE> where MESSAGE : IMessageContentType
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

            public override void OnBind(MESSAGE message)
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
        public class DefaultDateHeaderViewHolder<DATE> : ViewHolder<Date>, DefaultMessageViewHolder
        {

            protected internal TextView text;
            protected internal string dateFormat;
            protected internal DateFormatter.Formatter dateHeadersFormatter;

            public DefaultDateHeaderViewHolder(View itemView) : base(itemView)
            {
                text = (TextView)itemView.FindViewById(Resource.Id.messageText);
            }

            public override void OnBind(Date date)
            {
                if (text != null)
                {
                    string formattedDate = null;
                    if (dateHeadersFormatter != null)
                    {
                        formattedDate = dateHeadersFormatter.Format(date);
                    }
                    text.Text = string.ReferenceEquals(formattedDate, null) ? DateFormatter.Format(date, dateFormat) : formattedDate;
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
        public abstract class BaseIncomingMessageViewHolder<MESSAGE> : BaseMessageViewHolder<MESSAGE>, DefaultMessageViewHolder where MESSAGE : IMessage
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

            public override void OnBind(MESSAGE message)
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
        public abstract class BaseOutcomingMessageViewHolder<MESSAGE> : BaseMessageViewHolder<MESSAGE>, DefaultMessageViewHolder where MESSAGE : IMessage
        {

            protected internal TextView time;

            public BaseOutcomingMessageViewHolder(View itemView) : base(itemView)
            {
                time = (TextView)itemView.FindViewById(Resource.Id.messageTime);
            }

            public override void OnBind(MESSAGE message)
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

        private class DefaultIncomingTextMessageViewHolder : IncomingTextMessageViewHolder<IMessage>
        {

            public DefaultIncomingTextMessageViewHolder(View itemView) : base(itemView)
            {
            }
        }

        private class DefaultOutcomingTextMessageViewHolder : OutcomingTextMessageViewHolder<IMessage>
        {

            public DefaultOutcomingTextMessageViewHolder(View itemView) : base(itemView)
            {
            }
        }

        private class DefaultIncomingImageMessageViewHolder : IncomingImageMessageViewHolder<IMessageContentType>
        {

            public DefaultIncomingImageMessageViewHolder(View itemView) : base(itemView)
            {
            }
        }

        private class DefaultOutcomingImageMessageViewHolder : OutcomingImageMessageViewHolder<IMessageContentType>
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