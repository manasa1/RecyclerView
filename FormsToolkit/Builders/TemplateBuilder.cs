using Xamarin.Forms;

namespace FormsToolkit.Builders
{
    public static class TemplateBuilder
    {

        public static DataTemplate GenerateDefaultTemplate()
        {
            return new DataTemplate(() =>
            {
                return new Grid
                {
                    BackgroundColor = Color.Pink,
                    HeightRequest = 100
                };
            });
        }

    }
}
