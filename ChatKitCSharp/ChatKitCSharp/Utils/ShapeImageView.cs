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
using Android.Util;
using Android.Graphics;

namespace ChatKitCSharp.Utils
{
    public class ShapeImageView : ImageView
    {
        private Path path;

        public ShapeImageView(Context c) : base(c) { }
        public ShapeImageView(Context c, IAttributeSet attrs) : base(c, attrs) { }
        public ShapeImageView(Context c, IAttributeSet attrs, int defStyle) : base(c, attrs, defStyle) { }

        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            base.OnSizeChanged(w, h, oldw, oldh);
            path = new Path();
            float halfWidth = (float)w / 2f;
            float firstParam = (float)w * 0.1f;
            float secondParam = (float)w * 0.8875f;

            path.MoveTo(halfWidth, (float)w);
            path.CubicTo(firstParam, (float)w, 0, secondParam, 0, halfWidth);
            path.CubicTo(0, firstParam, firstParam, 0, halfWidth, 0);
            path.CubicTo(secondParam, 0, (float)w, firstParam, (float)w, halfWidth);
            path.CubicTo((float)w, secondParam, secondParam, (float)w, halfWidth, (float)w);
            path.Close();
        }

        protected override void OnDraw(Canvas canvas)
        {
            if (canvas != null)
            {
                canvas.ClipPath(path);
                base.OnDraw(canvas);
            }
        }
    }
}