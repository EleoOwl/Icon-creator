using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawPixel
{
    public class MenuStripColorTable : ProfessionalColorTable
    {
        public override Color ToolStripDropDownBackground // Рамка выпадающего списка.
        {
            get
            {
                return Color.FromArgb(134, 95, 197);
            }
        }

        public override Color ImageMarginGradientBegin // Рамка выпадающего списка.
        {
            get
            {
                return Color.FromArgb(134, 95, 197);
            }
        }

        public override Color ImageMarginGradientMiddle
        {
            get
            {
                return Color.FromArgb(134, 95, 197);
            }
        }

        public override Color ImageMarginGradientEnd
        {
            get
            {
                return Color.FromArgb(134, 95, 197);
            }
        }

        public override Color MenuBorder // Граница выпадающего списка.
        {
            get
            {
                return Color.FromArgb(73, 51, 107);
            }
        }

        public override Color MenuItemBorder // Рамка выделяемого элемента.
        {
            get
            {
                return Color.FromArgb(73, 51, 107);
            }
        }

        public override Color MenuItemSelected // Цвет выделеного элемента.
        {
            get
            {
                return Color.FromArgb(163, 101, 197);
            }
        }

        public override Color MenuStripGradientBegin
        {
            get
            {
                return Color.FromArgb(134, 95, 197);
            }
        }

        public override Color MenuStripGradientEnd
        {
            get
            {
                return Color.FromArgb(255, 255, 255);
            }
        }

        public override Color MenuItemSelectedGradientBegin // Начало градиента выбраного элемента.
        {
            get
            {
                return Color.FromArgb(163, 101, 197);
            }
        }

        public override Color MenuItemSelectedGradientEnd // Концен градиента выбраного элемента.
        {
            get
            {
                return Color.FromArgb(163, 101, 197);
            }
        }

        public override Color MenuItemPressedGradientBegin // Начало градиента нажатого элемента.
        {
            get
            {
                return Color.FromArgb(134, 95, 197);
            }
        }

        public override Color MenuItemPressedGradientEnd // Конец градиента нажатого элемента.
        {
            get
            {
                return Color.FromArgb(134, 95, 197);
            }
        }

    }
}
