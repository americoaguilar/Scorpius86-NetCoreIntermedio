#pragma checksum "D:\OneDrive\Galaxy\ASP NET MVC 6.0 Nivel Intermedio\01 - Componentes MVC Y aplicando seguridad al Website\Galaxy.MVC\Galaxy.MVC.Authentication\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e9950d4d8b148356187f1abd33a46ac0db2f1e12"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "D:\OneDrive\Galaxy\ASP NET MVC 6.0 Nivel Intermedio\01 - Componentes MVC Y aplicando seguridad al Website\Galaxy.MVC\Galaxy.MVC.Authentication\Views\_ViewImports.cshtml"
using Galaxy.MVC.Authentication;

#line default
#line hidden
#line 2 "D:\OneDrive\Galaxy\ASP NET MVC 6.0 Nivel Intermedio\01 - Componentes MVC Y aplicando seguridad al Website\Galaxy.MVC\Galaxy.MVC.Authentication\Views\_ViewImports.cshtml"
using Galaxy.MVC.Authentication.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e9950d4d8b148356187f1abd33a46ac0db2f1e12", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"724b116eee1450766ae56a516d2b5c9cdc73426f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-lg btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Auth", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SignUp", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 27, true);
            WriteLiteral("\r\n<div class=\"jumbotron\">\r\n");
            EndContext();
#line 3 "D:\OneDrive\Galaxy\ASP NET MVC 6.0 Nivel Intermedio\01 - Componentes MVC Y aplicando seguridad al Website\Galaxy.MVC\Galaxy.MVC.Authentication\Views\Home\Index.cshtml"
     if (User.Identity.IsAuthenticated)
    {

#line default
#line hidden
            BeginContext(75, 17, true);
            WriteLiteral("        <h1>Hola ");
            EndContext();
            BeginContext(93, 18, false);
#line 5 "D:\OneDrive\Galaxy\ASP NET MVC 6.0 Nivel Intermedio\01 - Componentes MVC Y aplicando seguridad al Website\Galaxy.MVC\Galaxy.MVC.Authentication\Views\Home\Index.cshtml"
            Write(User.Identity.Name);

#line default
#line hidden
            EndContext();
            BeginContext(111, 8, true);
            WriteLiteral("!</h1>\r\n");
            EndContext();
#line 6 "D:\OneDrive\Galaxy\ASP NET MVC 6.0 Nivel Intermedio\01 - Componentes MVC Y aplicando seguridad al Website\Galaxy.MVC\Galaxy.MVC.Authentication\Views\Home\Index.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(143, 31, true);
            WriteLiteral("        <h1>Hello World!</h1>\r\n");
            EndContext();
#line 10 "D:\OneDrive\Galaxy\ASP NET MVC 6.0 Nivel Intermedio\01 - Componentes MVC Y aplicando seguridad al Website\Galaxy.MVC\Galaxy.MVC.Authentication\Views\Home\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(181, 200, true);
            WriteLiteral("    <p class=\"lead\">Cras justo odio, dapibus ac facilisis in, egestas eget quam. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus.</p>\r\n");
            EndContext();
#line 12 "D:\OneDrive\Galaxy\ASP NET MVC 6.0 Nivel Intermedio\01 - Componentes MVC Y aplicando seguridad al Website\Galaxy.MVC\Galaxy.MVC.Authentication\Views\Home\Index.cshtml"
     if (!User.Identity.IsAuthenticated)
    {

#line default
#line hidden
            BeginContext(430, 25, true);
            WriteLiteral("        <p>\r\n            ");
            EndContext();
            BeginContext(455, 121, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e9950d4d8b148356187f1abd33a46ac0db2f1e126534", async() => {
                BeginContext(531, 41, true);
                WriteLiteral("\r\n                Registrar\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(576, 16, true);
            WriteLiteral("\r\n        </p>\r\n");
            EndContext();
#line 19 "D:\OneDrive\Galaxy\ASP NET MVC 6.0 Nivel Intermedio\01 - Componentes MVC Y aplicando seguridad al Website\Galaxy.MVC\Galaxy.MVC.Authentication\Views\Home\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(599, 383, true);
            WriteLiteral(@"</div>
<div class=""row marketing"">
    <div class=""col-lg-6"">
        <h4>Subheading</h4>
        <p>Donec id elit non mi porta gravida at eget metus. Maecenas faucibus mollis interdum.</p>
    </div>
    <div class=""col-lg-6"">
        <h4>Subheading</h4>
        <p>Donec id elit non mi porta gravida at eget metus. Maecenas faucibus mollis interdum.</p>
    </div>
</div>");
            EndContext();
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
