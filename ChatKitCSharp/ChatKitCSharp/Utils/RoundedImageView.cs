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
using Android.Graphics.Drawables;
using Android.Util;
using Android.Graphics;
using Android.Net;
using Android.Support.V4.Content;
using Android.Content.Res;

namespace ChatKitCSharp.Utils
{
    public class RoundedImageView : ImageView
    {
        private int mResource = 0;
        private Drawable mDrawable;

        private float[] mRadii = new float[] { 0, 0, 0, 0, 0, 0, 0, 0 };

        public RoundedImageView(Context context) : base(context) { }
        public RoundedImageView(Context context, IAttributeSet attrs) : base(context, attrs) { }
        public RoundedImageView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle) { }

        protected override void DrawableStateChanged()
        {
            base.DrawableStateChanged();
            Invalidate();
        }

        public override void SetImageDrawable(Drawable drawable)
        {
            mResource = 0;
            mDrawable = RoundedCornerDrawable.FromDrawable(drawable, Resources);

            base.SetImageDrawable(drawable);
            UpdateDrawable();
        }

        public override void SetImageBitmap(Bitmap bm)
        {
            mResource = 0;
            mDrawable = RoundedCornerDrawable.FromBitmap(bm, Resources);
            base.SetImageBitmap(bm);
            UpdateDrawable();
        }

        public override void SetImageResource(int resId)
        {
            if (mResource != resId)
            {
                mResource = resId;
                mDrawable = ResolveResource();
                base.SetImageDrawable(mDrawable);
                UpdateDrawable();
            }
        }

        public override void SetImageURI(Android.Net.Uri uri)
        {
            base.SetImageURI(uri);
            SetImageDrawable(Drawable);
        }

        public void SetCorners(int leftTop, int rightTop, int rightBottom, int leftBottom)
        {
            SetCorners(leftTop == 0 ? 0 : Resources.GetDimension(leftTop),
                rightTop == 0 ? 0 : Resources.GetDimension(rightTop),
                rightBottom == 0 ? 0 : Resources.GetDimension(rightBottom),
                leftBottom == 0 ? 0 : Resources.GetDimension(leftBottom));
        }

        public void SetCorners(float leftTop, float rightTop, float rightBottom, float leftBottom)
        {
            mRadii = new float[]
            {
                leftTop, leftTop,
                rightTop, rightTop,
                rightBottom, rightBottom,
                leftBottom, leftBottom
            };
            UpdateDrawable();
        }

        private Drawable ResolveResource()
        {
            Drawable d = null;

            if (mResource != 0)
            {
                try
                {
                    d = ContextCompat.GetDrawable(Context, mResource);
                }
                catch (Exception e)
                {
                    mResource = 0;
                }
            }
            return RoundedCornerDrawable.FromDrawable(d, Resources);
        }

        private void UpdateDrawable()
        {
            if (mDrawable == null) return;
            ((RoundedCornerDrawable)mDrawable).SetCornerRadii(mRadii);
        }

        internal class RoundedCornerDrawable : Drawable
        {
            private RectF mBounds = new RectF();
            private RectF mBitmapRect = new RectF();
            private int mBitmapWidth;
            private int mBitmapHeight;
            private Paint mBitmapPaint;
            private BitmapShader mBitmapShader;
            private float[] mRadii = new float[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            private Path mPath = new Path();
            private Bitmap mBitmap;
            private bool mBoundsConfigured = false;

            RoundedCornerDrawable(Bitmap bitmap, Resources r)
            {
                mBitmap = bitmap;
                mBitmapShader = new BitmapShader(bitmap, Shader.TileMode.Clamp, Shader.TileMode.Clamp);
                mBitmapWidth = bitmap.GetScaledWidth(r.DisplayMetrics);
                mBitmapHeight = bitmap.GetScaledHeight(r.DisplayMetrics);
                mBitmapRect.Set(0, 0, mBitmapWidth, mBitmapHeight);
                mBitmapPaint = new Paint(PaintFlags.AntiAlias);
                mBitmapPaint.SetStyle(Paint.Style.Fill);
                mBitmapPaint.SetShader(mBitmapShader);
            }

            public static RoundedCornerDrawable FromBitmap(Bitmap bitmap, Resources r)
            {
                if (bitmap != null) return new RoundedCornerDrawable(bitmap, r);
                else return null;
            }

            public static Drawable FromDrawable(Drawable drawable, Resources r)
            {
                if (drawable != null)
                {
                    if (drawable.GetType() == typeof(RoundedCornerDrawable))
                    {
                        return drawable;
                    }
                    else if (drawable.GetType() == typeof(LayerDrawable))
                    {
                        LayerDrawable ld = drawable as LayerDrawable;
                        int num = ld.NumberOfLayers;
                        for (int i = 0; i < num; i++)
                        {
                            Drawable d = ld.GetDrawable(i);
                            ld.SetDrawableByLayerId(ld.GetId(i), FromDrawable(d, r));
                        }
                        return ld;
                    }

                    Bitmap bm = DrawableToBitmap(drawable);
                    if (bm != null) return new RoundedCornerDrawable(bm, r);
                }
                return drawable;
            }

            public static Bitmap DrawableToBitmap(Drawable drawable)
            {
                if (drawable == null) return null;

                if (drawable.GetType() == typeof(BitmapDrawable))
                {
                    return ((BitmapDrawable)drawable).Bitmap;
                }

                Bitmap bitmap;
                int width = Math.Max(drawable.IntrinsicWidth, 2);
                int height = Math.Max(drawable.IntrinsicHeight, 2);
                try
                {
                    bitmap = Bitmap.CreateBitmap(width, height, Bitmap.Config.Argb8888);
                    Canvas canvas = new Canvas(bitmap);
                    drawable.SetBounds(0, 0, canvas.Width, canvas.Height);
                    drawable.Draw(canvas);
                }
                catch (Exception e)
                {
                    bitmap = null;
                }
                return bitmap;
            }

            private void ConfigureBounds(Canvas canvas)
            {
                var canvasMatrix = canvas.Matrix;
                ApplyScaleToRadii(canvasMatrix);
                mBounds.Set(mBitmapRect);
            }

            private void ApplyScaleToRadii(Matrix m)
            {
                float[] values = new float[9];
                m.GetValues(values);
                for (int i = 0; i < mRadii.Length; i++)
                {
                    mRadii[i] = mRadii[i] / values[0];
                }
            }

            public override void Draw(Canvas canvas)
            {
                canvas.Save();
                if (!mBoundsConfigured)
                {
                    ConfigureBounds(canvas);
                    mBoundsConfigured = true;
                }
                mPath.AddRoundRect(mBounds, mRadii, Path.Direction.Cw);
                canvas.DrawPath(mPath, mBitmapPaint);
                canvas.Restore();
            }

            public void SetCornerRadii(float[] radii)
            {
                if (radii == null) return;
                if (radii.Length != 8)
                {
                    throw new Exception("radii[] needs 8 values");
                }
                Java.Lang.JavaSystem.Arraycopy(radii, 0, mRadii, 0, radii.Length);
            }

            public override int Opacity
            {
                get
                {
                    return (mBitmap == null || mBitmap.HasAlpha || mBitmapPaint.Alpha < 255) ? -3 : -1;
                }
            }

            public override void SetAlpha(int alpha)
            {
                mBitmapPaint.Alpha = alpha;
                InvalidateSelf();
            }

            public override void SetColorFilter(ColorFilter colorFilter)
            {
                mBitmapPaint.SetColorFilter(colorFilter);
                InvalidateSelf();
            }

            public override void SetDither(bool dither)
            {
                mBitmapPaint.Dither = dither;
                InvalidateSelf();
            }

            public override void SetFilterBitmap(bool filter)
            {
                mBitmapPaint.FilterBitmap = filter;
                InvalidateSelf();
            }

            public override int IntrinsicWidth => mBitmapWidth;

            public override int IntrinsicHeight => mBitmapHeight;


        }
    }
}