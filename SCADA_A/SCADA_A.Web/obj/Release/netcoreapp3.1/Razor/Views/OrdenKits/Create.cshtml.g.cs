#pragma checksum "C:\Project\Web\SCADA_A\SCADA_A.Web\Views\OrdenKits\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2e95fff08a74d781d36b92448bed94b9e6c28b64"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_OrdenKits_Create), @"mvc.1.0.view", @"/Views/OrdenKits/Create.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2e95fff08a74d781d36b92448bed94b9e6c28b64", @"/Views/OrdenKits/Create.cshtml")]
    #nullable restore
    public class Views_OrdenKits_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SCADA_A.Entidades.OnePieceFlow.OrdenKit>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Project\Web\SCADA_A\SCADA_A.Web\Views\OrdenKits\Create.cshtml"
  
    ViewData["Title"] = "Create";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Create</h1>

<h4>OrdenKit</h4>
<hr />
<div class=""row"">
    <div class=""col-md-4"">
        <form asp-action=""Create"">
            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
            <div class=""form-group"">
                <label asp-for=""idOrden"" class=""control-label""></label>
                <select asp-for=""idOrden"" class =""form-control"" asp-items=""ViewBag.idOrden""></select>
            </div>
            <div class=""form-group"">
                <label asp-for=""idKit"" class=""control-label""></label>
                <select asp-for=""idKit"" class =""form-control"" asp-items=""ViewBag.idKit""></select>
            </div>
            <div class=""form-group"">
                <label asp-for=""Estatus"" class=""control-label""></label>
                <input asp-for=""Estatus"" class=""form-control"" />
                <span asp-validation-for=""Estatus"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <input type=""submit""");
            WriteLiteral(" value=\"Create\" class=\"btn btn-primary\" />\r\n            </div>\r\n        </form>\r\n    </div>\r\n</div>\r\n\r\n<div>\r\n    <a asp-action=\"Index\">Back to List</a>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SCADA_A.Entidades.OnePieceFlow.OrdenKit> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591