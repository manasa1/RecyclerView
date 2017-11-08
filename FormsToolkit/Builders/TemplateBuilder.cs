using Xamarin.Forms;

namespace FormsToolkit.Builders
{
    public static class TemplateBuilder
    {

        public static DataTemplate GenerateDefaultTemplate()
        {
            return new DataTemplate(() =>
            {
                StackLayout layout = new StackLayout();
                layout.Children.Add(new Button()
                {
                    Text = "No Data Template Selected",
                    BackgroundColor = Color.BlueViolet,
                    WidthRequest = 200
                });

                return layout;
            });
        }

    }
}
