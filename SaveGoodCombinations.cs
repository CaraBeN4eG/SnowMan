using System;
using System.Drawing; // потрібно для Color

namespace SnowMan
{
    public partial class SaveGoodCombination
    {
        public override string ToString()
        {
            Color fill = Color.FromArgb(this.FillColor);
            Color border = Color.FromArgb(this.BorderColor);

            string fillHex = $"#{fill.R:X2}{fill.G:X2}{fill.B:X2}";
            string borderHex = $"#{border.R:X2}{border.G:X2}{border.B:X2}";

            return $"Id={this.Id}, Fill={fillHex}, Border={borderHex}";
        }
    }
}