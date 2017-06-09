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
using Xamarin.Forms;
using PrismUnityApp2.Controls;
using Xamarin.Forms.Platform.Android;
using PrismUnityApp2.Droid.Renderers;
using Android.Graphics;
using Android.Graphics.Drawables.Shapes;
using Android.Graphics.Drawables;

[assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntryRenderer))]
namespace PrismUnityApp2.Droid.Renderers
{
    public class MyEntryRenderer : EntryRenderer
    {
        MyEntry myEntry;
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                myEntry = e.NewElement as MyEntry;
            }

            if (Control != null)
            {
                EditText textField = (EditText)Control;
                //textField.Typeface = Android.Graphics.Typeface.Monospace;
                var color = Android.Graphics.Color.ParseColor(myEntry == null ? "#c8c8c8" : myEntry.PlaceholderColorText);
                var colorWhite = Android.Graphics.Color.ParseColor("#ffffff");
                var colorBlack = Android.Graphics.Color.ParseColor("#000000");
                textField.SetHintTextColor(color);

                //var shape = new ShapeDrawable(new RectShape());
                //shape.Paint.Color = colorWhite;
                //shape.Paint.SetStyle(Paint.Style.FillAndStroke);

                //textField.Background = shape;

                GradientDrawable gradientDrawable = new GradientDrawable();
                gradientDrawable.SetShape(ShapeType.Rectangle);
                gradientDrawable.SetColor(colorWhite);
                gradientDrawable.SetStroke(4, colorBlack);
                gradientDrawable.SetCornerRadius(10.0f);
                textField.Background = gradientDrawable;
            }
        }
    }
}