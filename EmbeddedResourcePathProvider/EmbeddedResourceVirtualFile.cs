using System;
using System.Reflection;

namespace Paraesthesia.Web.Hosting
{
	/// <summary>
	/// Represents a file object in embedded resource space.
	/// </summary>
	/// <remarks>
	/// <para>
	/// This type is used by the <see cref="Paraesthesia.Web.Hosting.EmbeddedResourcePathProvider"/>
	/// to serve embedded resources as virtual files.  The properties on the
	/// file can be used to retrieve an embedded resource stream from the
	/// <see cref="Paraesthesia.Web.Hosting.EmbeddedResourceVirtualFile.ContainingAssembly"/>
	/// at the appropriate
	/// <see cref="Paraesthesia.Web.Hosting.EmbeddedResourceVirtualFile.ResourcePath"/>
	/// using reflection.  As part of the <see cref="System.Web.Hosting.VirtualFile"/>
	/// interface, you can do this easily via <see cref="Paraesthesia.Web.Hosting.EmbeddedResourceVirtualFile.Open"/>.
	/// </para>
	/// <para>
	/// For more information on embedded resource virtual filesystem
	/// usage, see <see cref="Paraesthesia.Web.Hosting.EmbeddedResourcePathProvider"/>
	/// </para>
	/// </remarks>
	/// <seealso cref="Paraesthesia.Web.Hosting.EmbeddedResourcePathProvider" />
	public class EmbeddedResourceVirtualFile : System.Web.Hosting.VirtualFile
	{
		
		#region EmbeddedResourceVirtualFile Variables

		#region Instance

		/// <summary>
		/// Internal storage for the
		/// <see cref="Paraesthesia.Web.Hosting.EmbeddedResourceVirtualFile.ContainingAssembly" />
		/// property.
		/// </summary>
		/// <seealso cref="Paraesthesia.Web.Hosting.EmbeddedResourceVirtualFile" />
        private Assembly _containingAssembly;

		/// <summary>
		/// Internal storage for the
		/// <see cref="Paraesthesia.Web.Hosting.EmbeddedResourceVirtualFile.ResourcePath" />
		/// property.
		/// </summary>
		/// <seealso cref="Paraesthesia.Web.Hosting.EmbeddedResourceVirtualFile" />
        private string _resourcePath;

		#endregion

		#endregion



		#region EmbeddedResourceVirtualFile Properties

		/// <summary>
		/// Gets a reference to the assembly containing the virtual file.
		/// </summary>
		/// <value>
		/// A <see cref="System.Reflection.Assembly"/> that contains the embedded
		/// resource with the file contents.
		/// </value>
		/// <seealso cref="Paraesthesia.Web.Hosting.EmbeddedResourceVirtualFile" />
		public Assembly ContainingAssembly
		{
			get
			{
				return _containingAssembly;
			}
		}

		/// <summary>
		/// Gets the path to the embedded resource in the containing assembly.
		/// </summary>
		/// <value>
		/// A <see cref="System.String"/> that indicates an embedded resource
		/// in the <see cref="Paraesthesia.Web.Hosting.EmbeddedResourceVirtualFile.ContainingAssembly"/>
		/// that represents the file for this instance.
		/// </value>
		/// <seealso cref="Paraesthesia.Web.Hosting.EmbeddedResourceVirtualFile" />
		public string ResourcePath
		{
			get
			{
				return _resourcePath;
			}
		}

		#endregion



		#region EmbeddedResourceVirtualFile Implementation

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="Paraesthesia.Web.Hosting.EmbeddedResourceVirtualFile" /> class.
		/// </summary>
		/// <param name="virtualPath">The virtual path to the resource represented by this instance.</param>
		/// <param name="containingAssembly">The <see cref="System.Reflection.Assembly"/> containing the resource represented by this instance.</param>
		/// <param name="resourcePath">The path to the embedded resource in the <paramref name="containingAssembly" />.</param>
		/// <exception cref="System.ArgumentNullException">
		/// Thrown if <paramref name="containingAssembly" /> or <paramref name="resourcePath" /> is <see langword="null" />.
		/// </exception>
		/// <exception cref="System.ArgumentOutOfRangeException">
		/// Thrown if <paramref name="resourcePath" /> is <see cref="System.String.Empty" />.
		/// </exception>
		/// <seealso cref="Paraesthesia.Web.Hosting.EmbeddedResourceVirtualFile" />
        public EmbeddedResourceVirtualFile(string virtualPath, Assembly containingAssembly, string resourcePath)
			: base(virtualPath)
		{
			if (containingAssembly == null)
			{
				throw new ArgumentNullException("containingAssembly");
			}
			if (resourcePath == null)
			{
				throw new ArgumentNullException("resourcePath");
			}
			if (resourcePath.Length == 0)
			{
				throw new ArgumentOutOfRangeException("resourcePath");
			}
			this._containingAssembly = containingAssembly;
			this._resourcePath = resourcePath;
		}

		#endregion

		#region Overrides
        
		/// <summary>
		/// Returns a read-only stream to the virtual resource.
		/// </summary>
		/// <returns>A read-only stream to the virtual file.</returns>
		/// <seealso cref="Paraesthesia.Web.Hosting.EmbeddedResourceVirtualFile" />
		/// <seealso cref="System.Web.Hosting.VirtualFile.Open" />
		public override System.IO.Stream Open()
		{
			return this.ContainingAssembly.GetManifestResourceStream(this.ResourcePath);
		}

		#endregion

		#endregion
	}
}
