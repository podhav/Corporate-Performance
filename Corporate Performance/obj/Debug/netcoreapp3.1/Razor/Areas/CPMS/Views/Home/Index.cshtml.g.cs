#pragma checksum "G:\Users\podhav\source\repos\Corporate Performance\Corporate Performance\Areas\CPMS\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6af41b7706b9f9596d9cb9047a6900375091e1bf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_CPMS_Views_Home_Index), @"mvc.1.0.view", @"/Areas/CPMS/Views/Home/Index.cshtml")]
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
#line 1 "G:\Users\podhav\source\repos\Corporate Performance\Corporate Performance\Areas\CPMS\Views\_ViewImports.cshtml"
using Corporate_Performance;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\Users\podhav\source\repos\Corporate Performance\Corporate Performance\Areas\CPMS\Views\_ViewImports.cshtml"
using Corporate_Performance.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6af41b7706b9f9596d9cb9047a6900375091e1bf", @"/Areas/CPMS/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e9e75ff18bb12f52ecc164943f166f90fbb84fe", @"/Areas/CPMS/Views/_ViewImports.cshtml")]
    public class Areas_CPMS_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Corporate_Performance.Models.ViewModels.IndexViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_ThumbNailAreaPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n<br />\r\n<div class=\"backgroundWhite container\">\r\n\r\n    <ul id=\"menu-filters\" class=\"menu-filter-list list-inline text-center\">\r\n        <li class=\"active btn btn-secondary ml-1 mr-1\" data-filter=\".all-years\">Show All</li>\r\n\r\n");
#nullable restore
#line 9 "G:\Users\podhav\source\repos\Corporate Performance\Corporate Performance\Areas\CPMS\Views\Home\Index.cshtml"
         foreach (var item in Model.Fiscal)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"ml-1 mr-1\" data-filter=\".");
#nullable restore
#line 11 "G:\Users\podhav\source\repos\Corporate Performance\Corporate Performance\Areas\CPMS\Views\Home\Index.cshtml"
                                           Write(item.FiscalYear);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 11 "G:\Users\podhav\source\repos\Corporate Performance\Corporate Performance\Areas\CPMS\Views\Home\Index.cshtml"
                                                             Write(item.FiscalYear);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 12 "G:\Users\podhav\source\repos\Corporate Performance\Corporate Performance\Areas\CPMS\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\r\n\r\n");
#nullable restore
#line 15 "G:\Users\podhav\source\repos\Corporate Performance\Corporate Performance\Areas\CPMS\Views\Home\Index.cshtml"
     foreach (var item in Model.Fiscal)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"row\" id=\"menu-wrapper\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6af41b7706b9f9596d9cb9047a6900375091e1bf5345", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 18 "G:\Users\podhav\source\repos\Corporate Performance\Corporate Performance\Areas\CPMS\Views\Home\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model.performance.Where(p=>p.Fiscal.FiscalYear.Equals(item.FiscalYear));

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
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 20 "G:\Users\podhav\source\repos\Corporate Performance\Corporate Performance\Areas\CPMS\Views\Home\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script src=""https://code.jquery.com/jquery-3.5.1.js"" 
            integrity=""sha256-QWo7LDvxbWT2tbbQ97B53yJnYU3WhH/C8ycbRAkjPDc=""
            crossorigin=""anonymous"">

    </script>

    <script>var posts = $('.post');

    (function ($) {

        $(""#menu-filters li"").click(function() {
            $(""#menu-filters li"").removeClass('active btn btn-secondary');
            $(this).addClass('active btn btn-secondary');

            var selectedFilter = $(this).data(""filter"");

            $("".all-years"").fadeOut();

            setTimeout(function () {
                $(selectedFilter).slideDown();
            }, 300);
        });

        })(jQuery);
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Corporate_Performance.Models.ViewModels.IndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591