package com.airbnb.lottie;


public class LottieComposition$Factory_ActionCompositionLoaded
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.airbnb.lottie.OnCompositionLoadedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCompositionLoaded:(Lcom/airbnb/lottie/LottieComposition;)V:GetOnCompositionLoaded_Lcom_airbnb_lottie_LottieComposition_Handler:Com.Airbnb.Lottie.IOnCompositionLoadedListenerInvoker, Lottie.Android\n" +
			"";
		mono.android.Runtime.register ("Com.Airbnb.Lottie.LottieComposition+Factory+ActionCompositionLoaded, Lottie.Android", LottieComposition$Factory_ActionCompositionLoaded.class, __md_methods);
	}


	public LottieComposition$Factory_ActionCompositionLoaded ()
	{
		super ();
		if (getClass () == LottieComposition$Factory_ActionCompositionLoaded.class)
			mono.android.TypeManager.Activate ("Com.Airbnb.Lottie.LottieComposition+Factory+ActionCompositionLoaded, Lottie.Android", "", this, new java.lang.Object[] {  });
	}


	public void onCompositionLoaded (com.airbnb.lottie.LottieComposition p0)
	{
		n_onCompositionLoaded (p0);
	}

	private native void n_onCompositionLoaded (com.airbnb.lottie.LottieComposition p0);

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
