#pragma checksum "C:\Users\MOMENTUM3\source\repos\FactureXpressProject\FactureXpressProject\Views\Archives\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6bc85b127de8e5124bfedc6786895311e6513315"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Archives_Index), @"mvc.1.0.view", @"/Views/Archives/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\MOMENTUM3\source\repos\FactureXpressProject\FactureXpressProject\Views\_ViewImports.cshtml"
using FactureXpressProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\MOMENTUM3\source\repos\FactureXpressProject\FactureXpressProject\Views\_ViewImports.cshtml"
using FactureXpressProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bc85b127de8e5124bfedc6786895311e6513315", @"/Views/Archives/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4c376dd6d00c3df0c77d559e38f28d11024b639f", @"/Views/_ViewImports.cshtml")]
    public class Views_Archives_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<FactureXpressProject.Models.Commande>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\MOMENTUM3\source\repos\FactureXpressProject\FactureXpressProject\Views\Archives\Index.cshtml"
  
    ViewBag.Title = "Archives";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Liste des archives</h2>\r\n\r\n<table class=\"table table-striped table-bordered\">\r\n    <tr>\r\n        <th>\r\n            ");
#nullable restore
#line 12 "C:\Users\MOMENTUM3\source\repos\FactureXpressProject\FactureXpressProject\Views\Archives\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 15 "C:\Users\MOMENTUM3\source\repos\FactureXpressProject\FactureXpressProject\Views\Archives\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.Client.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n\r\n        <th>Actions</th>\r\n    </tr>\r\n\r\n");
#nullable restore
#line 21 "C:\Users\MOMENTUM3\source\repos\FactureXpressProject\FactureXpressProject\Views\Archives\Index.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n\r\n            <td>\r\n                ");
#nullable restore
#line 26 "C:\Users\MOMENTUM3\source\repos\FactureXpressProject\FactureXpressProject\Views\Archives\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 29 "C:\Users\MOMENTUM3\source\repos\FactureXpressProject\FactureXpressProject\Views\Archives\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Client.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n\r\n            <td>\r\n                ");
#nullable restore
#line 33 "C:\Users\MOMENTUM3\source\repos\FactureXpressProject\FactureXpressProject\Views\Archives\Index.cshtml"
           Write(Html.ActionLink("Details", "Details", new { id = item.CommandeId }));

#line default
#line hidden
#nullable disable
            WriteLiteral("|\r\n                ");
#nullable restore
#line 34 "C:\Users\MOMENTUM3\source\repos\FactureXpressProject\FactureXpressProject\Views\Archives\Index.cshtml"
           Write(Html.ActionLink("Restore", "Delete", new { id = item.CommandeId }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 37 "C:\Users\MOMENTUM3\source\repos\FactureXpressProject\FactureXpressProject\Views\Archives\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</table>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<FactureXpressProject.Models.Commande>> Html { get; private set; }
    }
}
#pragma warning restore 1591
