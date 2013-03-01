/*
 * Copyright (c) Dominick Baier.  All rights reserved.
 * see license.txt
 */

namespace DemoApplication.IdentityModel.Extensions.XmlExtensions
{
    using System.Diagnostics.Contracts;
    using System.Xml;
    using System.Xml.Linq;

    public static partial class XmlExtensions
    {
        /// <summary>
        /// Converts a XmlDocument to a XDocument.
        /// </summary>
        /// <param name="document">The XmlDocument.</param>
        /// <returns>A XDocument</returns>
        public static XDocument ToXDocument(this XmlDocument document)
        {
            Contract.Requires(document != null);
            Contract.Ensures(Contract.Result<XDocument>() != null);


            return new XmlConverter(document).CreateXDocument();
        }   
    }
}