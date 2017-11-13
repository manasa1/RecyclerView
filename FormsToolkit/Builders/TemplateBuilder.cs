using Xamarin.Forms;

namespace FormsToolkit.Builders
{
    public static class TemplateBuilder
    {

        public static DataTemplate GenerateDefaultTemplate()
        {
            return new DataTemplate(() =>
            {
                Grid grid = new Grid
                {
                    BackgroundColor = Color.Blue,
                    HeightRequest = 200,
                    RowDefinitions =
                    {
                        new RowDefinition() { Height = GridLength.Star },
                        new RowDefinition() { Height = 50 },
                        new RowDefinition() { Height = GridLength.Star }
                    }
                };

                Button button = new Button()
                {
                    Text = "No Data Template Selected",
                    TextColor = Color.Blue,
                    BackgroundColor = Color.WhiteSmoke
                };

                Grid.SetRow(button, 1);
                Grid.SetColumn(button, 0);
                grid.Children.Add(button);

                return grid;
            });
        }

    }
}
