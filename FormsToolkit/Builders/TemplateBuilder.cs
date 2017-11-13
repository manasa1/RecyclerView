using Xamarin.Forms;

namespace FormsToolkit.Builders
{
    public static class TemplateBuilder
    {

        public static DataTemplate GenerateDefaultTemplate()
        {
            return new DataTemplate(() =>
            {
                StackLayout layout = new StackLayout()
                {
                    BackgroundColor = Color.Blue,
                    WidthRequest = 200,
                    HeightRequest = 200,
                };

                layout.Children.Add(new Button()
                {
                    Text = "No Data Template Selected",
                    TextColor = Color.Blue,
                    BackgroundColor = Color.WhiteSmoke,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.Center,
                    HeightRequest = 50
                });

                return layout;
            });
        }

    }
}
