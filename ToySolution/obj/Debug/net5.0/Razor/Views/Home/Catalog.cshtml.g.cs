#pragma checksum "C:\Users\User\Desktop\Final-Project\ToySolution\Views\Home\Catalog.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f102f48e65464c7bee6a7bead236469184302ec6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Catalog), @"mvc.1.0.view", @"/Views/Home/Catalog.cshtml")]
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
#line 2 "C:\Users\User\Desktop\Final-Project\ToySolution\Views\_ViewImports.cshtml"
using ToyStoreSolution.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\User\Desktop\Final-Project\ToySolution\Views\_ViewImports.cshtml"
using ToyStoreSolution.Models.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\User\Desktop\Final-Project\ToySolution\Views\_ViewImports.cshtml"
using ToyStoreSolution.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\User\Desktop\Final-Project\ToySolution\Views\_ViewImports.cshtml"
using ToySolution.Models.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\User\Desktop\Final-Project\ToySolution\Views\_ViewImports.cshtml"
using ToySolution.Models.FormModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\User\Desktop\Final-Project\ToySolution\Views\_ViewImports.cshtml"
using ToySolution.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\User\Desktop\Final-Project\ToySolution\Views\_ViewImports.cshtml"
using ToySolution.Models.Entities.Membership;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f102f48e65464c7bee6a7bead236469184302ec6", @"/Views/Home/Catalog.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"306bcbf19667b9dc057b3cb9f7801786fb14c096", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Catalog : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IndexViewModels>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img-top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("..."), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("items-img-holder"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "catalogdetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\User\Desktop\Final-Project\ToySolution\Views\Home\Catalog.cshtml"
  
    ViewData["Title"] = "Catalog";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            DefineSection("addcss", async() => {
                WriteLiteral("\r\n    <style>\r\n        .btn-active {\r\n            background-color: #a5c926;\r\n            color: white;\r\n            border-radius: 8%;\r\n        }\r\n    </style>\r\n");
            }
            );
            WriteLiteral(@"<section style=""padding-top:61px"">
    <div class=""navigation"" style=""margin-top: 80px;display: flex;align-items: flex-start;"">
        <ul>
            <li>Home</li>
            <li>
                <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor""
                     class=""bi bi-arrow-right-short"" viewBox=""0 0 16 16"">
                    <path fill-rule=""evenodd""
                          d=""M4 8a.5.5 0 0 1 .5-.5h5.793L8.146 5.354a.5.5 0 1 1 .708-.708l3 3a.5.5 0 0 1 0 .708l-3 3a.5.5 0 0 1-.708-.708L10.293 8.5H4.5A.5.5 0 0 1 4 8z"" />
                </svg>
            </li>
            <li>Catalog</li>
        </ul>
    </div>
</section>
<section>
    <div class=""container category toys"">
        <div class=""row toy"">
            <div class=""col category-head toyshead"">
                <h2>All Toys</h2>
            </div>

            <div style=""text-align: end;display: flex;
              justify-content: end;
              align-items: center;"" cl");
            WriteLiteral(@"ass=""col toysul push_two two columns"">
                <ul>

                    <li style=""padding: 8px;"">
                        <button style="" border: none; "" class=""btn-active"" cs-filter=""*"" id=""toysulnav"">All Toys</button>

                    </li>
");
#nullable restore
#line 47 "C:\Users\User\Desktop\Final-Project\ToySolution\Views\Home\Catalog.cshtml"
                     foreach (var item in Model.Sort)
                    {


#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li style=\"padding: 8px;\">\r\n                            <button style=\" border: none; \"");
            BeginWriteAttribute("cs-filter", " cs-filter=\"", 1731, "\"", 1751, 1);
#nullable restore
#line 51 "C:\Users\User\Desktop\Final-Project\ToySolution\Views\Home\Catalog.cshtml"
WriteAttributeValue("", 1743, item.Id, 1743, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 51 "C:\Users\User\Desktop\Final-Project\ToySolution\Views\Home\Catalog.cshtml"
                                                                            Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n\r\n                        </li>\r\n");
#nullable restore
#line 54 "C:\Users\User\Desktop\Final-Project\ToySolution\Views\Home\Catalog.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"



                </ul>
            </div>
            <div class=""categoryshop catalogline"">
                <div class=""shopcolor"">

                </div>
            </div>
        </div>


    </div>
    <div class=""toyscard"">
        <div class=""container"">
            <div class=""row"">
");
#nullable restore
#line 73 "C:\Users\User\Desktop\Final-Project\ToySolution\Views\Home\Catalog.cshtml"
                 foreach (var item in Model.Products)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"col items\"");
            BeginWriteAttribute("cs-category", " cs-category=\"", 2260, "\"", 2287, 1);
#nullable restore
#line 75 "C:\Users\User\Desktop\Final-Project\ToySolution\Views\Home\Catalog.cshtml"
WriteAttributeValue("", 2274, item.Sort.Id, 2274, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f102f48e65464c7bee6a7bead236469184302ec610429", async() => {
                WriteLiteral("\r\n                            <div class=\"card\">\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "f102f48e65464c7bee6a7bead236469184302ec610769", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 2511, "~/uploads/images//", 2511, 18, true);
#nullable restore
#line 79 "C:\Users\User\Desktop\Final-Project\ToySolution\Views\Home\Catalog.cshtml"
AddHtmlAttributeValue("", 2529, item.ImgPath, 2529, 13, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                <div class=\"card-body\">\r\n                                    <h5 class=\"card-title product-name\">");
#nullable restore
#line 82 "C:\Users\User\Desktop\Final-Project\ToySolution\Views\Home\Catalog.cshtml"
                                                                   Write(item.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h5>\r\n                                 \r\n                                        <span class=\"product-price\">$  ");
#nullable restore
#line 84 "C:\Users\User\Desktop\Final-Project\ToySolution\Views\Home\Catalog.cshtml"
                                                                  Write(item.Value);

#line default
#line hidden
#nullable disable
                WriteLiteral(" USD</span>\r\n                                    \r\n                                    \r\n\r\n                                </div>\r\n                            </div>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 77 "C:\Users\User\Desktop\Final-Project\ToySolution\Views\Home\Catalog.cshtml"
                                                                                                        WriteLiteral(item.Id);

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
            WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 92 "C:\Users\User\Desktop\Final-Project\ToySolution\Views\Home\Catalog.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

            </div>
        </div>
    </div>
</section>

<section>
    <div style=""display: flex;flex-direction: column; justify-content: center;align-items: center;""
         class=""instagram"">
        <div style=""display: flex;flex-direction: column;align-items: center;justify-content: center;"" class=""insintro"">
            <div class=""title"">
                ElasticThemes
            </div>
            <h2>We're on Instagram!</h2>


        </div>
        <div class=""instimage"">
            <div class=""container"">
                <div class=""row"">
");
#nullable restore
#line 114 "C:\Users\User\Desktop\Final-Project\ToySolution\Views\Home\Catalog.cshtml"
                     foreach (var item in Model.InstagramPhotos)
                    {


#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div data-aos=\"zoom-in\" class=\"col\">\r\n                            <a href=\"https://www.instagram.com/?hl=en\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "f102f48e65464c7bee6a7bead236469184302ec617030", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3970, "~/uploads/images/", 3970, 17, true);
#nullable restore
#line 119 "C:\Users\User\Desktop\Final-Project\ToySolution\Views\Home\Catalog.cshtml"
AddHtmlAttributeValue("", 3987, item.ImgPath, 3987, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </a>\r\n                        </div>\r\n");
#nullable restore
#line 123 "C:\Users\User\Desktop\Final-Project\ToySolution\Views\Home\Catalog.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n\r\n        </div>\r\n        <a id=\"btn\"");
            BeginWriteAttribute("href", " href=\"", 4221, "\"", 4228, 0);
            EndWriteAttribute();
            WriteLiteral(">See More Photos</a>\r\n    </div>\r\n</section>\r\n\r\n\r\n\r\n\r\n");
            DefineSection("addjs", async() => {
                WriteLiteral(@"



    <script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js""></script>




    <script>

        $(function () {


            $(""button[cs-filter]"").click(function () {

                var t = $(this).attr('cs-filter');
                $(""button[cs-filter]"").removeClass('btn-active');
                $(this).addClass('btn-active');
                if (t == ""*"") {
                    $("".items[cs-category]"").show(""fast"");
                } else {
                    $.each($("".items[cs-category]""), function (index, value) {
                        if (!$(this).attr('cs-category').match(new RegExp(t))) {
                            $(this).hide(""fast"");
                        } else {
                            $(this).show(""fast"");
                        }
                    });
                }
            });



        });



    </script>


        <script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery-cookie/1.4.1/jquery.cookie");
                WriteLiteral(@".min.js""></script>
        <script class=""removeable"">

            function addToCard(id) {
                let arr = [];

                var storedJson = $.cookie('basket');

                if (storedJson != undefined && typeof storedJson == 'string') {
                    arr = JSON.parse(storedJson)
                    console.log(arr);
                }

                var found = arr.filter(item => {

                    return item.productId == id;       //eger eyni id li product varsa sayi artirsin
                })[0];

                if (found == undefined) {
                    found = {
                        productId: id,
                        count: 1

                    };
                    arr.push(found)
                }
                else {
                    found.count = found.count + 1;
                }





                var jsonStrinfy = JSON.stringify(arr);



                $.cookie('basket', jsonStrinfy, { expires: 7, path: '/");
                WriteLiteral("\' }); //cocie yaradrq\r\n                showBasketCount();\r\n\r\n            }\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n        </script>\r\n\r\n\r\n    ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexViewModels> Html { get; private set; }
    }
}
#pragma warning restore 1591
