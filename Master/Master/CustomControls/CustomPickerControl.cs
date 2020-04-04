using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Master.CustomControls
{
    public class CustomPickerControl : Picker
    {
        public static readonly BindableProperty PickerBorderColorProperty =
            BindableProperty.Create(nameof(PickerBorderColor), typeof(Color),
                typeof(CustomPickerControl), default(Color), BindingMode.TwoWay);
        public Color PickerBorderColor
        {
            get => (Color)GetValue(PickerBorderColorProperty);
            set => SetValue(PickerBorderColorProperty, value);
        }
    }
}
