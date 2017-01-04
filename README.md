# EmbeddedResourcePathProvider - Binary-Only ASP.NET 2.0

ASP.NET 2.0 `VirtualPathProvider` that allows you to serve your ASPX markup from embedded resources. [Originally released on my blog.](http://www.paraesthesia.com/archive/2007/07/13/embeddedresourcepathprovider-binary-only-asp.net-2.0.aspx/)

This VirtualPathProvider implementation allows you to register
assemblies that are allowed to serve embedded files and specify on those
assemblies which embedded resources are allowed to be served.  After you
register the provider (programmatically at app startup), when ASP.NET
asks for a specific page it will ask the provider.  If the provider
finds that file in embedded resources, it's served from there; if not,
it falls back to the filesystem as usual.

Detailed usage is included in the API documentation and an
implementation can be seen in the included demo site.  On a high level,
you need to:

1.  Set each page, control, or file in your web project that you wish to
    serve embedded as embedded resource.  (Normally these are "Content"
    files - switch to "Embedded Resource" in your project to embed
    them.)
2.  Add a `Paraesthesia.Web.Hosting.EmbeddedResourceFileAttribute` to your
    web project assembly for each embedded page.  This lets the
    `VirtualPathProvider` know which resources are allowed to be served
    (and allows you to differentiate files that get served from
    resources that are used for other purposes).
3.  In your `Global.asax`, at application startup, add a registration for
    the `EmbeddedResourcePathProvider`:
    `HostingEnvironment.RegisterVirtualPathProvider(new EmbeddedResourcePathProvider());`
4.  In your `web.config`, add a `configSection` called
    `embeddedFileAssemblies` that gets parsed by
    `Paraesthesia.Configuration.StringCollectionSectionHandler`. This
    section will contain the list of assemblies that the
    `VirtualPathProvider` should query for `EmbeddedResourceFileAttribute` items.
5.  Optionally specify the ability to override embedded files with files
    in the filesystem by adding an `appSettings` key called
    `Paraesthesia.Web.Hosting.EmbeddedResourcePathProvider.AllowOverrides`
    and setting it to `true`.

A demo web site with an installer is included to show the provider in
action.  It will also help you see what the code/config/attribute
declarations are so you can follow that pattern in your own usage.

This sort of thing, in combination with things like the
[WebResourceAttribute](http://msdn2.microsoft.com/en-us/library/system.web.ui.webresourceattribute.aspx)
and
[WebResource.axd](http://weblogs.asp.net/jeff/archive/2005/07/18/419842.aspx)
can get you ever closer to serving an entirely binary web site.

Caveats:

-   This won't work for sites that rely on file system security. I
    primarily work with forms authentication, so this isn't a problem
    for me. It may be for you.
-   Cache dependencies on embedded resource files are actually set on
    the assemblies that contain the files.
-   It doesn't support "directories" so if you use the
    HostingEnvironment to go directory browsing, you won't see the
    embedded files.
-   There's some weirdness with IIS where you can't set the "default
    page" for a directory to be an embedded file.  IIS detects it's not
    there and pre-emptively returns a 404.
-   Your site has to run in [High trust
    mode](http://msdn2.microsoft.com/en-us/library/system.web.aspnethostingpermissionlevel.aspx)
    for this to work. This is a requirement of the VirtualPathProvider
    framework.
-   This is going to be a one-shot deal. I'm not going to be posting
    updates or actively supporting it or anything. Take it at your own
    risk, your mileage may vary, etc.
-   The source bundle includes the source for the VirtualPathProvider,
    related attributes, support classes, a readme, and a demo web site
    illustrating the project in action. The compiled bundle is the
    compiled assembly, the XML API doc, the installer for the demo site,
    and a readme.
-   It's totally free and open-source. Do whatcha like.