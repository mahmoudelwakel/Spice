#pragma checksum "E:\Projects\Spice\Spice\Spice\Areas\Customer\Views\Orders\OrderPickUp.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cb17f3faa7a83a4616c2ca6ce06f3f050ef5ef1e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Customer_Views_Orders_OrderPickUp), @"mvc.1.0.view", @"/Areas/Customer/Views/Orders/OrderPickUp.cshtml")]
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
#line 1 "E:\Projects\Spice\Spice\Spice\Areas\Customer\Views\_ViewImports.cshtml"
using Spice;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Projects\Spice\Spice\Spice\Areas\Customer\Views\_ViewImports.cshtml"
using Spice.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\Projects\Spice\Spice\Spice\Areas\Customer\Views\_ViewImports.cshtml"
using Spice.Models.ViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\Projects\Spice\Spice\Spice\Areas\Customer\Views\_ViewImports.cshtml"
using Spice.Models.Utility;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cb17f3faa7a83a4616c2ca6ce06f3f050ef5ef1e", @"/Areas/Customer/Views/Orders/OrderPickUp.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"431bf9170c638beabf7bc734481a8d8de625dd8a", @"/Areas/Customer/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Customer_Views_Orders_OrderPickUp : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OrderListViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("page-class", "btn  border", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("page-class-normal", "btn btn-light", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("page-class-selected", "btn btn-info active", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-group float-right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Spice.Services.TagHelpers.pageLinkTagHelper __Spice_Services_TagHelpers_pageLinkTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cb17f3faa7a83a4616c2ca6ce06f3f050ef5ef1e5427", async() => {
                WriteLiteral(@"
    <br />
    <br />
    <h2 class=""text-info"">Order Ready For PickUp</h2>
    <br />
    <div class=""whiteBackground border"">
        <div class=""container border border-secondary mb-3""style=""height:60px"">
            <div class=""row container "">
                <div class=""col-11"">
                    <div class=""row""style=""padding-top:10px;"">
                        <div class=""col-4"">
                            ");
#nullable restore
#line 19 "E:\Projects\Spice\Spice\Spice\Areas\Customer\Views\Orders\OrderPickUp.cshtml"
                       Write(Html.Editor("searchName",new{htmlAttributes=new{@class="form-control",@placeholder="Name...."
                            }}));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n                        </div>\r\n                         <div class=\"col-4\">\r\n                            ");
#nullable restore
#line 24 "E:\Projects\Spice\Spice\Spice\Areas\Customer\Views\Orders\OrderPickUp.cshtml"
                       Write(Html.Editor("searchPhone",new{htmlAttributes=new{@class="form-control",@placeholder="Phone...."
                            }}));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n                        </div>\r\n                         <div class=\"col-4\">\r\n                            ");
#nullable restore
#line 29 "E:\Projects\Spice\Spice\Spice\Areas\Customer\Views\Orders\OrderPickUp.cshtml"
                       Write(Html.Editor("searchEmail",new{htmlAttributes=new{@class="form-control",@placeholder="Email...."
                            }}));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"

                        </div>

                    </div>

                </div>
                <div class=""col-1"">
                    <div class="" row""style=""padding-top:10px"">
                        <button type=""submit""class=""btn btn-primary form-control""value=""Search"">
                            <i class=""fas fa-search""></i>
                        </button>

                    </div>

                </div>

            </div>

        </div>
        <div>

");
#nullable restore
#line 52 "E:\Projects\Spice\Spice\Spice\Areas\Customer\Views\Orders\OrderPickUp.cshtml"
             if (Model.Orders.Count() == 0)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <p class=\"text-danger\">No Order Ready For PickUp.....</p>\r\n");
#nullable restore
#line 55 "E:\Projects\Spice\Spice\Spice\Areas\Customer\Views\Orders\OrderPickUp.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <table class=\"table table-striped border\">\r\n                    <tr class=\"table-secondary\">\r\n                        <th>");
#nullable restore
#line 60 "E:\Projects\Spice\Spice\Spice\Areas\Customer\Views\Orders\OrderPickUp.cshtml"
                       Write(Html.DisplayNameFor(e=>e.Orders[0].OrderHeader.Id));

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n                        <th>");
#nullable restore
#line 61 "E:\Projects\Spice\Spice\Spice\Areas\Customer\Views\Orders\OrderPickUp.cshtml"
                       Write(Html.DisplayNameFor(e=>e.Orders[0].OrderHeader.PickUpName));

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n                        <th>");
#nullable restore
#line 62 "E:\Projects\Spice\Spice\Spice\Areas\Customer\Views\Orders\OrderPickUp.cshtml"
                       Write(Html.DisplayNameFor(e=>e.Orders[0].OrderHeader.ApplicationUser.Email));

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n                        <th>");
#nullable restore
#line 63 "E:\Projects\Spice\Spice\Spice\Areas\Customer\Views\Orders\OrderPickUp.cshtml"
                       Write(Html.DisplayNameFor(e=>e.Orders[0].OrderHeader.PickUpTime));

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n                        <th>");
#nullable restore
#line 64 "E:\Projects\Spice\Spice\Spice\Areas\Customer\Views\Orders\OrderPickUp.cshtml"
                       Write(Html.DisplayNameFor(e=>e.Orders[0].OrderHeader.OrderTotal));

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n                        <th>Total Item</th>\r\n                        <th></th>\r\n                    </tr>\r\n");
#nullable restore
#line 68 "E:\Projects\Spice\Spice\Spice\Areas\Customer\Views\Orders\OrderPickUp.cshtml"
                     foreach (var item in Model.Orders)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 71 "E:\Projects\Spice\Spice\Spice\Areas\Customer\Views\Orders\OrderPickUp.cshtml"
                           Write(Html.DisplayFor(e=>item.OrderHeader.Id));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 72 "E:\Projects\Spice\Spice\Spice\Areas\Customer\Views\Orders\OrderPickUp.cshtml"
                           Write(Html.DisplayFor(e=>item.OrderHeader.PickUpName));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 73 "E:\Projects\Spice\Spice\Spice\Areas\Customer\Views\Orders\OrderPickUp.cshtml"
                           Write(Html.DisplayFor(e=>item.OrderHeader.ApplicationUser.Email));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 74 "E:\Projects\Spice\Spice\Spice\Areas\Customer\Views\Orders\OrderPickUp.cshtml"
                           Write(Html.DisplayFor(e=>item.OrderHeader.PickUpTime));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 75 "E:\Projects\Spice\Spice\Spice\Areas\Customer\Views\Orders\OrderPickUp.cshtml"
                           Write(Html.DisplayFor(e=>item.OrderHeader.OrderTotal));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 76 "E:\Projects\Spice\Spice\Spice\Areas\Customer\Views\Orders\OrderPickUp.cshtml"
                           Write(Html.DisplayFor(e=>item.OrderDetails.Count));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n\r\n                            <td>\r\n                                <button class=\"btn btn-success showDetails\" type=\"button\" data-id=\"");
#nullable restore
#line 79 "E:\Projects\Spice\Spice\Spice\Areas\Customer\Views\Orders\OrderPickUp.cshtml"
                                                                                              Write(item.OrderHeader.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" data-toggle=\"modal\">\r\n                                    <i class=\"fas fa-list-alt\"></i>&nbsp; Details\r\n                                </button>\r\n\r\n\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 86 "E:\Projects\Spice\Spice\Spice\Areas\Customer\Views\Orders\OrderPickUp.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </table>\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cb17f3faa7a83a4616c2ca6ce06f3f050ef5ef1e13533", async() => {
                    WriteLiteral("\r\n                ");
                }
                );
                __Spice_Services_TagHelpers_pageLinkTagHelper = CreateTagHelper<global::Spice.Services.TagHelpers.pageLinkTagHelper>();
                __tagHelperExecutionContext.Add(__Spice_Services_TagHelpers_pageLinkTagHelper);
#nullable restore
#line 89 "E:\Projects\Spice\Spice\Spice\Areas\Customer\Views\Orders\OrderPickUp.cshtml"
__Spice_Services_TagHelpers_pageLinkTagHelper.pageModel = Model.pagingInfo;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("page-model", __Spice_Services_TagHelpers_pageLinkTagHelper.pageModel, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 89 "E:\Projects\Spice\Spice\Spice\Areas\Customer\Views\Orders\OrderPickUp.cshtml"
__Spice_Services_TagHelpers_pageLinkTagHelper.pageClassesEnabled = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("page-classes-enabled", __Spice_Services_TagHelpers_pageLinkTagHelper.pageClassesEnabled, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Spice_Services_TagHelpers_pageLinkTagHelper.pageClass = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Spice_Services_TagHelpers_pageLinkTagHelper.pageClassNormal = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Spice_Services_TagHelpers_pageLinkTagHelper.pageClassSelected = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
                WriteLiteral("                <br />\r\n");
#nullable restore
#line 93 "E:\Projects\Spice\Spice\Spice\Areas\Customer\Views\Orders\OrderPickUp.cshtml"

            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </div>\r\n\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<div class=""modal fade"" id=""myModal"" tabindex=""-1"" role=""dialog"" aria-hidden=""true""style=""width:100%"">
    <div class=""modal-dialog-centered modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header bg-success text-light"">
                <div class=""col-10 offset-1"">
                  <center><h5 class=""modal-title"">Order Details</h5></center>   
                </div>
               <div class=""col-1"">
                    <button class=""btn btn-outline-secondary float-right close""aria-label=""Close"" data-dismiss=""modal"" >&times;</button>
               </div>
            </div>
            <div class=""modal-body justify-content-center"" id=""myModalContent"">
            </div>
          

        </div>

    </div>

</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        var URL = ""/Customer/Orders/GetOrderDetails"";
        $(function() {
            $("".showDetails"").click(function() {
                var $buttonClicked = $(this);
                var id = $buttonClicked.attr('data-id');
                $.ajax(
                    {
                        type: ""GET"",
                        url: URL,
                        contentType: ""text/html;charset=utf-8"",
                        data: { ""id"": id },
                        cache: false,
                        dataType: ""html"",
                        success: function(data) {
                            $('#myModalContent').html(data);
                            $('#myModal').modal('show');
                        },
                        error: function() {
                            alert(""Dynamic Data Load Failed"")
                        }

                    }
                );
            });





        });
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OrderListViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
