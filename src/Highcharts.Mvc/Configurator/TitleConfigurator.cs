using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Highcharts.Mvc.Json;

namespace Highcharts.Mvc
{
    public class TitleConfigurator : JsonConfigurator
    {
        public TitleConfigurator()
            : base("title")
        {

        }

        public TitleConfigurator Align(TitleAlignment alignment)
        {
            this.Set(new JsonAttribute("align", alignment));
            return this;
        }

        public TitleConfigurator Margin(int margin)
        {
            this.Set(new JsonAttribute("margin", margin));
            return this;
        }

        public TitleConfigurator Offset(int offset)
        {
            this.Set(new JsonAttribute("offset", offset));
            return this;
        }

        public TitleConfigurator Rotation(int rotation)
        {
            this.Set(new JsonAttribute("rotation", rotation));
            return this;
        }

        public TitleConfigurator Text(string text)
        {
            this.Set(new JsonAttribute("text", text));
            return this;
        }
    }
}
