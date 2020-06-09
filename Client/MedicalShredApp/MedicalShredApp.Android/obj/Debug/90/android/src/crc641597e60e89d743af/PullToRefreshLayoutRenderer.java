package crc641597e60e89d743af;


public class PullToRefreshLayoutRenderer
	extends android.support.v4.widget.SwipeRefreshLayout
	implements
		mono.android.IGCUserPeer,
		android.support.v4.widget.SwipeRefreshLayout.OnRefreshListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_isRefreshing:()Z:GetIsRefreshingHandler\n" +
			"n_setRefreshing:(Z)V:GetSetRefreshing_ZHandler\n" +
			"n_canChildScrollUp:()Z:GetCanChildScrollUpHandler\n" +
			"n_onRefresh:()V:GetOnRefreshHandler:Android.Support.V4.Widget.SwipeRefreshLayout/IOnRefreshListenerInvoker, Xamarin.Android.Support.SwipeRefreshLayout\n" +
			"";
		mono.android.Runtime.register ("Refractored.XamForms.PullToRefresh.Droid.PullToRefreshLayoutRenderer, Refractored.XamForms.PullToRefresh", PullToRefreshLayoutRenderer.class, __md_methods);
	}


	public PullToRefreshLayoutRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == PullToRefreshLayoutRenderer.class)
			mono.android.TypeManager.Activate ("Refractored.XamForms.PullToRefresh.Droid.PullToRefreshLayoutRenderer, Refractored.XamForms.PullToRefresh", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public PullToRefreshLayoutRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == PullToRefreshLayoutRenderer.class)
			mono.android.TypeManager.Activate ("Refractored.XamForms.PullToRefresh.Droid.PullToRefreshLayoutRenderer, Refractored.XamForms.PullToRefresh", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public boolean isRefreshing ()
	{
		return n_isRefreshing ();
	}

	private native boolean n_isRefreshing ();


	public void setRefreshing (boolean p0)
	{
		n_setRefreshing (p0);
	}

	private native void n_setRefreshing (boolean p0);


	public boolean canChildScrollUp ()
	{
		return n_canChildScrollUp ();
	}

	private native boolean n_canChildScrollUp ();


	public void onRefresh ()
	{
		n_onRefresh ();
	}

	private native void n_onRefresh ();

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
