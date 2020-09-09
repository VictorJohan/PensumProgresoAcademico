using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace PensumProgresoAcademico.ViewModel
{
    public class SubItem
    {
        public string Name { get; private set; }
        public UserControl Screen { get; private set; }

        public SubItem(string name, UserControl screen = null)
        {
            Name = name;
            Screen = screen;
        }
    }
}
