using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class ChangePhoto : MonoBehaviour {
	public void Upload(){
		UserManager.currentUser.profilePic = EditorUtility.OpenFilePanel ("Browse","","");
		SetPhoto (UserManager.currentUser);
		UserManager.SaveChanges ();
	}
	public static void SetPhoto(User user){
		WWW resim = new WWW ("file:///" + user.profilePic);
		FindObjectOfType<RawImage> ().texture = resim.texture;
	}
}
