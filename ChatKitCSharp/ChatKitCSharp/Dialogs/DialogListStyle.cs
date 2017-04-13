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
using ChatKitCSharp.Commons;
using Android.Util;
using Android.Content.Res;
using Android.Graphics;

namespace ChatKitCSharp.Dialogs
{
    public class DialogListStyle : Style
    {
        public int DialogTitleTextColor { get; set; }
        public int DialogTitleTextSize { get; set; }
        public int DialogTitleTextStyle { get; set; }
        public int DialogUnreadTitleTextColor { get; set; }
        public int DialogUnreadTitleTextStyle { get; set; }
        public int DialogMessageTextColor { get; set; }
        public int DialogMessageTextSize { get; set; }
        public int DialogMessageTextStyle { get; set; }
        public int DialogUnreadMessageTextColor { get; set; }
        public int DialogUnreadMessageTextStyle { get; set; }
        public int DialogDateColor { get; set; }
        public int DialogDateSize { get; set; }
        public int DialogDateStyle { get; set; }
        public int DialogUnreadDateColor { get; set; }
        public int DialogUnreadDateStyle { get; set; }
        public bool DialogUnreadBubbleEnabled { get; set; }
        public int DialogUnreadBubbleTextColor { get; set; }
        public int DialogUnreadBubbleTextSize { get; set; }
        public int DialogUnreadBubbleTextStyle { get; set; }
        public int DialogUnreadBubbleBackgroundColor { get; set; }
        public int DialogAvatarWidth { get; set; }
        public int DialogAvatarHeight { get; set; }
        public bool DialogMessageAvatarEnabled { get; set; }
        public int DialogMessageAvatarWidth { get; set; }
        public int DialogMessageAvatarHeight { get; set; }
        public bool DialogDividerEnabled { get; set; }
        public int DialogDividerColor { get; set; }
        public int DialogDividerLeftPadding { get; set; }
        public int DialogDividerRightPadding { get; set; }
        public int DialogItemBackground { get; set; }
        public int DialogUnreadItemBackground { get; set; }

        public static DialogListStyle Parse(Context context, IAttributeSet attrs)
        {
            DialogListStyle style = new DialogListStyle(context, attrs);
            TypedArray typedArray = context.ObtainStyledAttributes(attrs, Resource.Styleable.DialogsList);

            // Item Background
            style.DialogItemBackground = typedArray.GetColor(Resource.Styleable.DialogsList_dialogItemBackground, style.GetColor(Resource.Color.transparent));
            style.DialogUnreadItemBackground = typedArray.GetColor(Resource.Styleable.DialogsList_dialogUnreadItemBackground, style.GetColor(Resource.Color.transparent));

            // Title text
            style.DialogTitleTextColor = typedArray.GetColor(Resource.Styleable.DialogsList_dialogTitleTextColor, style.GetColor(Resource.Color.dialog_title_text));
            style.DialogTitleTextSize = typedArray.GetDimensionPixelSize(Resource.Styleable.DialogsList_dialogTitleTextSize, context.Resources.GetDimensionPixelSize(Resource.Dimension.dialog_title_text_size));
            style.DialogTitleTextStyle = typedArray.GetInt(Resource.Styleable.DialogsList_dialogTitleTextStyle, 0);

            // Title unread text
            style.DialogUnreadTitleTextColor = typedArray.GetColor(Resource.Styleable.DialogsList_dialogUnreadTitleTextColor, style.GetColor(Resource.Color.dialog_title_text));
            style.DialogUnreadTitleTextStyle = typedArray.GetInt(Resource.Styleable.DialogsList_dialogUnreadTitleTextStyle, 0);

            // Message text
            style.DialogMessageTextColor = typedArray.GetColor(Resource.Styleable.DialogsList_dialogMessageTextColor, style.GetColor(Resource.Color.dialog_message_text));
            style.DialogMessageTextSize = typedArray.GetDimensionPixelSize(Resource.Styleable.DialogsList_dialogMessageTextSize, context.Resources.GetDimensionPixelSize(Resource.Dimension.dialog_message_text_size));
            style.DialogMessageTextStyle = typedArray.GetInt(Resource.Styleable.DialogsList_dialogMessageTextStyle, 0);

            // Message unread text
            style.DialogUnreadMessageTextColor = typedArray.GetColor(Resource.Styleable.DialogsList_dialogUnreadMessageTextColor, style.GetColor(Resource.Color.dialog_message_text));
            style.DialogUnreadMessageTextStyle = typedArray.GetInt(Resource.Styleable.DialogsList_dialogUnreadMessageTextStyle, 0);

            // Date text
            style.DialogDateColor = typedArray.GetColor(Resource.Styleable.DialogsList_dialogDateColor, style.GetColor(Resource.Color.dialog_date_text));
            style.DialogDateSize = typedArray.GetDimensionPixelSize(Resource.Styleable.DialogsList_dialogDateSize, context.Resources.GetDimensionPixelSize(Resource.Dimension.dialog_date_text_size));
            style.DialogDateStyle = typedArray.GetInt(Resource.Styleable.DialogsList_dialogDateStyle, 0);

            // Date unread text
            style.DialogUnreadDateColor = typedArray.GetColor(Resource.Styleable.DialogsList_dialogUnreadDateColor, style.GetColor(Resource.Color.dialog_date_text));
            style.DialogUnreadDateStyle = typedArray.GetInt(Resource.Styleable.DialogsList_dialogUnreadDateStyle, 0);

            // Unread bubble
            style.DialogUnreadBubbleEnabled = typedArray.GetBoolean(Resource.Styleable.DialogsList_dialogUnreadBubbleEnabled, true);
            style.DialogUnreadBubbleBackgroundColor = typedArray.GetColor(Resource.Styleable.DialogsList_dialogUnreadBubbleBackgroundColor, style.GetColor(Resource.Color.dialog_unread_bubble));

            // Unread bubble text
            style.DialogUnreadBubbleTextColor = typedArray.GetColor(Resource.Styleable.DialogsList_dialogUnreadBubbleTextColor, style.GetColor(Resource.Color.dialog_unread_text));
            style.DialogUnreadBubbleTextSize = typedArray.GetDimensionPixelSize(Resource.Styleable.DialogsList_dialogUnreadBubbleTextSize, context.Resources.GetDimensionPixelSize(Resource.Dimension.dialog_unread_bubble_text_size));
            style.DialogUnreadBubbleTextStyle = typedArray.GetInt(Resource.Styleable.DialogsList_dialogUnreadBubbleTextStyle, 0);

            // Avatar
            style.DialogAvatarWidth = typedArray.GetDimensionPixelSize(Resource.Styleable.DialogsList_dialogAvatarWidth, context.Resources.GetDimensionPixelSize(Resource.Dimension.dialog_avatar_width));
            style.DialogAvatarHeight = typedArray.GetDimensionPixelSize(Resource.Styleable.DialogsList_dialogAvatarHeight, context.Resources.GetDimensionPixelSize(Resource.Dimension.dialog_avatar_height));

            // Last message avatar
            style.DialogMessageAvatarEnabled = typedArray.GetBoolean(Resource.Styleable.DialogsList_dialogMessageAvatarEnabled, true);
            style.DialogMessageAvatarWidth = typedArray.GetDimensionPixelSize(Resource.Styleable.DialogsList_dialogMessageAvatarWidth, context.Resources.GetDimensionPixelSize(Resource.Dimension.dialog_last_message_avatar_width));
            style.DialogMessageAvatarHeight = typedArray.GetDimensionPixelSize(Resource.Styleable.DialogsList_dialogMessageAvatarHeight, context.Resources.GetDimensionPixelSize(Resource.Dimension.dialog_last_message_avatar_height));

            // Divider
            style.DialogDividerEnabled = typedArray.GetBoolean(Resource.Styleable.DialogsList_dialogDividerEnabled, true);
            style.DialogDividerColor = typedArray.GetColor(Resource.Styleable.DialogsList_dialogDividerColor, style.GetColor(Resource.Color.dialog_divider));
            style.DialogDividerLeftPadding = typedArray.GetDimensionPixelSize(Resource.Styleable.DialogsList_dialogDividerLeftPadding, context.Resources.GetDimensionPixelSize(Resource.Dimension.dialog_divider_margin_left));
            style.DialogDividerRightPadding = typedArray.GetDimensionPixelSize(Resource.Styleable.DialogsList_dialogDividerRightPadding, context.Resources.GetDimensionPixelSize(Resource.Dimension.dialog_divider_margin_right));

            typedArray.Recycle();

            return style;
        }

        private DialogListStyle(Context context, IAttributeSet attrs) : base(context, attrs)
        {

        }
    }
}