#pragma checksum "C:\Project\Web\SCADA_A\SCADA_A.Web\Views\OrdenKits\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "772d3c9172eea8ba1d122b063cad4d83bb01abba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_OrdenKits_Index), @"mvc.1.0.view", @"/Views/OrdenKits/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"772d3c9172eea8ba1d122b063cad4d83bb01abba", @"/Views/OrdenKits/Index.cshtml")]
    #nullable restore
    public class Views_OrdenKits_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SCADA_A.Entidades.OnePieceFlow.OrdenKit>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Project\Web\SCADA_A\SCADA_A.Web\Views\OrdenKits\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    <a asp-action=\"Create\">Create New</a>\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "C:\Project\Web\SCADA_A\SCADA_A.Web\Views\OrdenKits\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Estatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 20 "C:\Project\Web\SCADA_A\SCADA_A.Web\Views\OrdenKits\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.orden));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 23 "C:\Project\Web\SCADA_A\SCADA_A.Web\Views\OrdenKits\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.kit));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 29 "C:\Project\Web\SCADA_A\SCADA_A.Web\Views\OrdenKits\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 32 "C:\Project\Web\SCADA_A\SCADA_A.Web\Views\OrdenKits\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Estatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 35 "C:\Project\Web\SCADA_A\SCADA_A.Web\Views\OrdenKits\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.orden.CodigoColor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 38 "C:\Project\Web\SCADA_A\SCADA_A.Web\Views\OrdenKits\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.kit.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                <a asp-action=\"Edit\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1038, "\"", 1069, 1);
#nullable restore
#line 41 "C:\Project\Web\SCADA_A\SCADA_A.Web\Views\OrdenKits\Index.cshtml"
WriteAttributeValue("", 1053, item.idOrdenKit, 1053, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a> |\r\n                <a asp-action=\"Details\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1122, "\"", 1153, 1);
#nullable restore
#line 42 "C:\Project\Web\SCADA_A\SCADA_A.Web\Views\OrdenKits\Index.cshtml"
WriteAttributeValue("", 1137, item.idOrdenKit, 1137, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Details</a> |\r\n                <a asp-action=\"Delete\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1208, "\"", 1239, 1);
#nullable restore
#line 43 "C:\Project\Web\SCADA_A\SCADA_A.Web\Views\OrdenKits\Index.cshtml"
WriteAttributeValue("", 1223, item.idOrdenKit, 1223, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a>\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 46 "C:\Project\Web\SCADA_A\SCADA_A.Web\Views\OrdenKits\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SCADA_A.Entidades.OnePieceFlow.OrdenKit>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591