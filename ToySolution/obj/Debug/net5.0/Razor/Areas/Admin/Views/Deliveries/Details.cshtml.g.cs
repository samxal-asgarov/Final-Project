#pragma checksum "C:\Users\User\Desktop\Final-Project\ToySolution\Areas\Admin\Views\Deliveries\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "be80097b84d469a9356d5427d2f36b204ca5090c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Deliveries_Details), @"mvc.1.0.view", @"/Areas/Admin/Views/Deliveries/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"be80097b84d469a9356d5427d2f36b204ca5090c", @"/Areas/Admin/Views/Deliveries/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"41afc7ea4c12f1ede13a8b89ac18551fc32ae096", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Deliveries_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ToyStoreSolution.Models.Entities.Delivery>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\User\Desktop\Final-Project\ToySolution\Areas\Admin\Views\Deliveries\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Delivery</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "C:\Users\User\Desktop\Final-Project\ToySolution\Areas\Admin\Views\Deliveries\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Head));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n          ");
#nullable restore
#line 17 "C:\Users\User\Desktop\Final-Project\ToySolution\Areas\Admin\Views\Deliveries\Details.cshtml"
     Write(Model.Head.PlainTexts());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n      \r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be80097b84d469a9356d5427d2f36b204ca5090c7877", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 23 "C:\Users\User\Desktop\Final-Project\ToySolution\Areas\Admin\Views\Deliveries\Details.cshtml"
                           WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be80097b84d469a9356d5427d2f36b204ca5090c10031", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ToyStoreSolution.Models.Entities.Delivery> Html { get; private set; }
    }
}
#pragma warning restore 1591
