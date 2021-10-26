#pragma checksum "C:\Users\ANTONY\Documents\MVCCore\MonolithicWebApplication\MonolithicWebApplication\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "46e79314aa33393d1a7d09f5f1efaf5404391dfc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\ANTONY\Documents\MVCCore\MonolithicWebApplication\MonolithicWebApplication\Views\_ViewImports.cshtml"
using MonolithicWebApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ANTONY\Documents\MVCCore\MonolithicWebApplication\MonolithicWebApplication\Views\_ViewImports.cshtml"
using MonolithicWebApplication.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"46e79314aa33393d1a7d09f5f1efaf5404391dfc", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b7c734380aa084aae66dc164e46ff157609c56e", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ProductModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\ANTONY\Documents\MVCCore\MonolithicWebApplication\MonolithicWebApplication\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Welcome to TechnologyWebStore</h1>\r\n    <p>Learn more and find the greatest variety in technology.</p>\r\n    <br />\r\n    <div class=\"row\" align=\"center\">\r\n");
#nullable restore
#line 11 "C:\Users\ANTONY\Documents\MVCCore\MonolithicWebApplication\MonolithicWebApplication\Views\Home\Index.cshtml"
         foreach (var product in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"card\" style=\"width: 20rem;\">\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 414, "\"", 444, 1);
#nullable restore
#line 14 "C:\Users\ANTONY\Documents\MVCCore\MonolithicWebApplication\MonolithicWebApplication\Views\Home\Index.cshtml"
WriteAttributeValue("", 420, product.ImageUrlProduct, 420, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top\" alt=\"...\" style=\"height:200px;\">\r\n                <div class=\"card-body\">\r\n                    <h5 class=\"card-title\">");
#nullable restore
#line 16 "C:\Users\ANTONY\Documents\MVCCore\MonolithicWebApplication\MonolithicWebApplication\Views\Home\Index.cshtml"
                                      Write(product.NameProduct);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                    <h5 class=\"card-title\">");
#nullable restore
#line 17 "C:\Users\ANTONY\Documents\MVCCore\MonolithicWebApplication\MonolithicWebApplication\Views\Home\Index.cshtml"
                                      Write(product.DescriptionProduct);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 20 "C:\Users\ANTONY\Documents\MVCCore\MonolithicWebApplication\MonolithicWebApplication\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </div>
</div>

<div class=""row"">
    <button onclick=""getAPI()"" class=""btn btn-primary form-control"">Get</button>
    <div class=""row"">
        <ul id=""uList""></ul>
    </div>
</div>

<script>

    function getAPI() {
        $.ajax({
            type: ""GET"",
            url: 'https://jsonplaceholder.typicode.com/todos/',
            contentType: ""application/json"",
            success: function (data) {
                console.log('Data Inicia');
                for (var i = 0; i < data.length; i++) {
                    $('#uList').append(""<li>"" + data[i].title + ""</li>"")
                }
                console.log('Data Finaliza');
            },
            error: function (data) {
                alert('Error');
            }
        });
    }

</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ProductModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
