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
using ChatKitLibrary.Commons;
using Android.Graphics.Drawables;
using Android.Util;
using Android.Support.V4.Graphics.Drawable;
using Android.Content.Res;

namespace ChatKitLibrary.Messages
{
    public class MessageInputStyle : Style
    {
        private static int DEFAULT_MAX_LINES = 5;

        private bool _showAttachmentButton;

        private int attachmentButtonBackground;
        private int attachmentButtonDefaultBgColor;
        private int attachmentButtonDefaultBgPressedColor;
        private int attachmentButtonDefaultBgDisabledColor;

        private int attachmentButtonIcon;
        private int attachmentButtonDefaultIconColor;
        private int attachmentButtonDefaultIconPressedColor;
        private int attachmentButtonDefaultIconDisabledColor;

        private int attachmentButtonWidth;
        private int attachmentButtonHeight;
        private int attachmentButtonMargin;

        private int inputButtonBackground;
        private int inputButtonDefaultBgColor;
        private int inputButtonDefaultBgPressedColor;
        private int inputButtonDefaultBgDisabledColor;

        private int inputButtonIcon;
        private int inputButtonDefaultIconColor;
        private int inputButtonDefaultIconPressedColor;
        private int inputButtonDefaultIconDisabledColor;

        private int inputButtonWidth;
        private int inputButtonHeight;
        private int inputButtonMargin;

        private int inputMaxLines;
        private String inputHint;
        private String inputText;

        private int inputTextSize;
        private int inputTextColor;
        private int inputHintColor;

        private Drawable inputBackground;
        private Drawable inputCursorDrawable;

        private int inputDefaultPaddingLeft;
        private int inputDefaultPaddingRight;
        private int inputDefaultPaddingTop;
        private int inputDefaultPaddingBottom;

        public static MessageInputStyle Parse(Context context, IAttributeSet attrs)
        {
            MessageInputStyle style = new MessageInputStyle(context, attrs);
            TypedArray typedArray = context.ObtainStyledAttributes(attrs, Resource.Styleable.MessageInput);
            
            style._showAttachmentButton = typedArray.GetBoolean(Resource.Styleable.MessageInput_showAttachmentButton, false);

            style.attachmentButtonBackground = typedArray.GetResourceId(Resource.Styleable.MessageInput_attachmentButtonBackground, -1);
            style.attachmentButtonDefaultBgColor = typedArray.GetColor(Resource.Styleable.MessageInput_attachmentButtonDefaultBgColor,
                    style.GetColor(Resource.Color.white_four));
            style.attachmentButtonDefaultBgPressedColor = typedArray.GetColor(Resource.Styleable.MessageInput_attachmentButtonDefaultBgPressedColor,
                    style.GetColor(Resource.Color.white_five));
            style.attachmentButtonDefaultBgDisabledColor = typedArray.GetColor(Resource.Styleable.MessageInput_attachmentButtonDefaultBgDisabledColor,
                    style.GetColor(Resource.Color.transparent));

            style.attachmentButtonIcon = typedArray.GetResourceId(Resource.Styleable.MessageInput_attachmentButtonIcon, -1);
            style.attachmentButtonDefaultIconColor = typedArray.GetColor(Resource.Styleable.MessageInput_attachmentButtonDefaultIconColor,
                    style.GetColor(Resource.Color.cornflower_blue_two));
            style.attachmentButtonDefaultIconPressedColor = typedArray.GetColor(Resource.Styleable.MessageInput_attachmentButtonDefaultIconPressedColor,
                    style.GetColor(Resource.Color.cornflower_blue_two_dark));
            style.attachmentButtonDefaultIconDisabledColor = typedArray.GetColor(Resource.Styleable.MessageInput_attachmentButtonDefaultIconDisabledColor,
                    style.GetColor(Resource.Color.cornflower_blue_light_40));

            style.attachmentButtonWidth = typedArray.GetDimensionPixelSize(Resource.Styleable.MessageInput_attachmentButtonWidth, style.GetDimension(Resource.Dimension.input_button_width));
            style.attachmentButtonHeight = typedArray.GetDimensionPixelSize(Resource.Styleable.MessageInput_attachmentButtonHeight, style.GetDimension(Resource.Dimension.input_button_height));
            style.attachmentButtonMargin = typedArray.GetDimensionPixelSize(Resource.Styleable.MessageInput_attachmentButtonMargin, style.GetDimension(Resource.Dimension.input_button_margin));

            style.inputButtonBackground = typedArray.GetResourceId(Resource.Styleable.MessageInput_inputButtonBackground, -1);
            style.inputButtonDefaultBgColor = typedArray.GetColor(Resource.Styleable.MessageInput_inputButtonDefaultBgColor,
                    style.GetColor(Resource.Color.cornflower_blue_two));
            style.inputButtonDefaultBgPressedColor = typedArray.GetColor(Resource.Styleable.MessageInput_inputButtonDefaultBgPressedColor,
                    style.GetColor(Resource.Color.cornflower_blue_two_dark));
            style.inputButtonDefaultBgDisabledColor = typedArray.GetColor(Resource.Styleable.MessageInput_inputButtonDefaultBgDisabledColor,
                    style.GetColor(Resource.Color.white_four));

            style.inputButtonIcon = typedArray.GetResourceId(Resource.Styleable.MessageInput_inputButtonIcon, -1);
            style.inputButtonDefaultIconColor = typedArray.GetColor(Resource.Styleable.MessageInput_inputButtonDefaultIconColor,
                    style.GetColor(Resource.Color.white));
            style.inputButtonDefaultIconPressedColor = typedArray.GetColor(Resource.Styleable.MessageInput_inputButtonDefaultIconPressedColor,
                    style.GetColor(Resource.Color.white));
            style.inputButtonDefaultIconDisabledColor = typedArray.GetColor(Resource.Styleable.MessageInput_inputButtonDefaultIconDisabledColor,
                    style.GetColor(Resource.Color.warm_grey));

            style.inputButtonWidth = typedArray.GetDimensionPixelSize(Resource.Styleable.MessageInput_inputButtonWidth, style.GetDimension(Resource.Dimension.input_button_width));
            style.inputButtonHeight = typedArray.GetDimensionPixelSize(Resource.Styleable.MessageInput_inputButtonHeight, style.GetDimension(Resource.Dimension.input_button_height));
            style.inputButtonMargin = typedArray.GetDimensionPixelSize(Resource.Styleable.MessageInput_inputButtonMargin, style.GetDimension(Resource.Dimension.input_button_margin));

            style.inputMaxLines = typedArray.GetInt(Resource.Styleable.MessageInput_inputMaxLines, DEFAULT_MAX_LINES);
            style.inputHint = typedArray.GetString(Resource.Styleable.MessageInput_inputHint);
            style.inputText = typedArray.GetString(Resource.Styleable.MessageInput_inputText);

            style.inputTextSize = typedArray.GetDimensionPixelSize(Resource.Styleable.MessageInput_inputTextSize, style.GetDimension(Resource.Dimension.input_text_size));
            style.inputTextColor = typedArray.GetColor(Resource.Styleable.MessageInput_inputTextColor, style.GetColor(Resource.Color.dark_grey_two));
            style.inputHintColor = typedArray.GetColor(Resource.Styleable.MessageInput_inputHintColor, style.GetColor(Resource.Color.warm_grey_three));

            style.inputBackground = typedArray.GetDrawable(Resource.Styleable.MessageInput_inputBackground);
            style.inputCursorDrawable = typedArray.GetDrawable(Resource.Styleable.MessageInput_inputCursorDrawable);

            typedArray.Recycle();

            style.inputDefaultPaddingLeft = style.GetDimension(Resource.Dimension.input_padding_left);
            style.inputDefaultPaddingRight = style.GetDimension(Resource.Dimension.input_padding_right);
            style.inputDefaultPaddingTop = style.GetDimension(Resource.Dimension.input_padding_top);
            style.inputDefaultPaddingBottom = style.GetDimension(Resource.Dimension.input_padding_bottom);

            return style;
        }

        private MessageInputStyle(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        private Drawable getSelector(int normalColor, int pressedColor,
                                     int disabledColor, int shape)
        {

            Drawable drawable = DrawableCompat.Wrap(GetVectorDrawable(shape)).Mutate();
            DrawableCompat.SetTintList(
                    drawable,
                    new ColorStateList(
                            new int[][]{
                                new int[]{Android.Resource.Attribute.StateEnabled, -Android.Resource.Attribute.StatePressed},
                                new int[]{Android.Resource.Attribute.StateEnabled, Android.Resource.Attribute.StatePressed},
                                new int[]{-Android.Resource.Attribute.StateEnabled }
                            },
                            new int[] { normalColor, pressedColor, disabledColor }
                    ));
            return drawable;
        }

        public bool showAttachmentButton()
        {
            return _showAttachmentButton;
        }

        public Drawable getAttachmentButtonBackground()
        {
            if (attachmentButtonBackground == -1)
            {
                return getSelector(attachmentButtonDefaultBgColor, attachmentButtonDefaultBgPressedColor,
                        attachmentButtonDefaultBgDisabledColor, Resource.Drawable.mask);
            }
            else
            {
                return GetDrawable(attachmentButtonBackground);
            }
        }

        public Drawable getAttachmentButtonIcon()
        {
            if (attachmentButtonIcon == -1)
            {
                return getSelector(attachmentButtonDefaultIconColor, attachmentButtonDefaultIconPressedColor,
                        attachmentButtonDefaultIconDisabledColor, Resource.Drawable.ic_add_attachment);
            }
            else
            {
                return GetDrawable(attachmentButtonIcon);
            }
        }

        public int getAttachmentButtonWidth()
        {
            return attachmentButtonWidth;
        }

        public int getAttachmentButtonHeight()
        {
            return attachmentButtonHeight;
        }

        public int getAttachmentButtonMargin()
        {
            return attachmentButtonMargin;
        }

        public Drawable getInputButtonBackground()
        {
            if (inputButtonBackground == -1)
            {
                return getSelector(inputButtonDefaultBgColor, inputButtonDefaultBgPressedColor,
                        inputButtonDefaultBgDisabledColor, Resource.Drawable.mask);
            }
            else
            {
                return GetDrawable(inputButtonBackground);
            }
        }

        public Drawable getInputButtonIcon()
        {
            if (inputButtonIcon == -1)
            {
                return getSelector(inputButtonDefaultIconColor, inputButtonDefaultIconPressedColor,
                        inputButtonDefaultIconDisabledColor, Resource.Drawable.ic_send);
            }
            else
            {
                return GetDrawable(inputButtonIcon);
            }
        }

        public int getInputButtonMargin()
        {
            return inputButtonMargin;
        }

        public int getInputButtonWidth()
        {
            return inputButtonWidth;
        }

        public int getInputButtonHeight()
        {
            return inputButtonHeight;
        }

        public int getInputMaxLines()
        {
            return inputMaxLines;
        }

        public String getInputHint()
        {
            return inputHint;
        }

        public String getInputText()
        {
            return inputText;
        }

        public int getInputTextSize()
        {
            return inputTextSize;
        }

        public int getInputTextColor()
        {
            return inputTextColor;
        }

        public int getInputHintColor()
        {
            return inputHintColor;
        }

        public Drawable getInputBackground()
        {
            return inputBackground;
        }

        public Drawable getInputCursorDrawable()
        {
            return inputCursorDrawable;
        }

        public int getInputDefaultPaddingLeft()
        {
            return inputDefaultPaddingLeft;
        }

        public int getInputDefaultPaddingRight()
        {
            return inputDefaultPaddingRight;
        }

        public int getInputDefaultPaddingTop()
        {
            return inputDefaultPaddingTop;
        }

        public int getInputDefaultPaddingBottom()
        {
            return inputDefaultPaddingBottom;
        }
    }
}