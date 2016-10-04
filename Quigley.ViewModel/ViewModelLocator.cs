using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quigley.ViewModel
{
    public class ViewModelLocator
    {
        private static MainWindowViewModel mainWindowVM;

        public static MainWindowViewModel MainWindowViewModelStatic
        {
            get
            {
                if (mainWindowVM == null)
                {
                    mainWindowVM = new MainWindowViewModel();
                }
                return mainWindowVM;
            }
        }
    }
}
