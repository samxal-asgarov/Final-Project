#pragma checksum "C:\Users\User\Desktop\Final-Project\ToySolution\Areas\Admin\Views\Users\Activated.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2bbda98ca659e4d151737ff94c00c0e3bb4c6040"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Users_Activated), @"mvc.1.0.view", @"/Areas/Admin/Views/Users/Activated.cshtml")]
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
#line 2 "C:\Users\User\Desktop\Final-Project\ToySolution\Areas\Admin\Views\_ViewImports.cshtml"
using ToyStoreSolution.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\User\Desktop\Final-Project\ToySolution\Areas\Admin\Views\_ViewImports.cshtml"
using ToyStoreSolution.Models.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\User\Desktop\Final-Project\ToySolution\Areas\Admin\Views\_ViewImports.cshtml"
using ToyStoreSolution.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\User\Desktop\Final-Project\ToySolution\Areas\Admin\Views\_ViewImports.cshtml"
using ToySolution.AppCode.Application.InstagramModule;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\User\Desktop\Final-Project\ToySolution\Areas\Admin\Views\_ViewImports.cshtml"
using ToySolution.Views.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\User\Desktop\Final-Project\ToySolution\Areas\Admin\Views\_ViewImports.cshtml"
using ToySolution.AppCode.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\User\Desktop\Final-Project\ToySolution\Areas\Admin\Views\_ViewImports.cshtml"
using ToySolution.AppCode.Application.AboutStoryModule;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\User\Desktop\Final-Project\ToySolution\Areas\Admin\Views\_ViewImports.cshtml"
using ToySolution.AppCode.Application.AboutIntroModule;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\User\Desktop\Final-Project\ToySolution\Areas\Admin\Views\_ViewImports.cshtml"
using ToySolution.AppCode.Application.ProductIntroModule;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\User\Desktop\Final-Project\ToySolution\Areas\Admin\Views\_ViewImports.cshtml"
using ToySolution.AppCode.Application.AboutUsModule;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\User\Desktop\Final-Project\ToySolution\Areas\Admin\Views\_ViewImports.cshtml"
using ToySolution.Models.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\User\Desktop\Final-Project\ToySolution\Areas\Admin\Views\_ViewImports.cshtml"
using ToySolution.AppCode.Application.AboutToys;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\User\Desktop\Final-Project\ToySolution\Areas\Admin\Views\_ViewImports.cshtml"
using ToySolution.AppCode.Application.DeliveryModule;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\User\Desktop\Final-Project\ToySolution\Areas\Admin\Views\_ViewImports.cshtml"
using ToySolution.Models.FormModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\User\Desktop\Final-Project\ToySolution\Areas\Admin\Views\_ViewImports.cshtml"
using ToySolution.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\User\Desktop\Final-Project\ToySolution\Areas\Admin\Views\_ViewImports.cshtml"
using ToySolution.Models.Entities.Membership;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2bbda98ca659e4d151737ff94c00c0e3bb4c6040", @"/Areas/Admin/Views/Users/Activated.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"41afc7ea4c12f1ede13a8b89ac18551fc32ae096", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Users_Activated : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<StoreUser>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\User\Desktop\Final-Project\ToySolution\Areas\Admin\Views\Users\Activated.cshtml"
  
    ViewData["Title"] = "Activated";


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-12\">\r\n        <h1>Email: ");
#nullable restore
#line 10 "C:\Users\User\Desktop\Final-Project\ToySolution\Areas\Admin\Views\Users\Activated.cshtml"
              Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n        <h1>UserName: ");
#nullable restore
#line 11 "C:\Users\User\Desktop\Final-Project\ToySolution\Areas\Admin\Views\Users\Activated.cshtml"
                 Write(Model.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    </div>\r\n    <div class=\"d-flex justify-content-end aligen-items-center\">\r\n\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2bbda98ca659e4d151737ff94c00c0e3bb4c60408330", async() => {
                WriteLiteral("Go Back");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2bbda98ca659e4d151737ff94c00c0e3bb4c60409577", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 17 "C:\Users\User\Desktop\Final-Project\ToySolution\Areas\Admin\Views\Users\Activated.cshtml"
             if (Model.Active)
            {


#line default
#line hidden
#nullable disable
                WriteLiteral("                <input type=\"hidden\" name=\"Activated\" value=\"false\" />\r\n");
                WriteLiteral("                <input type=\"submit\" class=\"btn btn-danger \" value=\"Disable\" />\r\n");
#nullable restore
#line 23 "C:\Users\User\Desktop\Final-Project\ToySolution\Areas\Admin\Views\Users\Activated.cshtml"

            }
            else
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <input type=\"hidden\" name=\"Activated\" value=\"true\" />\r\n");
                WriteLiteral("                <input type=\"submit\" class=\"btn btn-success \" value=\"Activated\" style=\"margin-left:10px\" />\r\n");
#nullable restore
#line 30 "C:\Users\User\Desktop\Final-Project\ToySolution\Areas\Admin\Views\Users\Activated.cshtml"

            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<StoreUser> Html { get; private set; }
    }
}
#pragma warning restore 1591
