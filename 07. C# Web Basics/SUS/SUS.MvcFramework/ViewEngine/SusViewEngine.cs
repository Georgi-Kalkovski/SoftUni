using System;
using System.Collections.Generic;
using System.Text;

namespace SUS.MvcFramework.ViewEngine
{
    public class SusViewEngine : IViewEngine
    {
        public string GetHtml(string templateCode, object viewModel)
        {
            string csharpCode = GenerateCSharpFromTemplate(templateCode);
            IView executableObject = GenerateExecutableCode(csharpCode);
            string html = executableObject.ExecuteTemplate(viewModel);
            return html;
        }
        private string GenerateCSharpFromTemplate(string templateCode)
        {
            string methodBody = GetMethodBody(templateCode);
            string csharpCode = @"
using System;
using System.Text;
using Sytem.Linq;
using System.Collection.Genereic;
using SUS.MvcFramework.ViewEngine;

namespace ViewNamespace
{
    public class ViewClass : IView
    {
        public string ExecuteTemplate(object viewModel)
        {
            var html = new StringBuilder();

            " + methodBody + @"

            return html.ToString();
        }

        private string GetMethodBody(string templateCode)
        {
            throw new NotImplementedException();
        }
    }
}
";
            return csharpCode;
        }

        private string GetMethodBody(string templateCode)
        {
            return string.Empty;
        }

        private IView GenerateExecutableCode(string csharpCode)
        {
            throw new NotImplementedException();
        }
    }
}
