using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Spice.Models;

namespace Spice.Services.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class pageLinkTagHelper : TagHelper
    {
        private readonly IUrlHelperFactory urlHelperFactory;

        public pageLinkTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            this.urlHelperFactory = urlHelperFactory;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public pagingInfo pageModel { get; set; }
        public string pageAction { get; set; }
        public bool pageClassesEnabled { get; set; }
        public string pageClass { get; set; }
        public string pageClassNormal { get; set; }
        public string pageClassSelected { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("div");
            for (int i = 1; i <= pageModel.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                string url= pageModel.urlParam.Replace(":",i.ToString());
                tag.Attributes["href"]=url;
                if (pageClassesEnabled)
                {
                    tag.AddCssClass(pageClass);
                    tag.AddCssClass(i == pageModel.CurrentPage ? pageClassSelected : pageClassNormal);
                }
                tag.InnerHtml.Append(i.ToString());
                result.InnerHtml.AppendHtml(tag);
            }
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
