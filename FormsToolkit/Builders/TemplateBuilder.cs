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
                    BackgroundColor = Color.BlueViolet
                };

                layout.Children.Add(new Button()
                {
                    Text = "No Data Template Selected",
                    TextColor = Color.Blue,
                    BackgroundColor = Color.WhiteSmoke,
                    HeightRequest = 200
                });

                return layout;
            });
        }

    }
}
