using System;
using Xamarin.Forms;

namespace Phoneword
{
	public class MainPage : ContentPage
	{
		Entry phoneNumberText;
		Button translateButton;
		Button callButton;

		string translatedNumber;

        public MainPage()
		{
			this.Padding = new Thickness(20, 50, 20, 50);

			StackLayout panel = new StackLayout { Spacing = 15 };
			panel.Children.Add(new Label { Text = "Enter a Phoneword:", FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)) });
			panel.Children.Add(phoneNumberText = new Entry { Text = "1-855-XAMARIN", HorizontalTextAlignment = TextAlignment.Center });
			panel.Children.Add(translateButton = new Button { Text = "Translate" });
			panel.Children.Add(callButton = new Button { Text = "Call", IsEnabled = false });

			translateButton.Clicked += OnTranslate;
			this.Content = panel;
		}

		private void OnTranslate(object sender, EventArgs e)
		{
			string enteredNumber = phoneNumberText.Text;
			translatedNumber = Core.PhonewordTranslator.ToNumber(enteredNumber);

            if (!string.IsNullOrEmpty(translatedNumber))
			{
				callButton.IsEnabled = true;
				callButton.Text = "Call " + translatedNumber;
			}
			else
			{
				callButton.IsEnabled = false;
				callButton.Text = "Call";
			}
		}
	}

	//public class MainPage : ContentPage
    //{
    //    public MainPage()
    //    {
    //        Content = new StackLayout
    //        {
    //            VerticalOptions = LayoutOptions.Center,
    //            Children =
    //            {
    //                new Label { Text = "Enter a Phoneword:", HorizontalTextAlignment = TextAlignment.Center },
    //                new Entry { Text = "1-800-XAMARIN", HorizontalTextAlignment = TextAlignment.Center },
    //                new Button { Text = "Translate" },
    //                new Button { Text = "Call" , IsEnabled = false}
    //            }
    //        };
    //    }
    //}
}
