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
using ChatKitLibrary.Commons;
using ChatKitLibrary.Utils;
using Java.Util;
using Android.Graphics;

namespace ChatKitLibrary.Messages
{
    public class MessagesListAdapter : RecyclerView.Adapter, RecyclerScrollMoreListener.OnLoadMoreListener
    {
        private MessageHolders holders;
        private string senderId;
        private List<Wrapper> items;

        private int selectedItemsCount;
        private SelectionListener selectionListener;

        internal static bool isSelectionModeEnabled;

        private OnLoadMoreListener loadMoreListener;
        private OnMessageClickListener onMessageClickListener;
        private OnMessageLongClickListener onMessageLongClickListener;
        private ImageLoader imageLoader;
        private RecyclerView.LayoutManager layoutManager;
        public MessagesListStyle Style { get; set; }
        
        private DateFormatter.Formatter dateHeadersFormatter;

        /// <summary>
        /// For default list item layout and view holder.
        /// </summary>
        /// <param name="senderId">    identifier of sender. </param>
        /// <param name="imageLoader"> image loading method. </param>
        public MessagesListAdapter(string senderId, ImageLoader imageLoader) : this(senderId, new MessageHolders(), imageLoader)
        {
        }

        /// <summary>
        /// For default list item layout and view holder.
        /// </summary>
        /// <param name="senderId">            identifier of sender. </param>
        /// <param name="holders"> custom layouts and view holders. See <seealso cref="MessageHolders"/> documentation for details </param>
        /// <param name="imageLoader">         image loading method. </param>
        public MessagesListAdapter(string senderId, MessageHolders holders, ImageLoader imageLoader)
        {
            this.senderId = senderId;
            this.holders = holders;
            this.imageLoader = imageLoader;
            this.items = new List<Wrapper>();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            //return holders.getHolder<MESSAGE>(parent, viewType, messagesListStyle);
            var tmp = onCreateViewHolder(parent, viewType);
            return tmp;
        }

        public ViewHolder onCreateViewHolder(ViewGroup parent, int viewType)
        {
            var tmp = holders.getHolder(parent, viewType, Style);
            return tmp;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            //Wrapper<MESSAGE> wrapper = items[position];
            var tmp = holder as ViewHolder;
            OnBindViewHolder(tmp, position);
            //holders.bind(tmp, wrapper.item, wrapper.isSelected, imageLoader, getMessageClickListener(wrapper), getMessageLongClickListener(wrapper), dateHeadersFormatter);
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @SuppressWarnings("unchecked") @Override public void onBindViewHolder(com.stfalcon.chatkit.commons.ViewHolder holder, int position)
        public void OnBindViewHolder(ViewHolder holder, int position)
        {
            Wrapper wrapper = items[position];
            holders.bind(holder, wrapper.item, wrapper.isSelected, imageLoader, getMessageClickListener(wrapper), getMessageLongClickListener(wrapper), dateHeadersFormatter);
        }

        public override int ItemCount
        {
            get
            {
                return items.Count;
            }
        }

        public override int GetItemViewType(int position)
        {
            //base.GetItemViewType(position);
            return holders.getViewType(items[position].item, senderId);
        }

        public void OnLoadMore(int page, int total)
        {
            if (loadMoreListener != null)
            {
                loadMoreListener.onLoadMore(page, total);
            }
        }

        /*
		* PUBLIC METHODS
		* */

        /// <summary>
        /// Adds message to bottom of list and scroll if needed.
        /// </summary>
        /// <param name="message"> message to add. </param>
        /// <param name="scroll">  {@code true} if need to scroll list to bottom when message added. </param>
        public virtual void addToStart(MessageData message, bool scroll)
        {
            bool isNewMessageToday = !isPreviousSameDate(0, message.CreatedAt);
            if (isNewMessageToday)
            {
                var dateMessage = new MessageData { CreatedAt = message.CreatedAt, Type = MessageData.DataType.Date };
                items.Insert(0, new Wrapper(this, dateMessage));
            }
            Wrapper element = new Wrapper(this, message);
            items.Insert(0, element);
            NotifyItemRangeInserted(0, isNewMessageToday ? 2 : 1);
            if (layoutManager != null && scroll)
            {
                layoutManager.ScrollToPosition(0);
            }
        }

        /// <summary>
        /// Adds messages list in chronological order. Use this method to add history.
        /// </summary>
        /// <param name="messages"> messages from history. </param>
        /// <param name="reverse">  {@code true} if need to reverse messages before adding. </param>
        public virtual void addToEnd(IList<MessageData> messages, bool reverse)
        {
            if (reverse)
            {
                messages = messages.Reverse().ToList();
            }

            if (items.Count > 0)
            {
                int lastItemPosition = items.Count - 1;
                Date lastItem = items[lastItemPosition].item.CreatedAt;
                if (DateFormatter.IsSameDay(messages[0].CreatedAt, lastItem))
                {
                    items.RemoveAt(lastItemPosition);
                    NotifyItemRemoved(lastItemPosition);
                }
            }

            int oldSize = items.Count;
            generateDateHeaders(messages);
            NotifyItemRangeInserted(oldSize, items.Count - oldSize);
        }

        /// <summary>
        /// Updates message by its id.
        /// </summary>
        /// <param name="message"> updated message object. </param>
        public virtual void update(MessageData message)
        {
            update(message.Id, message);
        }

        /// <summary>
        /// Updates message by old identifier (use this method if id has changed). Otherwise use <seealso cref="#update(IMessage)"/>
        /// </summary>
        /// <param name="oldId">      an identifier of message to update. </param>
        /// <param name="newMessage"> new message object. </param>
        public virtual void update(string oldId, MessageData newMessage)
        {
            int position = getMessagePositionById(oldId);
            if (position >= 0)
            {
                Wrapper element = new Wrapper(this, newMessage);
                items[position] = element;
                NotifyItemChanged(position);
            }
        }

        /// <summary>
        /// Deletes message.
        /// </summary>
        /// <param name="message"> message to delete. </param>
        public virtual void delete(MessageData message)
        {
            deleteById(message.Id);
        }

        /// <summary>
        /// Deletes messages list.
        /// </summary>
        /// <param name="messages"> messages list to delete. </param>
        public virtual void delete(IList<MessageData> messages)
        {
            foreach (MessageData message in messages)
            {
                int index = getMessagePositionById(message.Id);
                items.RemoveAt(index);
                NotifyItemRemoved(index);
            }
            recountDateHeaders();
        }

        /// <summary>
        /// Deletes message by its identifier.
        /// </summary>
        /// <param name="id"> identifier of message to delete. </param>
        public virtual void deleteById(string id)
        {
            int index = getMessagePositionById(id);
            if (index >= 0)
            {
                items.RemoveAt(index);
                NotifyItemRemoved(index);
                recountDateHeaders();
            }
        }

        /// <summary>
        /// Deletes messages by its identifiers.
        /// </summary>
        /// <param name="ids"> array of identifiers of messages to delete. </param>
        public virtual void deleteByIds(string[] ids)
        {
            foreach (string id in ids)
            {
                int index = getMessagePositionById(id);
                items.RemoveAt(index);
                NotifyItemRemoved(index);
            }
            recountDateHeaders();
        }

        /// <summary>
        /// Returns {@code true} if, and only if, messages count in adapter is non-zero.
        /// </summary>
        /// <returns> {@code true} if size is 0, otherwise {@code false} </returns>
        public virtual bool Empty
        {
            get
            {
                return items.Count == 0;
            }
        }

        /// <summary>
        /// Clears the messages list.
        /// </summary>
        public virtual void clear()
        {
            items.Clear();
        }

        /// <summary>
        /// Enables selection mode.
        /// </summary>
        /// <param name="selectionListener"> listener for selected items count. To get selected messages use <seealso cref="#getSelectedMessages()"/>. </param>
        public virtual void enableSelectionMode(SelectionListener selectionListener)
        {
            if (selectionListener == null)
            {
                throw new System.ArgumentException("SelectionListener must not be null. Use `disableSelectionMode()` if you want tp disable selection mode");
            }
            else
            {
                this.selectionListener = selectionListener;
            }
        }

        /// <summary>
        /// Disables selection mode and removes <seealso cref="SelectionListener"/>.
        /// </summary>
        public virtual void disableSelectionMode()
        {
            this.selectionListener = null;
            unselectAllItems();
        }

        /// <summary>
        /// Returns the list of selected messages.
        /// </summary>
        /// <returns> list of selected messages. Empty list if nothing was selected or selection mode is disabled. </returns>
        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @SuppressWarnings("unchecked") public java.util.ArrayList<MESSAGE> getSelectedMessages()
        public virtual List<MessageData> SelectedMessages
        {
            get
            {
                List<MessageData> selectedMessages = new List<MessageData>();
                foreach (Wrapper wrapper in items)
                {
                    if (wrapper.item is IMessage && wrapper.isSelected)
                    {
                        selectedMessages.Add((MessageData)wrapper.item);
                    }
                }
                return selectedMessages;
            }
        }

        /// <summary>
        /// Returns selected messages text and do <seealso cref="#unselectAllItems()"/> for you.
        /// </summary>
        /// <param name="formatter"> The formatter that allows you to format your message model when copying. </param>
        /// <param name="reverse">   Change ordering when copying messages. </param>
        /// <returns> formatted text by <seealso cref="Formatter"/>. If it's {@code null} - {@code MESSAGE#toString()} will be used. </returns>
        public virtual string getSelectedMessagesText(Formatter formatter, bool reverse)
        {
            string copiedText = getSelectedText(formatter, reverse);
            unselectAllItems();
            return copiedText;
        }

        /// <summary>
        /// Copies text to device clipboard and returns selected messages text. Also it does <seealso cref="#unselectAllItems()"/> for you.
        /// </summary>
        /// <param name="context">   The context. </param>
        /// <param name="formatter"> The formatter that allows you to format your message model when copying. </param>
        /// <param name="reverse">   Change ordering when copying messages. </param>
        /// <returns> formatted text by <seealso cref="Formatter"/>. If it's {@code null} - {@code MESSAGE#toString()} will be used. </returns>
        public virtual string copySelectedMessagesText(Context context, Formatter formatter, bool reverse)
        {
            string copiedText = getSelectedText(formatter, reverse);
            copyToClipboard(context, copiedText);
            unselectAllItems();
            return copiedText;
        }

        /// <summary>
        /// Unselect all of the selected messages. Notifies <seealso cref="SelectionListener"/> with zero count.
        /// </summary>
        public virtual void unselectAllItems()
        {
            for (int i = 0; i < items.Count; i++)
            {
                Wrapper wrapper = items[i];
                if (wrapper.isSelected)
                {
                    wrapper.isSelected = false;
                    NotifyItemChanged(i);
                }
            }
            isSelectionModeEnabled = false;
            selectedItemsCount = 0;
            notifySelectionChanged();
        }

        /// <summary>
        /// Deletes all of the selected messages and disables selection mode.
        /// Call <seealso cref="#getSelectedMessages()"/> before calling this method to delete messages from your data source.
        /// </summary>
        public virtual void deleteSelectedMessages()
        {
            IList<MessageData> selectedMessages = SelectedMessages;
            delete(selectedMessages);
            unselectAllItems();
        }

        /// <summary>
        /// Sets click listener for item. Fires ONLY if list is not in selection mode.
        /// </summary>
        /// <param name="onMessageClickListener"> click listener. </param>
        public virtual void setOnMessageClickListener(OnMessageClickListener onMessageClickListener)
        {
            this.onMessageClickListener = onMessageClickListener;
        }

        /// <summary>
        /// Sets long click listener for item. Fires only if selection mode is disabled.
        /// </summary>
        /// <param name="onMessageLongClickListener"> long click listener. </param>
        public virtual void setOnMessageLongClickListener(OnMessageLongClickListener onMessageLongClickListener)
        {
            this.onMessageLongClickListener = onMessageLongClickListener;
        }

        /// <summary>
        /// Set callback to be invoked when list scrolled to top.
        /// </summary>
        /// <param name="loadMoreListener"> listener. </param>
        public virtual OnLoadMoreListener LoadMoreListener
        {
            set
            {
                this.loadMoreListener = value;
            }
        }

        /// <summary>
        /// Sets custom <seealso cref="DateFormatter.Formatter"/> for text representation of date headers.
        /// </summary>
        public virtual DateFormatter.Formatter DateHeadersFormatter
        {
            set
            {
                this.dateHeadersFormatter = value;
            }
        }

        /*
		* PRIVATE METHODS
		* */
        private void recountDateHeaders()
        {
            IList<int?> indicesToDelete = new List<int?>();

            for (int i = 0; i < items.Count; i++)
            {
                Wrapper wrapper = items[i];
                if (wrapper.item.Type == MessageData.DataType.Date)
                {
                    if (i == 0)
                    {
                        indicesToDelete.Add(i);
                    }
                    else
                    {
                        if (items[i - 1].item.Type == MessageData.DataType.Date)
                        {
                            indicesToDelete.Add(i);
                        }
                    }
                }
            }

            indicesToDelete.Reverse();
            foreach (int i in indicesToDelete)
            {
                items.RemoveAt(i);
                NotifyItemRemoved(i);
            }
        }

        private void generateDateHeaders(IList<MessageData> messages)
        {
            for (int i = 0; i < messages.Count; i++)
            {
                MessageData message = messages[i];
                this.items.Add(new Wrapper(this, message));
                if (messages.Count > i + 1)
                {
                    MessageData nextMessage = messages[i + 1];
                    if (!DateFormatter.IsSameDay(message.CreatedAt, nextMessage.CreatedAt))
                    {
                        var dateMessage = new MessageData { CreatedAt = message.CreatedAt, Type = MessageData.DataType.Date };
                        this.items.Add(new Wrapper(this, dateMessage));
                    }
                }
                else
                {
                    var dateMessage = new MessageData { CreatedAt = message.CreatedAt, Type = MessageData.DataType.Date };
                    this.items.Add(new Wrapper(this, dateMessage));
                }
            }
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @SuppressWarnings("unchecked") private int getMessagePositionById(String id)
        private int getMessagePositionById(string id)
        {
            for (int i = 0; i < items.Count; i++)
            {
                Wrapper wrapper = items[i];
                if (wrapper.item is IMessage)
                {
                    MessageData message = (MessageData)wrapper.item;
                    if (message.Id != null && message.Id.Equals(id))
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @SuppressWarnings("unchecked") private boolean isPreviousSameDate(int position, java.util.Date dateToCompare)
        private bool isPreviousSameDate(int position, Date dateToCompare)
        {
            if (items.Count <= position)
            {
                return false;
            }
            if (items[position].item is IMessage)
            {
                Date previousPositionDate = ((MessageData)items[position].item).CreatedAt;
                return DateFormatter.IsSameDay(dateToCompare, previousPositionDate);
            }
            else
            {
                return false;
            }
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @SuppressWarnings("unchecked") private boolean isPreviousSameAuthor(String id, int position)
        private bool isPreviousSameAuthor(string id, int position)
        {
            int prevPosition = position + 1;
            if (items.Count <= prevPosition)
            {
                return false;
            }

            if (items[prevPosition].item is IMessage)
            {
                return ((MessageData)items[prevPosition].item).User.Id.Equals(id);
            }
            else
            {
                return false;
            }
        }

        private void incrementSelectedItemsCount()
        {
            selectedItemsCount++;
            notifySelectionChanged();
        }

        private void decrementSelectedItemsCount()
        {
            selectedItemsCount--;
            isSelectionModeEnabled = selectedItemsCount > 0;

            notifySelectionChanged();
        }

        private void notifySelectionChanged()
        {
            if (selectionListener != null)
            {
                selectionListener.onSelectionChanged(selectedItemsCount);
            }
        }

        private void notifyMessageClicked(MessageData message)
        {
            if (onMessageClickListener != null)
            {
                onMessageClickListener.onMessageClick(message);
            }
        }

        private void notifyMessageLongClicked(MessageData message)
        {
            if (onMessageLongClickListener != null)
            {
                onMessageLongClickListener.onMessageLongClick(message);
            }
        }

        //JAVA TO C# CONVERTER WARNING: 'final' parameters are not available in .NET:
        //ORIGINAL LINE: private android.view.View.OnClickListener getMessageClickListener(final Wrapper<MESSAGE> wrapper)
        private MyOnClickListener getMessageClickListener(Wrapper wrapper)
        {
            return new MyOnClickListener(this, wrapper);
        }

        public class MyOnClickListener : Java.Lang.Object, View.IOnClickListener
        {
            private readonly MessagesListAdapter outerInstance;

            private Wrapper wrapper;

            public MyOnClickListener(MessagesListAdapter outerInstance, Wrapper wrapper)
            {
                this.outerInstance = outerInstance;
                this.wrapper = wrapper;
            }

            public void OnClick(View view)
            {
                if (outerInstance.selectionListener != null && isSelectionModeEnabled)
                {
                    wrapper.isSelected = !wrapper.isSelected;

                    if (wrapper.isSelected)
                    {
                        outerInstance.incrementSelectedItemsCount();
                    }
                    else
                    {
                        outerInstance.decrementSelectedItemsCount();
                    }

                    MessageData message = (wrapper.item);
                    outerInstance.NotifyItemChanged(outerInstance.getMessagePositionById(message.Id));
                }
                else
                {
                    outerInstance.notifyMessageClicked(wrapper.item);
                }
            }
        }

        //JAVA TO C# CONVERTER WARNING: 'final' parameters are not available in .NET:
        //ORIGINAL LINE: private android.view.View.OnLongClickListener getMessageLongClickListener(final Wrapper<MESSAGE> wrapper)
        private MyOnLongClickListener getMessageLongClickListener(Wrapper wrapper)
        {
            return new MyOnLongClickListener(this, wrapper);
        }

        public class MyOnLongClickListener : Java.Lang.Object, View.IOnLongClickListener
        {
            private readonly MessagesListAdapter outerInstance;

            private Wrapper wrapper;

            public MyOnLongClickListener(MessagesListAdapter outerInstance, Wrapper wrapper)
            {
                this.outerInstance = outerInstance;
                this.wrapper = wrapper;
            }

            public bool OnLongClick(View view)
            {
                if (outerInstance.selectionListener == null)
                {
                    outerInstance.notifyMessageLongClicked(wrapper.item);
                    return true;
                }
                else
                {
                    isSelectionModeEnabled = true;
                    view.CallOnClick();
                    return true;
                }
            }
        }

        private string getSelectedText(Formatter formatter, bool reverse)
        {
            StringBuilder builder = new StringBuilder();

            List<MessageData> selectedMessages = SelectedMessages;
            if (reverse)
            {
                selectedMessages.Reverse();
            }

            foreach (MessageData message in selectedMessages)
            {
                builder.Append(formatter == null ? message.ToString() : formatter.format(message));
                builder.Append("\n\n");
            }
            builder.Remove(builder.Length - 2, builder.Length - builder.Length - 2).Insert(builder.Length - 2, "");

            return builder.ToString();
        }

        private void copyToClipboard(Context context, string copiedText)
        {
            ClipboardManager clipboard = (ClipboardManager)context.GetSystemService(Context.ClipboardService);
            ClipData clip = ClipData.NewPlainText(copiedText, copiedText);
            clipboard.PrimaryClip = clip;
        }

        internal virtual RecyclerView.LayoutManager LayoutManager
        {
            set
            {
                this.layoutManager = value;
            }
        }

        /*
		* WRAPPER
		* */
        public class Wrapper
        {
            private readonly MessagesListAdapter outerInstance;

            internal MessageData item;
            internal bool isSelected;

            internal Wrapper(MessagesListAdapter outerInstance, MessageData item)
            {
                this.outerInstance = outerInstance;
                this.item = item;
            }
        }

        /*
		* LISTENERS
		* */

        /// <summary>
        /// Interface definition for a callback to be invoked when next part of messages need to be loaded.
        /// </summary>
        public interface OnLoadMoreListener
        {

            /// <summary>
            /// Fires when user scrolled to the end of list.
            /// </summary>
            /// <param name="page">            next page to download. </param>
            /// <param name="totalItemsCount"> current items count. </param>
            void onLoadMore(int page, int totalItemsCount);
        }

        /// <summary>
        /// Interface definition for a callback to be invoked when selected messages count is changed.
        /// </summary>
        public interface SelectionListener
        {

            /// <summary>
            /// Fires when selected items count is changed.
            /// </summary>
            /// <param name="count"> count of selected items. </param>
            void onSelectionChanged(int count);
        }

        /// <summary>
        /// Interface definition for a callback to be invoked when message item is clicked.
        /// </summary>
        public interface OnMessageClickListener
        {

            /// <summary>
            /// Fires when message was clicked.
            /// </summary>
            /// <param name="message"> clicked message. </param>
            void onMessageClick(MessageData message);
        }

        /// <summary>
        /// Interface definition for a callback to be invoked when message item is long clicked.
        /// </summary>
        public interface OnMessageLongClickListener
        {

            /// <summary>
            /// Fires when message was long clicked.
            /// </summary>
            /// <param name="message"> clicked message. </param>
            void onMessageLongClick(MessageData message);
        }

        /// <summary>
        /// Interface used to format your message model when copying.
        /// </summary>
        public interface Formatter
        {

            /// <summary>
            /// Formats an string representation of the message object.
            /// </summary>
            /// <param name="message"> The object that should be formatted. </param>
            /// <returns> Formatted text. </returns>
            string format(MessageData message);
        }
    }
}