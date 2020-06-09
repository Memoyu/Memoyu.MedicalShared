package crc64dbf290ea7e69bd26;


public class BoxArrayAdapter
	extends android.widget.ArrayAdapter
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getFilter:()Landroid/widget/Filter;:GetGetFilterHandler\n" +
			"";
		mono.android.Runtime.register ("Plugin.InputKit.Platforms.Droid.BoxArrayAdapter, Plugin.InputKit", BoxArrayAdapter.class, __md_methods);
	}


	public BoxArrayAdapter (android.content.Context p0, int p1)
	{
		super (p0, p1);
		if (getClass () == BoxArrayAdapter.class)
			mono.android.TypeManager.Activate ("Plugin.InputKit.Platforms.Droid.BoxArrayAdapter, Plugin.InputKit", "Android.Content.Context, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1 });
	}


	public BoxArrayAdapter (android.content.Context p0, int p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == BoxArrayAdapter.class)
			mono.android.TypeManager.Activate ("Plugin.InputKit.Platforms.Droid.BoxArrayAdapter, Plugin.InputKit", "Android.Content.Context, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public BoxArrayAdapter (android.content.Context p0, int p1, int p2, java.util.List p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == BoxArrayAdapter.class)
			mono.android.TypeManager.Activate ("Plugin.InputKit.Platforms.Droid.BoxArrayAdapter, Plugin.InputKit", "Android.Content.Context, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib:System.Collections.IList, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public BoxArrayAdapter (android.content.Context p0, int p1, int p2, java.lang.Object[] p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == BoxArrayAdapter.class)
			mono.android.TypeManager.Activate ("Plugin.InputKit.Platforms.Droid.BoxArrayAdapter, Plugin.InputKit", "Android.Content.Context, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib:Java.Lang.Object[], Mono.Android", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public BoxArrayAdapter (android.content.Context p0, int p1, java.util.List p2)
	{
		super (p0, p1, p2);
		if (getClass () == BoxArrayAdapter.class)
			mono.android.TypeManager.Activate ("Plugin.InputKit.Platforms.Droid.BoxArrayAdapter, Plugin.InputKit", "Android.Content.Context, Mono.Android:System.Int32, mscorlib:System.Collections.IList, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public BoxArrayAdapter (android.content.Context p0, int p1, java.lang.Object[] p2)
	{
		super (p0, p1, p2);
		if (getClass () == BoxArrayAdapter.class)
			mono.android.TypeManager.Activate ("Plugin.InputKit.Platforms.Droid.BoxArrayAdapter, Plugin.InputKit", "Android.Content.Context, Mono.Android:System.Int32, mscorlib:Java.Lang.Object[], Mono.Android", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public android.widget.Filter getFilter ()
	{
		return n_getFilter ();
	}

	private native android.widget.Filter n_getFilter ();

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
