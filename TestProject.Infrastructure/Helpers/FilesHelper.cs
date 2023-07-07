using HtmlAgilityPack;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestProject.Infrastructure.Extensions;

namespace TestProject.Infrastructure.Helpers
{
    public static class FilesHelper
    {
        

        /// <summary>
        /// 图片地址拼接
        /// </summary>
        /// <param name="url">原图片地址</param>
        /// <returns> 帐户头像地址</returns>
        public static string FormatFileAddress(this string url,string fileFormAddress)
        {
            if (!string.IsNullOrWhiteSpace(fileFormAddress))
                url = $"{fileFormAddress}/{url}";
            return url;
        }
        /// <summary>
        /// 删除图片地址域名
        /// </summary>
        /// <param name="url">原图片地址</param>
        /// <returns> 相对地址</returns>
        public static string DelPictureUrl(this string url,string fileFormAddress)
        {
            if (!string.IsNullOrWhiteSpace(fileFormAddress) && !string.IsNullOrWhiteSpace(url))
                url = url.Replace(fileFormAddress, "");
            return url;
        }


        /// <summary>
        /// 内容图片处理
        /// </summary>
        /// <param name="content">原图片地址</param>
        /// <returns> 帐户头像地址</returns>
        public static string ToContentPicUrl(this string content,string fileFormAddress)
        {
            if (content.IsNullOrWhiteSpace() || fileFormAddress.IsNullOrWhiteSpace())
                return content;
            var doc = new HtmlDocument();
            doc.LoadHtml(content);
            var rootnode = doc.DocumentNode;
            var htmlNodes = rootnode.SelectNodes("//img");
            if (htmlNodes == null || htmlNodes.Count <= 0) return rootnode.OuterHtml;
            foreach (var imgSrcAttr in htmlNodes.Select(node => node.Attributes["src"]).Where(imgSrcAttr => imgSrcAttr != null))
            {
                imgSrcAttr.Value = $"{fileFormAddress}/{imgSrcAttr.Value}";
            }
            return rootnode.OuterHtml;
        }
        /// <summary>
        /// 删除内容图片处理
        /// </summary>
        /// <param name="content">原图片地址</param>
        /// <returns> </returns>
        public static string DelContentPicUrl(this string content,string fileFormAddress)
        {
            
            if (content.IsNullOrWhiteSpace() || fileFormAddress.IsNullOrWhiteSpace())
                return content;
            var doc = new HtmlDocument();
            doc.LoadHtml(content);
            var rootnode = doc.DocumentNode;
            var htmlNodes = rootnode.SelectNodes("//img");
            if (htmlNodes == null || htmlNodes.Count <= 0) return rootnode.OuterHtml;
            foreach (var imgSrcAttr in htmlNodes.Select(node => node.Attributes["src"]).Where(imgSrcAttr => imgSrcAttr != null))
            {
                imgSrcAttr.Value = imgSrcAttr.Value.Replace(fileFormAddress, "");
            }
            return rootnode.OuterHtml;
        }


    }
}
