using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Xml;

namespace Paraesthesia.Configuration
{
	/// <summary>
	/// Reads single value configuration information for a configuration section.
	/// </summary>
	/// <remarks>
	/// <para>
	/// While the <see cref="System.Configuration.DictionarySectionHandler"/>
	/// provides processing for key-value pairs in configuration, sometimes all
	/// that's required is a value with no key - a collection of strings.  This
	/// configuration section handler reads a set of single-valued items from
	/// configuration and processes them into a <see cref="System.Collections.Specialized.StringCollection"/>.
	/// </para>
	/// <para>
	/// A section parsed with this section handler has several <c>add</c> elements,
	/// each of which has a <c>value</c> attribute with the string value that should
	/// be added to the parsed collection.
	/// </para>
	/// </remarks>
	/// <example>
	/// <para>
	/// The following example shows a configuration section that will be parsed
	/// into a collection of three strings.
	/// </para>
	/// <code>
	/// &lt;settings id="Demo" handler="Paraesthesia.Configuration.StringCollectionSectionHandler, Paraesthesia.Web.Hosting.EmbeddedResorucePathProvider"&gt;
	///   &lt;add value="First" /&gt;
	///   &lt;add value="Second" /&gt;
	///   &lt;add value="Third" /&gt;
	/// &lt;/settings&gt;
	/// </code>
	/// </example>
	public class StringCollectionSectionHandler : IConfigurationSectionHandler
	{
		#region StringCollectionSectionHandler Variables

		/// <summary>
		/// Name of the node attribute indicating the value to be parsed.
		/// </summary>
		/// <seealso cref="Paraesthesia.Configuration.StringCollectionSectionHandler" />
		private const string AttributeIdValue = "value";
		
		/// <summary>
		/// Name of the node indicating a value to add to the parsed collection.
		/// </summary>
		/// <seealso cref="Paraesthesia.Configuration.StringCollectionSectionHandler" />
		private const string NodeNameAdd = "add";

		#endregion
		
		#region IConfigurationSectionHandler Members

		/// <summary>
		/// Evaluates the given XML section and returns a <see cref="System.Collections.Specialized.StringCollection"/>
		/// that contains the results of the evaluation.
		/// </summary>
		/// <param name="parent">The configuration settings in a corresponding parent configuration section.</param>
		/// <param name="configContext">
		/// An <see cref="System.Web.Configuration.HttpConfigurationContext"/> when 
		/// <see cref="System.Configuration.IConfigurationSectionHandler.Create"/> is called from the ASP.NET configuration 
		/// system.  Otherwise, this parameter is reserved and is <see langword="null"/>.</param>
		/// <param name="section">The <see cref="System.Xml.XmlNode"/> that contains the configuration information to be handled.  
		/// Provides direct access to the XML contents of the configuration section.
		/// </param>
		/// <returns>A <see cref="System.Collections.Specialized.StringCollection"/> that contains the section's configuration settings.</returns>
		/// <exception cref="System.ArgumentNullException">
		/// Thrown if <paramref name="section" /> is <see langword="null" />.
		/// </exception>
		/// <exception cref="System.Configuration.ConfigurationErrorsException">
		/// Thrown if <paramref name="section" /> contains an unrecognized node or
		/// if any node doesn't have the proper required attributes.
		/// </exception>
		/// <seealso cref="Paraesthesia.Configuration.StringCollectionSectionHandler" />
		/// <seealso cref="System.Configuration.IConfigurationSectionHandler.Create" />
		public object Create(object parent, object configContext, XmlNode section)
		{
			if(section == null)
			{
				throw new ArgumentNullException("section", "Section to parse cannot be null.");
			}

			StringCollection retVal = new StringCollection();
			foreach(XmlNode node in section.ChildNodes)
			{
				if(node.Name == NodeNameAdd)
				{
					XmlAttribute val = node.Attributes[AttributeIdValue];
					if(val == null)
					{
						throw new ConfigurationErrorsException(String.Format(System.Globalization.CultureInfo.InvariantCulture, "Node '{0}' must have an attribute '{1}.'", NodeNameAdd, AttributeIdValue), node);
					}
					string toAdd = "";
					if(!String.IsNullOrEmpty(val.Value))
					{
						toAdd = val.Value;
					}
					retVal.Add(toAdd);
				}
				else
				{
					throw new ConfigurationErrorsException(String.Format(System.Globalization.CultureInfo.InvariantCulture, "Unrecognized node '{0}' in configuration section.", node.Name), node);
				}
			}
			return retVal;
		}

		#endregion
	}
}
