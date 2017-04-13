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
using Android.Content.Res;
using Android.Util;
using Android.Support.V4.Content;
using Android.Graphics.Drawables;

namespace ChatKitCSharp.Commons
{
    public abstract class Style
    {
        protected Context context;
        protected Resources resources;
        protected IAttributeSet attrs;

        protected Style(Context context, IAttributeSet attrs)
        {
            this.context = context;
            this.resources = context.Resources;
            this.attrs = attrs;
        }

        protected int GetSystemAccentColor()
        {
            return GetSystemColor(Resource.Attribute.colorAccent);
        }

        protected int GetSystemPrimaryColor()
        {
            return GetSystemColor(Resource.Attribute.colorPrimary);
        }

        protected int GetSystemPrimaryDarkColor()
        {
            return GetSystemColor(Resource.Attribute.colorPrimaryDark);
        }

        protected int GetSystemPrimaryTextColor()
        {
            return GetSystemColor(Android.Resource.Attribute.TextColorPrimary);
        }

        protected int GetSystemHintColor()
        {
            return GetSystemColor(Android.Resource.Attribute.TextColorHint);
        }

        protected int GetSystemColor(int attr)
        {
            TypedValue typedValue = new TypedValue();
            TypedArray a = context.ObtainStyledAttributes(typedValue.Data, new int[] { attr });
            int color = a.GetColor(0, 0);
            a.Recycle();
            return color;
        }

        protected int GetDimension(int dimen)
        {
            return resources.GetDimensionPixelSize(dimen);
        }

        protected int GetColor(int color)
        {
            return ContextCompat.GetColor(context, color);
        }

        protected Drawable GetDrawable(int drawable)
        {
            return ContextCompat.GetDrawable(context, drawable);
        }

        protected Drawable GetVectorDrawable(int drawable)
        {
            return ContextCompat.GetDrawable(context, drawable);
        }
    }
}