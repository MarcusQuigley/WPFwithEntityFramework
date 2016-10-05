using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quigley.ViewModel
{
    public class ToolViewModel
    {
        public string DisplayName { get; set; }
    }

    public class AToolViewModel : ToolViewModel
    {
        public AToolViewModel()
        {
            DisplayName = "A";
        }
    }

    public class BToolViewModel : ToolViewModel
    {
        public BToolViewModel()
        {
            DisplayName = "B";
        }
    }
}
