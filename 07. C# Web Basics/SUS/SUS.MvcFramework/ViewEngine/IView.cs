using System;
using System.Collections.Generic;
using System.Text;

namespace SUS.MvcFramework.ViewEngine
{
    public interface IView
    {
        string ExecuteTemplate(object viewModel);
    }
}
