package md5e1203198aee8086c0eb7d9fc45fe9e3d;


public class WTableViewRenderer
	extends md51558244f76c53b6aeda52c8a337f2c37.TableViewRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Wapps.Forms.Controls.Droid.WTableViewRenderer, Wapps.Forms.Droid", WTableViewRenderer.class, __md_methods);
	}


	public WTableViewRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == WTableViewRenderer.class)
			mono.android.TypeManager.Activate ("Wapps.Forms.Controls.Droid.WTableViewRenderer, Wapps.Forms.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public WTableViewRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == WTableViewRenderer.class)
			mono.android.TypeManager.Activate ("Wapps.Forms.Controls.Droid.WTableViewRenderer, Wapps.Forms.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public WTableViewRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == WTableViewRenderer.class)
			mono.android.TypeManager.Activate ("Wapps.Forms.Controls.Droid.WTableViewRenderer, Wapps.Forms.Droid", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}