#pragma checksum "G:\Users\podhav\source\repos\Corporate Performance\Corporate Performance\Areas\Admin\Views\Performance\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ae9e541bfd6dcafeb6db7865c1b979210cd45ce7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Performance_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Performance/Index.cshtml")]
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
#line 1 "G:\Users\podhav\source\repos\Corporate Performance\Corporate Performance\Areas\Admin\Views\_ViewImports.cshtml"
using Corporate_Performance;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\Users\podhav\source\repos\Corporate Performance\Corporate Performance\Areas\Admin\Views\_ViewImports.cshtml"
using Corporate_Performance.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae9e541bfd6dcafeb6db7865c1b979210cd45ce7", @"/Areas/Admin/Views/Performance/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"121bd46d30e8f2eed3f0b842f922645b2b8d8102", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Performance_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Performance>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_CreateButtonPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_TableButtonPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "G:\Users\podhav\source\repos\Corporate Performance\Corporate Performance\Areas\Admin\Views\Performance\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n<br />\r\n<div class=\"row\">\r\n    <div class=\"col 6 \">\r\n        <h2 class=\"text-info\">List of Performance KPI\'s</h2>\r\n    </div>\r\n    <div class=\"col-6 text-right\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ae9e541bfd6dcafeb6db7865c1b979210cd45ce74386", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n<br />\r\n<div>\r\n");
#nullable restore
#line 18 "G:\Users\podhav\source\repos\Corporate Performance\Corporate Performance\Areas\Admin\Views\Performance\Index.cshtml"
     if (Model.Count() > 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <table class=\"table table-striped border table-sm\">\r\n           <tr class=\"table-secondary\">\r\n                <th>\r\n                    ");
#nullable restore
#line 23 "G:\Users\podhav\source\repos\Corporate Performance\Corporate Performance\Areas\Admin\Views\Performance\Index.cshtml"
               Write(Html.DisplayNameFor(p => p.FiscalId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 26 "G:\Users\podhav\source\repos\Corporate Performance\Corporate Performance\Areas\Admin\Views\Performance\Index.cshtml"
               Write(Html.DisplayNameFor(p => p.KPA));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 29 "G:\Users\podhav\source\repos\Corporate Performance\Corporate Performance\Areas\Admin\Views\Performance\Index.cshtml"
               Write(Html.DisplayNameFor(p => p.KPI));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>               \r\n                <th>\r\n                    ");
#nullable restore
#line 32 "G:\Users\podhav\source\repos\Corporate Performance\Corporate Performance\Areas\Admin\Views\Performance\Index.cshtml"
               Write(Html.DisplayNameFor(p => p.Qrt1Target));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 35 "G:\Users\podhav\source\repos\Corporate Performance\Corporate Performance\Areas\Admin\Views\Performance\Index.cshtml"
               Write(Html.DisplayNameFor(p => p.Qrt2Target));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 38 "G:\Users\podhav\source\repos\Corporate Performance\Corporate Performance\Areas\Admin\Views\Performance\Index.cshtml"
               Write(Html.DisplayNameFor(p => p.Qrt3Target));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 41 "G:\Users\podhav\source\repos\Corporate Performance\Corporate Performance\Areas\Admin\Views\Performance\Index.cshtml"
               Write(Html.DisplayNameFor(p => p.Qrt4Target));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 44 "G:\Users\podhav\source\repos\Corporate Performance\Corporate Performance\Areas\Admin\Views\Performance\Index.cshtml"
               Write(Html.DisplayNameFor(p => p.AnnualTarget));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>        \r\n                <th></th>\r\n                <th></th>\r\n            </tr>\r\n");
#nullable restore
#line 49 "G:\Users\podhav\source\repos\Corporate Performance\Corporate Performance\Areas\Admin\Views\Performance\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 53 "G:\Users\podhav\source\repos\Corporate Performance\Corporate Performance\Areas\Admin\Views\Performance\Index.cshtml"
                   Write(Html.DisplayFor(P => item.Fiscal.FiscalYear));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 56 "G:\Users\podhav\source\repos\Corporate Performance\Corporate Performance\Areas\Admin\Views\Performance\Index.cshtml"
                   Write(Html.DisplayFor(P => item.KPA.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 59 "G:\Users\podhav\source\repos\Corporate Performance\Corporate Performance\Areas\Admin\Views\Performance\Index.cshtml"
                   Write(Html.DisplayFor(P => item.KPI.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>                    \r\n                    <td>\r\n                        ");
#nullable restore
#line 62 "G:\Users\podhav\source\repos\Corporate Performance\Corporate Performance\Areas\Admin\Views\Performance\Index.cshtml"
                   Write(Html.DisplayFor(P => item.Qrt1Target));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 65 "G:\Users\podhav\source\repos\Corporate Performance\Corporate Performance\Areas\Admin\Views\Performance\Index.cshtml"
                   Write(Html.DisplayFor(P => item.Qrt2Target));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 68 "G:\Users\podhav\source\repos\Corporate Performance\Corporate Performance\Areas\Admin\Views\Performance\Index.cshtml"
                   Write(Html.DisplayFor(P => item.Qrt3Target));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 71 "G:\Users\podhav\source\repos\Corporate Performance\Corporate Performance\Areas\Admin\Views\Performance\Index.cshtml"
                   Write(Html.DisplayFor(P => item.Qrt4Target));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 74 "G:\Users\podhav\source\repos\Corporate Performance\Corporate Performance\Areas\Admin\Views\Performance\Index.cshtml"
                   Write(Html.DisplayFor(P => item.AnnualTarget));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>                   \r\n                    <td>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ae9e541bfd6dcafeb6db7865c1b979210cd45ce712356", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 77 "G:\Users\podhav\source\repos\Corporate Performance\Corporate Performance\Areas\Admin\Views\Performance\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = item.Id;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 80 "G:\Users\podhav\source\repos\Corporate Performance\Corporate Performance\Areas\Admin\Views\Performance\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </table>\r\n");
#nullable restore
#line 82 "G:\Users\podhav\source\repos\Corporate Performance\Corporate Performance\Areas\Admin\Views\Performance\Index.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>No Performance KPI exists..... </p>\r\n");
#nullable restore
#line 86 "G:\Users\podhav\source\repos\Corporate Performance\Corporate Performance\Areas\Admin\Views\Performance\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Performance>> Html { get; private set; }
    }
}
#pragma warning restore 1591
