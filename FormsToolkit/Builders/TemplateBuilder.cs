using Xamarin.Forms;

namespace FormsToolkit.Builders
{
    public static class TemplateBuilder
    {

        public static DataTemplate GenerateDefaultTemplate()
        {
            return new DataTemplate(() =>
            {
                return new Label
                {
                    Text = "No Data Template Selected",
                    BackgroundColor = Color.BlueViolet,
                    WidthRequest = 200
                };
            });
        }

    }
}
