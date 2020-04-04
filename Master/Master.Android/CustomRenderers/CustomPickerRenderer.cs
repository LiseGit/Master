using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using Master.CustomControls;
using Master.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomPickerControl), typeof(CustomPickerRenderer))]
namespace Master.Droid.CustomRenderers
{
    class CustomPickerRenderer : PickerRenderer
    {
        private CustomPickerControl _currentPicker;
        public CustomPickerRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (Element is CustomPickerControl picker)
            {
                var draw = new GradientDrawable();
                draw.SetCornerRadius(3f);
                draw.SetStroke(1, picker.PickerBorderColor.ToAndroid());
                Control.SetBackground(draw);
                //Control.SetPadding(50, Control.PaddingTop, Control.PaddingRight, Control.PaddingBottom);
                Control.InputType = InputTypes.TextFlagNoSuggestions;// Disable "text spell checking"

                //Control.SetPadding(picker.InnerLeftPadding,
                //    picker.InnerTopPadding,
                //    picker.InnerRightPadding,
                //    picker.InnerBottomPadding); // Padding inside picker. Native padding isn't consistent with app style.

                Control.Gravity = GravityFlags.CenterVertical;
                if (Build.VERSION.SdkInt > BuildVersionCodes.LollipopMr1)
                    Control.SetForegroundGravity(GravityFlags.CenterVertical);
                
                //SetFontSettings(picker);
                //SetColorSettings(picker);
                //picker.OnColorSettingsChanged = SetColorSettings;
                //Control.ImeOptions = picker.ReturnKeyType.GetValueFromDescription();
                //if (Control.ImeOptions == ImeAction.Next)
                //{
                //    picker.FocusOnNextElement = FocusOnNextElement;
                //}

                _currentPicker = picker;
            }
        }
        private void SetColorSettings(CustomPickerControl picker)
        {
            #region SetColorToEditor

            if (Control != null)
            {
                Control.SetTextColor(picker.TextColor.ToAndroid());
                Control.SetHintTextColor(picker.BackgroundColor.ToAndroid());

                //SetBorderColorSettings(picker);
            }

            #endregion
        }

    }
}