#pragma checksum "/Users/BigfishDim/Documents/howest/code/dotnet/masterView/Views/Password/Generate.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "951014877d82c33e7f27121c3958ef8390a6e0a8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Password_Generate), @"mvc.1.0.view", @"/Views/Password/Generate.cshtml")]
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
#line 1 "/Users/BigfishDim/Documents/howest/code/dotnet/masterView/Views/_ViewImports.cshtml"
using masterView;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/BigfishDim/Documents/howest/code/dotnet/masterView/Views/_ViewImports.cshtml"
using masterView.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"951014877d82c33e7f27121c3958ef8390a6e0a8", @"/Views/Password/Generate.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"04670259467cad7e322023d6e541c08b17881235", @"/Views/_ViewImports.cshtml")]
    public class Views_Password_Generate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/password_generated.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "/Users/BigfishDim/Documents/howest/code/dotnet/masterView/Views/Password/Generate.cshtml"
  
    Layout = "_PasswordLayout";
    ViewData["Title"] = "Generated Password";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "951014877d82c33e7f27121c3958ef8390a6e0a84128", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n<main id=\"password_generate\">\r\n    <header>\r\n    <h1>Generated password</h1>\r\n    </header>\r\n\r\n    <section>\r\n    <ul>\r\n");
#nullable restore
#line 17 "/Users/BigfishDim/Documents/howest/code/dotnet/masterView/Views/Password/Generate.cshtml"
         if(@Model.Status == "success"){

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li><label>algo:</label>");
#nullable restore
#line 18 "/Users/BigfishDim/Documents/howest/code/dotnet/masterView/Views/Password/Generate.cshtml"
                               Write(Model.Algo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n            <li><label >password:</label><span class=\"generated_password\">");
#nullable restore
#line 19 "/Users/BigfishDim/Documents/howest/code/dotnet/masterView/Views/Password/Generate.cshtml"
                                                                     Write(Model.Password);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\r\n");
#nullable restore
#line 20 "/Users/BigfishDim/Documents/howest/code/dotnet/masterView/Views/Password/Generate.cshtml"
        }else{

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"error\">");
#nullable restore
#line 21 "/Users/BigfishDim/Documents/howest/code/dotnet/masterView/Views/Password/Generate.cshtml"
                         Write(Model.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 22 "/Users/BigfishDim/Documents/howest/code/dotnet/masterView/Views/Password/Generate.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\r\n    </section>\r\n</main>\r\n\r\n\r\n");
            DefineSection("footer", async() => {
                WriteLiteral("\r\n    <div>generated password - <span class=\"footerColor\">");
#nullable restore
#line 29 "/Users/BigfishDim/Documents/howest/code/dotnet/masterView/Views/Password/Generate.cshtml"
                                                   Write(Model.Status);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span></div>\r\n");
            }
            );
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
