#pragma checksum "C:\Project\Web\SCADA_A\SCADA_A.Web\Views\KitComponentes\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "89a569451d29c84c8c910d79ee91751e65722904"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_KitComponentes_Delete), @"mvc.1.0.view", @"/Views/KitComponentes/Delete.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89a569451d29c84c8c910d79ee91751e65722904", @"/Views/KitComponentes/Delete.cshtml")]
    #nullable restore
    public class Views_KitComponentes_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SCADA_A.Entidades.OnePieceFlow.KitComponentes>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Project\Web\SCADA_A\SCADA_A.Web\Views\KitComponentes\Delete.cshtml"
  
    ViewData["Title"] = "Delete";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Delete</h1>\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4>KitComponentes</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 16 "C:\Project\Web\SCADA_A\SCADA_A.Web\Views\KitComponentes\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.CUSTOMPN));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 19 "C:\Project\Web\SCADA_A\SCADA_A.Web\Views\KitComponentes\Delete.cshtml"
       Write(Html.DisplayFor(model => model.CUSTOMPN));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 22 "C:\Project\Web\SCADA_A\SCADA_A.Web\Views\KitComponentes\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.TYPE));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 25 "C:\Project\Web\SCADA_A\SCADA_A.Web\Views\KitComponentes\Delete.cshtml"
       Write(Html.DisplayFor(model => model.TYPE));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 28 "C:\Project\Web\SCADA_A\SCADA_A.Web\Views\KitComponentes\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.POSITION));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 31 "C:\Project\Web\SCADA_A\SCADA_A.Web\Views\KitComponentes\Delete.cshtml"
       Write(Html.DisplayFor(model => model.POSITION));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 34 "C:\Project\Web\SCADA_A\SCADA_A.Web\Views\KitComponentes\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.COLOR));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 37 "C:\Project\Web\SCADA_A\SCADA_A.Web\Views\KitComponentes\Delete.cshtml"
       Write(Html.DisplayFor(model => model.COLOR));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 40 "C:\Project\Web\SCADA_A\SCADA_A.Web\Views\KitComponentes\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.kit));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 43 "C:\Project\Web\SCADA_A\SCADA_A.Web\Views\KitComponentes\Delete.cshtml"
       Write(Html.DisplayFor(model => model.kit.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </dd class>
    </dl>
    
    <form asp-action=""Delete"">
        <input type=""hidden"" asp-for=""idKitComponentes"" />
        <input type=""submit"" value=""Delete"" class=""btn btn-danger"" /> |
        <a asp-action=""Index"">Back to List</a>
    </form>
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SCADA_A.Entidades.OnePieceFlow.KitComponentes> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591