#pragma checksum "C:\Users\MOMENTUM3\source\repos\FactureXpressProject\FactureXpressProject\Views\Archives\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "483fe085a500d09793d4fe4e7bbbc38c896fa3e8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Archives_Delete), @"mvc.1.0.view", @"/Views/Archives/Delete.cshtml")]
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
#line 2 "C:\Users\MOMENTUM3\source\repos\FactureXpressProject\FactureXpressProject\Views\Archives\Delete.cshtml"
using FactureXpressProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"483fe085a500d09793d4fe4e7bbbc38c896fa3e8", @"/Views/Archives/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4c376dd6d00c3df0c77d559e38f28d11024b639f", @"/Views/_ViewImports.cshtml")]
    public class Views_Archives_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FactureXpressProject.Models.Commande>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\MOMENTUM3\source\repos\FactureXpressProject\FactureXpressProject\Views\Archives\Delete.cshtml"
  
    ViewBag.Title = "Delete";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Restore</h2>\r\n\r\n<h3>Are you sure you want to restore this?</h3>\r\n<div>\r\n    <h4>Commande</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
#nullable restore
#line 16 "C:\Users\MOMENTUM3\source\repos\FactureXpressProject\FactureXpressProject\Views\Archives\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Client.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
#nullable restore
#line 20 "C:\Users\MOMENTUM3\source\repos\FactureXpressProject\FactureXpressProject\Views\Archives\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Client.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            Total\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
#nullable restore
#line 28 "C:\Users\MOMENTUM3\source\repos\FactureXpressProject\FactureXpressProject\Views\Archives\Delete.cshtml"
       Write(ViewBag.totalCom);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </dd>

    </dl>

    <table id=""tblProduits"" class=""table table-striped table-bordered"" cellpadding=""0"" cellspacing=""0"">
        <thead>
            <tr>
                <th style=""width:150px"">Description</th>
                <th style=""width:150px"">Quantité</th>
                <th style=""width:150px"">Prix</th>
                <th style=""width:150px"">Total</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 43 "C:\Users\MOMENTUM3\source\repos\FactureXpressProject\FactureXpressProject\Views\Archives\Delete.cshtml"
             foreach (Produit p in @ViewBag.Produits)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 46 "C:\Users\MOMENTUM3\source\repos\FactureXpressProject\FactureXpressProject\Views\Archives\Delete.cshtml"
                   Write(p.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 47 "C:\Users\MOMENTUM3\source\repos\FactureXpressProject\FactureXpressProject\Views\Archives\Delete.cshtml"
                   Write(p.Qantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 48 "C:\Users\MOMENTUM3\source\repos\FactureXpressProject\FactureXpressProject\Views\Archives\Delete.cshtml"
                   Write(p.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 49 "C:\Users\MOMENTUM3\source\repos\FactureXpressProject\FactureXpressProject\Views\Archives\Delete.cshtml"
                    Write(p.Price *p.Qantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 51 "C:\Users\MOMENTUM3\source\repos\FactureXpressProject\FactureXpressProject\Views\Archives\Delete.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n\r\n");
#nullable restore
#line 55 "C:\Users\MOMENTUM3\source\repos\FactureXpressProject\FactureXpressProject\Views\Archives\Delete.cshtml"
     using (Html.BeginForm())
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "C:\Users\MOMENTUM3\source\repos\FactureXpressProject\FactureXpressProject\Views\Archives\Delete.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"form-actions no-color\">\r\n            <input type=\"submit\" value=\"Restore\" class=\"btn btn-default\" /> |\r\n            ");
#nullable restore
#line 61 "C:\Users\MOMENTUM3\source\repos\FactureXpressProject\FactureXpressProject\Views\Archives\Delete.cshtml"
       Write(Html.ActionLink("Back to List", "Index"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 63 "C:\Users\MOMENTUM3\source\repos\FactureXpressProject\FactureXpressProject\Views\Archives\Delete.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FactureXpressProject.Models.Commande> Html { get; private set; }
    }
}
#pragma warning restore 1591
