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
using Android.Graphics;
using Android.Content.Res;
using Android.Support.V4.Graphics.Drawable;
using Android.Util;

namespace ChatKitLibrary.Messages
{
    public class MessagesListStyle : Style
    {
        private int textAutoLinkMask;
        private int incomingTextLinkColor;
        private int outcomingTextLinkColor;

        private int incomingAvatarWidth;
        private int incomingAvatarHeight;

        private int incomingBubbleDrawable;
        private int incomingDefaultBubbleColor;
        private int incomingDefaultBubblePressedColor;
        private int incomingDefaultBubbleSelectedColor;

        private int incomingImageOverlayDrawable;
        private int incomingDefaultImageOverlayPressedColor;
        private int incomingDefaultImageOverlaySelectedColor;

        private int incomingDefaultBubblePaddingLeft;
        private int incomingDefaultBubblePaddingRight;
        private int incomingDefaultBubblePaddingTop;
        private int incomingDefaultBubblePaddingBottom;

        private int incomingTextColor;
        private int incomingTextSize;
        private int incomingTextStyle;

        private int incomingTimeTextColor;
        private int incomingTimeTextSize;
        private int incomingTimeTextStyle;

        private int incomingImageTimeTextColor;
        private int incomingImageTimeTextSize;
        private int incomingImageTimeTextStyle;

        private int outcomingBubbleDrawable;
        private int outcomingDefaultBubbleColor;
        private int outcomingDefaultBubblePressedColor;
        private int outcomingDefaultBubbleSelectedColor;

        private int outcomingImageOverlayDrawable;
        private int outcomingDefaultImageOverlayPressedColor;
        private int outcomingDefaultImageOverlaySelectedColor;

        private int outcomingDefaultBubblePaddingLeft;
        private int outcomingDefaultBubblePaddingRight;
        private int outcomingDefaultBubblePaddingTop;
        private int outcomingDefaultBubblePaddingBottom;

        private int outcomingTextColor;
        private int outcomingTextSize;
        private int outcomingTextStyle;

        private int outcomingTimeTextColor;
        private int outcomingTimeTextSize;
        private int outcomingTimeTextStyle;

        private int outcomingImageTimeTextColor;
        private int outcomingImageTimeTextSize;
        private int outcomingImageTimeTextStyle;

        private int dateHeaderPadding;
        private String dateHeaderFormat;
        private int dateHeaderTextColor;
        private int dateHeaderTextSize;
        private int dateHeaderTextStyle;

        public static MessagesListStyle Parse(Context context, IAttributeSet attrs)
        {
            MessagesListStyle style = new MessagesListStyle(context, attrs);
            TypedArray typedArray = context.ObtainStyledAttributes(attrs, Resource.Styleable.MessagesList);

            style.textAutoLinkMask = typedArray.GetInt(Resource.Styleable.MessagesList_textAutoLink, 0);
            style.incomingTextLinkColor = typedArray.GetColor(Resource.Styleable.MessagesList_incomingTextLinkColor,
                    style.GetSystemAccentColor());
            style.outcomingTextLinkColor = typedArray.GetColor(Resource.Styleable.MessagesList_outcomingTextLinkColor,
                    style.GetSystemAccentColor());

            style.incomingAvatarWidth = typedArray.GetDimensionPixelSize(Resource.Styleable.MessagesList_incomingAvatarWidth,
                    style.GetDimension(Resource.Dimension.message_avatar_width));
            style.incomingAvatarHeight = typedArray.GetDimensionPixelSize(Resource.Styleable.MessagesList_incomingAvatarHeight,
                    style.GetDimension(Resource.Dimension.message_avatar_height));

            style.incomingBubbleDrawable = typedArray.GetResourceId(Resource.Styleable.MessagesList_incomingBubbleDrawable, -1);
            style.incomingDefaultBubbleColor = typedArray.GetColor(Resource.Styleable.MessagesList_incomingDefaultBubbleColor,
                    style.GetColor(Resource.Color.white_two));
            style.incomingDefaultBubblePressedColor = typedArray.GetColor(Resource.Styleable.MessagesList_incomingDefaultBubblePressedColor,
                    style.GetColor(Resource.Color.white_two));
            style.incomingDefaultBubbleSelectedColor = typedArray.GetColor(Resource.Styleable.MessagesList_incomingDefaultBubbleSelectedColor,
                    style.GetColor(Resource.Color.cornflower_blue_two_24));

            style.incomingImageOverlayDrawable = typedArray.GetResourceId(Resource.Styleable.MessagesList_incomingImageOverlayDrawable, -1);
            style.incomingDefaultImageOverlayPressedColor = typedArray.GetColor(Resource.Styleable.MessagesList_incomingDefaultImageOverlayPressedColor,
                    style.GetColor(Resource.Color.transparent));
            style.incomingDefaultImageOverlaySelectedColor = typedArray.GetColor(Resource.Styleable.MessagesList_incomingDefaultImageOverlaySelectedColor,
                    style.GetColor(Resource.Color.cornflower_blue_light_40));

            style.incomingDefaultBubblePaddingLeft = typedArray.GetDimensionPixelSize(Resource.Styleable.MessagesList_incomingBubblePaddingLeft,
                    style.GetDimension(Resource.Dimension.message_padding_left));
            style.incomingDefaultBubblePaddingRight = typedArray.GetDimensionPixelSize(Resource.Styleable.MessagesList_incomingBubblePaddingRight,
                    style.GetDimension(Resource.Dimension.message_padding_right));
            style.incomingDefaultBubblePaddingTop = typedArray.GetDimensionPixelSize(Resource.Styleable.MessagesList_incomingBubblePaddingTop,
                    style.GetDimension(Resource.Dimension.message_padding_top));
            style.incomingDefaultBubblePaddingBottom = typedArray.GetDimensionPixelSize(Resource.Styleable.MessagesList_incomingBubblePaddingBottom,
                    style.GetDimension(Resource.Dimension.message_padding_bottom));
            style.incomingTextColor = typedArray.GetColor(Resource.Styleable.MessagesList_incomingTextColor,
                    style.GetColor(Resource.Color.dark_grey_two));
            style.incomingTextSize = typedArray.GetDimensionPixelSize(Resource.Styleable.MessagesList_incomingTextSize,
                    style.GetDimension(Resource.Dimension.message_text_size));
            style.incomingTextStyle = typedArray.GetInt(Resource.Styleable.MessagesList_incomingTextStyle, 0);

            style.incomingTimeTextColor = typedArray.GetColor(Resource.Styleable.MessagesList_incomingTimeTextColor,
                    style.GetColor(Resource.Color.warm_grey_four));
            style.incomingTimeTextSize = typedArray.GetDimensionPixelSize(Resource.Styleable.MessagesList_incomingTimeTextSize,
                    style.GetDimension(Resource.Dimension.message_time_text_size));
            style.incomingTimeTextStyle = typedArray.GetInt(Resource.Styleable.MessagesList_incomingTimeTextStyle, 0);

            style.incomingImageTimeTextColor = typedArray.GetColor(Resource.Styleable.MessagesList_incomingImageTimeTextColor,
                    style.GetColor(Resource.Color.warm_grey_four));
            style.incomingImageTimeTextSize = typedArray.GetDimensionPixelSize(Resource.Styleable.MessagesList_incomingImageTimeTextSize,
                    style.GetDimension(Resource.Dimension.message_time_text_size));
            style.incomingImageTimeTextStyle = typedArray.GetInt(Resource.Styleable.MessagesList_incomingImageTimeTextStyle, 0);

            style.outcomingBubbleDrawable = typedArray.GetResourceId(Resource.Styleable.MessagesList_outcomingBubbleDrawable, -1);
            style.outcomingDefaultBubbleColor = typedArray.GetColor(Resource.Styleable.MessagesList_outcomingDefaultBubbleColor,
                    style.GetColor(Resource.Color.cornflower_blue_two));
            style.outcomingDefaultBubblePressedColor = typedArray.GetColor(Resource.Styleable.MessagesList_outcomingDefaultBubblePressedColor,
                    style.GetColor(Resource.Color.cornflower_blue_two));
            style.outcomingDefaultBubbleSelectedColor = typedArray.GetColor(Resource.Styleable.MessagesList_outcomingDefaultBubbleSelectedColor,
                    style.GetColor(Resource.Color.cornflower_blue_two_24));

            style.outcomingImageOverlayDrawable = typedArray.GetResourceId(Resource.Styleable.MessagesList_outcomingImageOverlayDrawable, -1);
            style.outcomingDefaultImageOverlayPressedColor = typedArray.GetColor(Resource.Styleable.MessagesList_outcomingDefaultImageOverlayPressedColor,
                    style.GetColor(Resource.Color.transparent));
            style.outcomingDefaultImageOverlaySelectedColor = typedArray.GetColor(Resource.Styleable.MessagesList_outcomingDefaultImageOverlaySelectedColor,
                    style.GetColor(Resource.Color.cornflower_blue_light_40));

            style.outcomingDefaultBubblePaddingLeft = typedArray.GetDimensionPixelSize(Resource.Styleable.MessagesList_outcomingBubblePaddingLeft,
                    style.GetDimension(Resource.Dimension.message_padding_left));
            style.outcomingDefaultBubblePaddingRight = typedArray.GetDimensionPixelSize(Resource.Styleable.MessagesList_outcomingBubblePaddingRight,
                    style.GetDimension(Resource.Dimension.message_padding_right));
            style.outcomingDefaultBubblePaddingTop = typedArray.GetDimensionPixelSize(Resource.Styleable.MessagesList_outcomingBubblePaddingTop,
                    style.GetDimension(Resource.Dimension.message_padding_top));
            style.outcomingDefaultBubblePaddingBottom = typedArray.GetDimensionPixelSize(Resource.Styleable.MessagesList_outcomingBubblePaddingBottom,
                    style.GetDimension(Resource.Dimension.message_padding_bottom));
            style.outcomingTextColor = typedArray.GetColor(Resource.Styleable.MessagesList_outcomingTextColor,
                    style.GetColor(Resource.Color.white));
            style.outcomingTextSize = typedArray.GetDimensionPixelSize(Resource.Styleable.MessagesList_outcomingTextSize,
                    style.GetDimension(Resource.Dimension.message_text_size));
            style.outcomingTextStyle = typedArray.GetInt(Resource.Styleable.MessagesList_outcomingTextStyle, 0);

            style.outcomingTimeTextColor = typedArray.GetColor(Resource.Styleable.MessagesList_outcomingTimeTextColor,
                    style.GetColor(Resource.Color.white60));
            style.outcomingTimeTextSize = typedArray.GetDimensionPixelSize(Resource.Styleable.MessagesList_outcomingTimeTextSize,
                    style.GetDimension(Resource.Dimension.message_time_text_size));
            style.outcomingTimeTextStyle = typedArray.GetInt(Resource.Styleable.MessagesList_outcomingTimeTextStyle, 0);

            style.outcomingImageTimeTextColor = typedArray.GetColor(Resource.Styleable.MessagesList_outcomingImageTimeTextColor,
                    style.GetColor(Resource.Color.warm_grey_four));
            style.outcomingImageTimeTextSize = typedArray.GetDimensionPixelSize(Resource.Styleable.MessagesList_outcomingImageTimeTextSize,
                    style.GetDimension(Resource.Dimension.message_time_text_size));
            style.outcomingImageTimeTextStyle = typedArray.GetInt(Resource.Styleable.MessagesList_outcomingImageTimeTextStyle, 0);

            style.dateHeaderPadding = typedArray.GetDimensionPixelSize(Resource.Styleable.MessagesList_dateHeaderPadding,
                    style.GetDimension(Resource.Dimension.message_date_header_padding));
            style.dateHeaderFormat = typedArray.GetString(Resource.Styleable.MessagesList_dateHeaderFormat);
            style.dateHeaderTextColor = typedArray.GetColor(Resource.Styleable.MessagesList_dateHeaderTextColor,
                    style.GetColor(Resource.Color.warm_grey_two));
            style.dateHeaderTextSize = typedArray.GetDimensionPixelSize(Resource.Styleable.MessagesList_dateHeaderTextSize,
                    style.GetDimension(Resource.Dimension.message_date_header_text_size));
            style.dateHeaderTextStyle = typedArray.GetInt(Resource.Styleable.MessagesList_dateHeaderTextStyle, 0);

            typedArray.Recycle();

            return style;
        }

        private MessagesListStyle(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        private Drawable getMessageSelector(int normalColor, int selectedColor,
                                            int pressedColor, int shape)
        {

            Drawable drawable = DrawableCompat.Wrap(GetVectorDrawable(shape)).Mutate();
            DrawableCompat.SetTintList(
                    drawable,
                    new ColorStateList(
                            new int[][]{
                                new int[]{Android.Resource.Attribute.StateSelected},
                                new int[]{Android.Resource.Attribute.StatePressed},
                                new int[]{-Android.Resource.Attribute.StatePressed, -Android.Resource.Attribute.StateSelected}
                            },
                            new int[] { selectedColor, pressedColor, normalColor }
                    ));
            return drawable;
        }

        public int getTextAutoLinkMask()
        {
            return textAutoLinkMask;
        }

        public int getIncomingTextLinkColor()
        {
            return incomingTextLinkColor;
        }

        public int getOutcomingTextLinkColor()
        {
            return outcomingTextLinkColor;
        }

        public int getIncomingAvatarWidth()
        {
            return incomingAvatarWidth;
        }

        public int getIncomingAvatarHeight()
        {
            return incomingAvatarHeight;
        }

        public int getIncomingDefaultBubblePaddingLeft()
        {
            return incomingDefaultBubblePaddingLeft;
        }

        public int getIncomingDefaultBubblePaddingRight()
        {
            return incomingDefaultBubblePaddingRight;
        }

        public int getIncomingDefaultBubblePaddingTop()
        {
            return incomingDefaultBubblePaddingTop;
        }

        public int getIncomingDefaultBubblePaddingBottom()
        {
            return incomingDefaultBubblePaddingBottom;
        }

        public int getIncomingTextColor()
        {
            return incomingTextColor;
        }

        public int getIncomingTextSize()
        {
            return incomingTextSize;
        }

        public int getIncomingTextStyle()
        {
            return incomingTextStyle;
        }

        public Drawable getOutcomingBubbleDrawable()
        {
            if (outcomingBubbleDrawable == -1)
            {
                return getMessageSelector(outcomingDefaultBubbleColor, outcomingDefaultBubbleSelectedColor,
                        outcomingDefaultBubblePressedColor, Resource.Drawable.shape_outcoming_message);
            }
            else
            {
                return GetDrawable(outcomingBubbleDrawable);
            }
        }

        public Drawable getOutcomingImageOverlayDrawable()
        {
            if (outcomingImageOverlayDrawable == -1)
            {
                return getMessageSelector(Color.Transparent, outcomingDefaultImageOverlaySelectedColor,
                        outcomingDefaultImageOverlayPressedColor, Resource.Drawable.shape_outcoming_message);
            }
            else
            {
                return GetDrawable(outcomingImageOverlayDrawable);
            }
        }

        public int getOutcomingDefaultBubblePaddingLeft()
        {
            return outcomingDefaultBubblePaddingLeft;
        }

        public int getOutcomingDefaultBubblePaddingRight()
        {
            return outcomingDefaultBubblePaddingRight;
        }

        public int getOutcomingDefaultBubblePaddingTop()
        {
            return outcomingDefaultBubblePaddingTop;
        }

        public int getOutcomingDefaultBubblePaddingBottom()
        {
            return outcomingDefaultBubblePaddingBottom;
        }

        public int getOutcomingTextColor()
        {
            return outcomingTextColor;
        }

        public int getOutcomingTextSize()
        {
            return outcomingTextSize;
        }

        public int getOutcomingTextStyle()
        {
            return outcomingTextStyle;
        }

        public int getOutcomingTimeTextColor()
        {
            return outcomingTimeTextColor;
        }

        public int getOutcomingTimeTextSize()
        {
            return outcomingTimeTextSize;
        }

        public int getOutcomingTimeTextStyle()
        {
            return outcomingTimeTextStyle;
        }

        public int getOutcomingImageTimeTextColor()
        {
            return outcomingImageTimeTextColor;
        }

        public int getOutcomingImageTimeTextSize()
        {
            return outcomingImageTimeTextSize;
        }

        public int getOutcomingImageTimeTextStyle()
        {
            return outcomingImageTimeTextStyle;
        }

        public int getDateHeaderTextColor()
        {
            return dateHeaderTextColor;
        }

        public int getDateHeaderTextSize()
        {
            return dateHeaderTextSize;
        }

        public int getDateHeaderTextStyle()
        {
            return dateHeaderTextStyle;
        }

        public int getDateHeaderPadding()
        {
            return dateHeaderPadding;
        }

        public String getDateHeaderFormat()
        {
            return dateHeaderFormat;
        }

        public int getIncomingTimeTextSize()
        {
            return incomingTimeTextSize;
        }

        public int getIncomingTimeTextStyle()
        {
            return incomingTimeTextStyle;
        }

        public int getIncomingTimeTextColor()
        {
            return incomingTimeTextColor;
        }

        public int getIncomingImageTimeTextColor()
        {
            return incomingImageTimeTextColor;
        }

        public int getIncomingImageTimeTextSize()
        {
            return incomingImageTimeTextSize;
        }

        public int getIncomingImageTimeTextStyle()
        {
            return incomingImageTimeTextStyle;
        }

        public Drawable getIncomingBubbleDrawable()
        {
            if (incomingBubbleDrawable == -1)
            {
                return getMessageSelector(incomingDefaultBubbleColor, incomingDefaultBubbleSelectedColor,
                        incomingDefaultBubblePressedColor, Resource.Drawable.shape_incoming_message);
            }
            else
            {
                return GetDrawable(incomingBubbleDrawable);
            }
        }

        public Drawable getIncomingImageOverlayDrawable()
        {
            if (incomingImageOverlayDrawable == -1)
            {
                return getMessageSelector(Color.Transparent, incomingDefaultImageOverlaySelectedColor,
                        incomingDefaultImageOverlayPressedColor, Resource.Drawable.shape_incoming_message);
            }
            else
            {
                return GetDrawable(incomingImageOverlayDrawable);
            }
        }
    }
}