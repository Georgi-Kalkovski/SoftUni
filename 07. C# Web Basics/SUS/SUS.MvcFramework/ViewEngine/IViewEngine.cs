using System;
using System.Collections.Generic;
using System.Text;

namespace SUS.MvcFramework.ViewEngine
{
    public interface IViewEngine
    {
        string GetHtml(string templateCode, object viewModel);
    }
}
