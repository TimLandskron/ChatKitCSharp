package md55946350e7e7da602d46867269263b519;


public class DialogViewHolder_1
	extends md55946350e7e7da602d46867269263b519.BaseDialogViewHolder_1
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("ChatKitCSharp.Dialogs.DialogViewHolder`1, ChatKitCSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", DialogViewHolder_1.class, __md_methods);
	}


	public DialogViewHolder_1 (android.view.View p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == DialogViewHolder_1.class)
			mono.android.TypeManager.Activate ("ChatKitCSharp.Dialogs.DialogViewHolder`1, ChatKitCSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
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
