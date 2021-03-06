﻿//code from Telerik MVC Extensions

using QZCHY.PanoramaQuzhou.Core;
using QZCHY.PanoramaQuzhou.Core.Infrastructure;
using System;
using System.IO;
using System.Web.Routing;
using System.Xml;

namespace QZCHY.PanoramaQuzhou.Web.Framework.Menu
{
    public class XmlSiteMap
    {
        public XmlSiteMap()
        {
            RootNode = new SiteMapNode();
        }

        public SiteMapNode RootNode { get; set; }

        public virtual void LoadFrom(string physicalPath)
        {
            var webHelper = EngineContext.Current.Resolve<IWebHelper>();
            string filePath = webHelper.MapPath(physicalPath);
            string content = File.ReadAllText(filePath);

            if (!string.IsNullOrEmpty(content))
            {
                using (var sr = new StringReader(content))
                {
                    using (var xr = XmlReader.Create(sr,
                            new XmlReaderSettings
                            {
                                CloseInput = true,
                                IgnoreWhitespace = true,
                                IgnoreComments = true,
                                IgnoreProcessingInstructions = true
                            }))
                    {
                        var doc = new XmlDocument();
                        doc.Load(xr);

                        if ((doc.DocumentElement != null) && doc.HasChildNodes)
                        {
                            XmlNode xmlRootNode = doc.DocumentElement.FirstChild;
                            Iterate(RootNode, xmlRootNode);
                        }
                    }
                }
            }
        }

        private static void Iterate(SiteMapNode siteMapNode, XmlNode xmlNode)
        {
            PopulateNode(siteMapNode, xmlNode);

            foreach (XmlNode xmlChildNode in xmlNode.ChildNodes)
            {
                if (xmlChildNode.LocalName.Equals("siteMapNode", StringComparison.InvariantCultureIgnoreCase))
                {
                    var siteMapChildNode = new SiteMapNode();
                    siteMapNode.ChildNodes.Add(siteMapChildNode);

                    Iterate(siteMapChildNode, xmlChildNode);
                }
            }
        }

        private static void PopulateNode(SiteMapNode siteMapNode, XmlNode xmlNode)
        {
            //system name
            siteMapNode.SystemName = GetStringValueFromAttribute(xmlNode, "SystemName");

            //title
            //var CSCZJResource = GetStringValueFromAttribute(xmlNode, "CSCZJResource");
            siteMapNode.Title = siteMapNode.SystemName;

            //routes, url
            string controllerName = GetStringValueFromAttribute(xmlNode, "controller");
            string actionName = GetStringValueFromAttribute(xmlNode, "action");
            string url = GetStringValueFromAttribute(xmlNode,  "url");
            if (!string.IsNullOrEmpty(controllerName) && !string.IsNullOrEmpty(actionName))
            {
                siteMapNode.ControllerName = controllerName;
                siteMapNode.ActionName = actionName;

                //apply admin area as described here - http://www.CSCZJcommerce.com/boards/t/20478/broken-menus-in-admin-area-whilst-trying-to-make-a-plugin-admin-page.aspx
                siteMapNode.RouteValues = new RouteValueDictionary { {"area", "Admin"} };
            }
            else if (!string.IsNullOrEmpty(url))
            {
                siteMapNode.Url = url;
            }

            //Icon
            siteMapNode.Icon = GetStringValueFromAttribute(xmlNode, "Icon");

            //Color
            siteMapNode.Color = GetStringValueFromAttribute(xmlNode, "Color");

            //是否为Group
            siteMapNode.Group = Convert.ToBoolean(GetStringValueFromAttribute(xmlNode, "Group"));

            //先默认都为True
            siteMapNode.Visible = true;

            ////permission name
            //var permissionNames = GetStringValueFromAttribute(xmlNode, "PermissionNames");
            //if (!string.IsNullOrEmpty(permissionNames))
            //{
            //    //权限控制 暂时注释
            //    //var permissionService = EngineContext.Current.Resolve<IPermissionService>();
            //    //siteMapNode.Visible = permissionNames.Split(new [] { ',' }, StringSplitOptions.RemoveEmptyEntries)
            //    //   .Any(permissionName => permissionService.Authorize(permissionName.Trim()));
            //}
            //else
            //{
            //    siteMapNode.Visible = true;
            //}
        }

        private static string GetStringValueFromAttribute(XmlNode node, string attributeName)
        {
            string value = null;

            if (node.Attributes != null && node.Attributes.Count > 0)
            {
                XmlAttribute attribute = node.Attributes[attributeName];

                if (attribute != null)
                {
                    value = attribute.Value;
                }
            }

            return value;
        }
    }
}
