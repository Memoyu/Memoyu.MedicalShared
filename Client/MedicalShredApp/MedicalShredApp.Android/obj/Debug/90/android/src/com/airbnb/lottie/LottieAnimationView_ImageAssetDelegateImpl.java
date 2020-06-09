package com.airbnb.lottie;


public class LottieAnimationView_ImageAssetDelegateImpl
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.airbnb.lottie.ImageAssetDelegate
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_fetchBitmap:(Lcom/airbnb/lottie/LottieImageAsset;)Landroid/graphics/Bitmap;:GetFetchBitmap_Lcom_airbnb_lottie_LottieImageAsset_Handler:Com.Airbnb.Lottie.IImageAssetDelegateInvoker, Lottie.Android\n" +
			"";
		mono.android.Runtime.register ("Com.Airbnb.Lottie.LottieAnimationView+ImageAssetDelegateImpl, Lottie.Android", LottieAnimationView_ImageAssetDelegateImpl.class, __md_methods);
	}


	public LottieAnimationView_ImageAssetDelegateImpl ()
	{
		super ();
		if (getClass () == LottieAnimationView_ImageAssetDelegateImpl.class)
			mono.android.TypeManager.Activate ("Com.Airbnb.Lottie.LottieAnimationView+ImageAssetDelegateImpl, Lottie.Android", "", this, new java.lang.Object[] {  });
	}


	public android.graphics.Bitmap fetchBitmap (com.airbnb.lottie.LottieImageAsset p0)
	{
		return n_fetchBitmap (p0);
	}

	private native android.graphics.Bitmap n_fetchBitmap (com.airbnb.lottie.LottieImageAsset p0);

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
