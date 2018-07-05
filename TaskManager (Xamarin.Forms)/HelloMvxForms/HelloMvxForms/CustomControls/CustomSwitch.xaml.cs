using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloMvxForms.CustomControls
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomSwitch : ContentView
    {
        public CustomSwitch()
        {
            InitializeComponent();
            Text = "Task isn't done";
        }

        public static BindableProperty TextProperty = BindableProperty.Create(
            propertyName: "Text",
            returnType: typeof(string),
            declaringType: typeof(ContentView),
            defaultValue: string.Empty,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: HandleTextPropertyChanged);

        public string Text
        {
            // ----- The display text for the composite control.
            get { return (string)base.GetValue(TextProperty); }
            set
            {
                if (value != this.SwitchText.Text)
                    base.SetValue(TextProperty, value);
            }
        }

        private static void HandleTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            // ----- Someone changed the full control's Text property.
            //       Store that new value in the internal Label’s Text property.
            CustomSwitch targetView;

            targetView = (CustomSwitch)bindable;
            if (targetView != null)
                targetView.SwitchText.Text = (string)newValue;
        }

        public static BindableProperty ValueProperty = BindableProperty.Create(
            propertyName: "Value",
            returnType: typeof(bool),
            declaringType: typeof(ContentView),
            defaultValue: false,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: HandleValuePropertyChanged);

        public bool Value
        {
            // ----- The toggle value of the internal Switch control.
            get { return (bool)base.GetValue(ValueProperty); }
            set
            {
                if (this.Value != value)
                {
                    base.SetValue(ValueProperty, value);

                    // ----- Also notify by standard event handler.
                    this.OnValueToggled(new ToggledEventArgs(value));
                }
            }
        }

        private static void HandleValuePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            // ----- Someone changed the full control's Value property. Store
            //       that new value in the internal Switch’s IsToggled property.
            CustomSwitch targetView;

            targetView = (CustomSwitch)bindable;
            if (targetView != null)
                targetView.SwitchValue.IsToggled = (bool)newValue;
        }

        public event EventHandler<ToggledEventArgs> ValueToggled;
        protected virtual void OnValueToggled(ToggledEventArgs e)
        {
            // ----- Event handler for value changes.
            ValueToggled?.Invoke(this, e);
        }

        private void SwitchValue_Toggled(object sender, ToggledEventArgs e)
        {
            // ----- Communicate the new value back to the property.
            this.SwitchValue.IsToggled = e.Value;
            Value = e.Value;
        }
    }
}