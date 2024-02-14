using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Dynamic;
using Ardalis.Result;

namespace Clean.Architecture.Web.CustomTagHelper;

[HtmlTargetElement("div", Attributes = "page-model")]
public class PageLinkTagHelper : TagHelper
{
  private IUrlHelperFactory urlHelperFactory;

  public PageLinkTagHelper(IUrlHelperFactory helperFactory)
  {
    urlHelperFactory = helperFactory;
  }

  [ViewContext]
  [HtmlAttributeNotBound]
  public ViewContext? ViewContext { get; set; }

  public PagedInfo? PageModel { get; set; }

  public string? PageAction { get; set; }

  /*Accepts all attributes that are page-other-* like page-other-category="@Model.allTotal" page-other-some="@Model.allTotal"*/
  [HtmlAttributeName(DictionaryAttributePrefix = "page-other-")]
  public Dictionary<string, object> PageOtherValues { get; set; } = new Dictionary<string, object>();

  public bool PageClassesEnabled { get; set; } = false;

  public string? PageClass { get; set; }

  public string? PageClassSelected { get; set; }

  public override void Process(TagHelperContext context, TagHelperOutput output)
  {
    IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext!);
    TagBuilder result = new TagBuilder("div");
    string anchorInnerHtml = "";

    for (int i = 1; i <= PageModel!.TotalPages; i++)
    {
      TagBuilder tag = new TagBuilder("a");
      anchorInnerHtml = AnchorInnerHtml(i, PageModel);

      if (anchorInnerHtml == "..")
        tag.Attributes["href"] = "#";
      else if (PageOtherValues.Keys.Count != 0)
        tag.Attributes["href"] = urlHelper.Action(PageAction, AddDictionaryToQueryString(i));
      else
        tag.Attributes["href"] = urlHelper.Action(PageAction, new { id = i });

      if (PageClassesEnabled)
      {
        tag.AddCssClass(PageClass!);
        tag.AddCssClass(i == PageModel.PageNumber ? PageClassSelected! : "");
      }
      tag.InnerHtml.Append(anchorInnerHtml);
      if (anchorInnerHtml != "")
        result.InnerHtml.AppendHtml(tag);
    }
    output.Content.AppendHtml(result.InnerHtml);
  }

  public IDictionary<string, object> AddDictionaryToQueryString(int i)
  {
    object routeValues=new object();
    var dict = (routeValues != null) ? new RouteValueDictionary(routeValues) : new RouteValueDictionary();
    dict.Add("id", i);
    foreach (string key in PageOtherValues.Keys)
    {
      dict.Add(key, PageOtherValues[key]);
    }

    var expandoObject = new ExpandoObject();
    var expandoDictionary = (IDictionary<string, object>)expandoObject!;
    foreach (var keyValuePair in dict)
    {
      expandoDictionary.Add(keyValuePair!);
    }

    return expandoDictionary;
  }

  public static string AnchorInnerHtml(int i, PagedInfo pagingInfo)
  {
    string anchorInnerHtml = "";
    if (pagingInfo.TotalPages <= 10)
      anchorInnerHtml = i.ToString();
    else
    {
      if (pagingInfo.PageNumber <= 5)
      {
        if ((i <= 8) || (i == pagingInfo.TotalPages))
          anchorInnerHtml = i.ToString();
        else if (i == pagingInfo.TotalPages - 1)
          anchorInnerHtml = "..";
      }
      else if ((pagingInfo.PageNumber > 5) && (pagingInfo.TotalPages - pagingInfo.PageNumber >= 5))
      {
        if ((i == 1) || (i == pagingInfo.TotalPages) || ((pagingInfo.PageNumber - i >= -3) && (pagingInfo.PageNumber - i <= 3)))
          anchorInnerHtml = i.ToString();
        else if ((i == pagingInfo.PageNumber - 4) || (i == pagingInfo.PageNumber + 4))
          anchorInnerHtml = "..";
      }
      else if (pagingInfo.TotalPages - pagingInfo.PageNumber < 5)
      {
        if ((i == 1) || (pagingInfo.TotalPages - i <= 7))
          anchorInnerHtml = i.ToString();
        else if (pagingInfo.TotalPages - i == 8)
          anchorInnerHtml = "..";
      }
    }
    return anchorInnerHtml;
  }
}
