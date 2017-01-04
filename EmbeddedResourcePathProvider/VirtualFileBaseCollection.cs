using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Hosting;

namespace Paraesthesia.Web.Hosting
{
	/// <summary>
	/// A strongly typed <see cref="System.Collections.ObjectModel.KeyedCollection{T, T}" />
	/// where each element is a <see cref="System.Web.Hosting.VirtualFileBase" /> and is keyed
	/// off of the <see cref="System.Web.Hosting.VirtualFileBase.VirtualPath" />
	/// property.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The default constructor for this collection does a culture-invariant case-insensitive
	/// comparison on the keys.  This allows for proper case-insensitive web-oriented
	/// behavior that is generally expected.
	/// </para>
	/// </remarks>
	/// <seealso cref="System.Web.Hosting.VirtualFileBase" />
	public class VirtualFileBaseCollection : KeyedCollection<String, VirtualFileBase>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Paraesthesia.Web.Hosting.VirtualFileBaseCollection" /> class that uses a case-insensitive comparer.
		/// </summary>
		/// <seealso cref="Paraesthesia.Web.Hosting.VirtualFileBaseCollection" />
		public VirtualFileBaseCollection() : base(StringComparer.InvariantCultureIgnoreCase) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="Paraesthesia.Web.Hosting.VirtualFileBaseCollection" /> class that uses the specified equality comparer.
		/// </summary>
		/// <param name="comparer">
		/// The implementation of the <see cref="System.Collections.Generic.IEqualityComparer{T}" />
		/// generic interface to use when comparing keys, or <see langword="null" /> to use the default
		/// equality comparer for the type of the key, obtained from <see cref="System.Collections.Generic.EqualityComparer{T}.Default" />.
		/// </param>
		/// <seealso cref="Paraesthesia.Web.Hosting.VirtualFileBaseCollection" />
		public VirtualFileBaseCollection(IEqualityComparer<String> comparer) : base(comparer) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="Paraesthesia.Web.Hosting.VirtualFileBaseCollection" /> class that uses the specified equality comparer.
		/// </summary>
		/// <param name="comparer">
		/// The implementation of the <see cref="System.Collections.Generic.IEqualityComparer{T}" />
		/// generic interface to use when comparing keys, or <see langword="null" /> to use the default
		/// equality comparer for the type of the key, obtained from <see cref="System.Collections.Generic.EqualityComparer{T}.Default" />.
		/// </param>
		/// <param name="dictionaryCreationThreshold">
		/// The number of elements the collection can hold without creating a lookup dictionary
		/// (0 creates the lookup dictionary when the first item is added), or ?1 to specify that
		/// a lookup dictionary is never created.
		/// </param>
		/// <seealso cref="Paraesthesia.Web.Hosting.VirtualFileBaseCollection" />
		public VirtualFileBaseCollection(IEqualityComparer<String> comparer, int dictionaryCreationThreshold) : base(comparer, dictionaryCreationThreshold) { }

		/// <summary>
		/// Extracts the key from the specified element.
		/// </summary>
		/// <param name="item">
		/// The <see cref="System.Web.Hosting.VirtualFileBase" /> element from which to extract the key (<see cref="System.Web.Hosting.VirtualFileBase.VirtualPath" />).
		/// </param>
		/// <seealso cref="Paraesthesia.Web.Hosting.VirtualFileBaseCollection" />
		protected override String GetKeyForItem(VirtualFileBase item)
		{
			return item.VirtualPath;
		}
	}
}