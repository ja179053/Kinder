using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//Outputs
public class ShowUser : UserManager {
	static Text sOName;
	static Button profileButton;
	List<User> potentialMatches;
	User displayedUser = null;
	User DisplayedUser{
		get{
			return displayedUser;
		}set {
			displayedUser = value;
			ShowUserInfo (DisplayedUser);
		}
	}
	void Start(){
		sOName = GameObject.Find ("UsernameText").GetComponent<Text>();
		profileButton = GameObject.Find ("MyProfileButton").GetComponent<Button> ();
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			InitalisePotentialMatches (users.ToArray());
			if (potentialMatches.Count > 0) {
				DisplayedUser = potentialMatches [Random.Range (0, potentialMatches.Count)];
			}
		}
		if (Input.GetKey (KeyCode.Escape)) {
			LogOut ();
		}
	}
	public void LogOut(){
		SceneManager.LoadScene (0);
	}
	void InitalisePotentialMatches(User[] allUsers){
		potentialMatches = new List<User>();
		if (users != null && currentUser != null) {
			potentialMatches.AddRange (allUsers);
			potentialMatches.Remove (currentUser);
			Debug.Log ("Found " + potentialMatches.Count + " potential matches of " + users.Count);
		}
	}

	public static void ShowUserInfo(User user = null){
		profileButton.gameObject.SetActive (user != null);
		if (user == null) {
			user = UserManager.currentUser;
		}
		if (user.profilePic != null) {
			ChangePhoto.SetPhoto (user);
		}
		//ELSE USE DEFAULT PIC
		sOName.text = user.username;
	}
	public void MyInfo(){
		ShowUserInfo ();
	}
}
