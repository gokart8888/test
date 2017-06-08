using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PrismUnityApp2.Controls
{
    public class MyEntry : Entry
    {
        public static readonly BindableProperty PlaceHolderColorProperty = BindableProperty.Create("PlaceholderColorText", typeof(string), typeof(MyEntry), "#cccccc");

        public string PlaceholderColorText
        {
            get { return (string)GetValue(PlaceHolderColorProperty); }
            set { SetValue(PlaceHolderColorProperty, value); }
        }
    }
}
