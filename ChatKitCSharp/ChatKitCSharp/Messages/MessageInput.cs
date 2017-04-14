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
using Android.Text;
using Android.Util;
using Java.Lang;
using Android.Graphics.Drawables;
using static Android.Icu.Text.MessageFormat;
using Android.Content.Res;

namespace ChatKitCSharp.Messages
{
    public class MessageInput : RelativeLayout, View.IOnClickListener, ITextWatcher
    {
        public EditText messageInput;
        protected ImageButton messageSendButton;
        protected ImageButton attachmentButton;
        protected Space sendButtonSpace, attachmentButtonSpace;

        private string input;
        public InputListener inputListener;
        public AttachmentsListener attachmentsListener;

        public MessageInput(Context context) : base(context)
        {
            Init(context);
        }

        public MessageInput(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Init(context, attrs);
        }

        public MessageInput(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Init(context, attrs);
        }

        public void SetInputListener(InputListener listener)
        {
            this.inputListener = listener;
        }

        public void SetAttachmentsListener(AttachmentsListener listener)
        {
            this.attachmentsListener = listener;
        }

        public EditText GetInputEditText()
        {
            return messageInput;
        }

        public ImageButton GetButton()
        {
            return messageSendButton;
        }

        public void OnClick(View v)
        {
            int id = v.Id;
            if (id == Resource.Id.messageSendButton)
            {
                bool isSubmitted = OnSubmit();
                if (isSubmitted)
                {
                    messageInput.Text = "";
                }
            }
            else if (id == Resource.Id.attachmentButton)
            {
                OnAddAttachments();
            }
        }

        public void AfterTextChanged(IEditable s)
        {
        }

        public void BeforeTextChanged(ICharSequence s, int start, int count, int after)
        {
        }

        public void OnTextChanged(ICharSequence s, int start, int before, int count)
        {
            input = s.ToString();
            messageSendButton.Enabled = input.Length > 0;
        }

        private bool OnSubmit()
        {
            return inputListener != null && inputListener.OnSubmit(input);
        }

        private void OnAddAttachments()
        {
            if (attachmentsListener != null) attachmentsListener.OnAddAttachments();
        }

        private void Init(Context context, IAttributeSet attrs)
        {
            Init(context);
            MessageInputStyle style = MessageInputStyle.Parse(context, attrs);

            this.messageInput.SetMaxLines(style.getInputMaxLines());
            this.messageInput.Hint = style.getInputHint();
            this.messageInput.Text = style.getInputText();
            this.messageInput.SetTextSize(ComplexUnitType.Px, style.getInputTextSize());
            this.messageInput.SetTextColor(new ColorStateList(new int[][] { new int[] { 0 } }, new int[] { style.getInputTextColor() }));
            this.messageInput.SetHintTextColor(new ColorStateList(new int[][] { new int[] { 0 } }, new int[] { style.getInputHintColor() }));
            this.messageInput.Background = style.getInputBackground();
            SetCursor(style.getInputCursorDrawable());

            this.attachmentButton.Visibility = style.showAttachmentButton() ? ViewStates.Visible : ViewStates.Gone;
            this.attachmentButton.Background = style.getAttachmentButtonBackground();
            this.attachmentButton.SetImageDrawable(style.getAttachmentButtonIcon());
            this.attachmentButton.LayoutParameters.Width = style.getAttachmentButtonWidth();
            this.attachmentButton.LayoutParameters.Height = style.getAttachmentButtonHeight();

            this.attachmentButtonSpace.Visibility = style.showAttachmentButton() ? ViewStates.Visible : ViewStates.Gone;
            this.attachmentButtonSpace.LayoutParameters.Width = style.getAttachmentButtonMargin();

            this.messageSendButton.Background = style.getInputButtonBackground();
            this.messageSendButton.SetImageDrawable(style.getInputButtonIcon());
            this.messageSendButton.LayoutParameters.Width = style.getInputButtonWidth();
            this.messageSendButton.LayoutParameters.Height = style.getInputButtonHeight();
            this.sendButtonSpace.LayoutParameters.Width = style.getInputButtonMargin();

            if (PaddingLeft == 0
                    && PaddingRight == 0
                    && PaddingTop == 0
                    && PaddingBottom == 0)
            {
                SetPadding(
                        style.getInputDefaultPaddingLeft(),
                        style.getInputDefaultPaddingTop(),
                        style.getInputDefaultPaddingRight(),
                        style.getInputDefaultPaddingBottom()
                );
            }
        }

        private void Init(Context context)
        {
            Inflate(context, Resource.Layout.view_message_input, this);

            messageInput = (EditText)FindViewById(Resource.Id.messageInput);
            messageSendButton = (ImageButton)FindViewById(Resource.Id.messageSendButton);
            attachmentButton = (ImageButton)FindViewById(Resource.Id.attachmentButton);
            sendButtonSpace = (Space)FindViewById(Resource.Id.sendButtonSpace);
            attachmentButtonSpace = (Space)FindViewById(Resource.Id.attachmentButtonSpace);
            messageSendButton.SetOnClickListener(this);
            attachmentButton.SetOnClickListener(this);
            messageInput.AddTextChangedListener(this);
            messageInput.Text = "";
        }

        private void SetCursor(Drawable drawable)
        {
            try
            {

                IntPtr IntPtrtextViewClass = JNIEnv.FindClass(typeof(TextView));
                IntPtr mCursorDrawableResProperty = JNIEnv.GetFieldID(IntPtrtextViewClass, "mCursorDrawableRes", "I");
                JNIEnv.SetField(messageInput.Handle, mCursorDrawableResProperty, Resources.GetIdentifier(nameof(drawable), null, null)); // replace 0 with a Resource.Drawable.my_cursor
            }
            catch (Java.Lang.Exception)
            {

            }
        }

        public interface InputListener
        {
            bool OnSubmit(string input);
        }

        public interface AttachmentsListener
        {
            void OnAddAttachments();
        }
    }
}