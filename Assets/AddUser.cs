//Accesses Input UI
using UnityEngine.UI;
//Accesses Debug Log
using UnityEngine;

//Adds a user to the list. Checks if list exists and user exists.
public class AddUser : UserManager {
	public InputField infield;
	public GameObject outputs;

	void Start(){
		currentUser = null;
		outputs.SetActive (false);
	}

	public void Add(){
		string welcomeMessage = "";
		InitialiseUsers ();
		currentUser = RecoverUser (infield.text);
		bool recovered = true;
		if (currentUser == null) {
			recovered = false;
			currentUser = new User (infield.text);
			users.Add (currentUser);
			SaveChanges ();
			welcomeMessage = "Registration successful. ";
		} 
		welcomeMessage += "Welcome ";
		if (recovered) {
			welcomeMessage += "back ";
		}
		outputs.SetActive (true);
		infield.transform.parent.gameObject.SetActive (false);
		ShowUser.ShowUserInfo ();
		Debug.Log (welcomeMessage + infield.text);
	/*	if (!users.Contains (newUser)) {
			users.Add (newUser);
			Debug.Log("Registration successful");
			Debug.Log ("There are " + users.Count + " users.");
		} else {
			Debug.Log("Welcome back " + infield.text);
		}
		currentUser = newUser;*/
		//Saves user database.
	}
}
