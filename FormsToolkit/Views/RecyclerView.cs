using FormsToolkit.Builders;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FormsToolkit.Views
{
    public class RecyclerView : View
    {

        public DataTemplate ItemTemplate;

        public IEnumerable ItemSource;
        
        public RecyclerView()
        {
            ItemTemplate = TemplateBuilder.GenerateDefaultTemplate();
        }

    }
}
