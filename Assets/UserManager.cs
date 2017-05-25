using System.Collections.Generic;
using UnityEngine;

public class UserManager : MonoBehaviour {
	protected static List<User> users;
	//Make static once database is made
	public static User currentUser;
	protected void InitialiseUsers(){
		if (users == null) {
			users = new List<User> ();
		}
	}
	protected static User RecoverUser(string userName){
		//Recovers the data for this user.
		User u = users.Find(x => x.username == userName);
		return u;
		/*
		foreach(User user in users){
			if (user.username == userName) {
				return user;
			}
		}
		return null;*/
	}
//	protected static User RecoverUser(User u){
//	}
	public static void SaveChanges(){
		//Saves this user's changes
		RecoverUser(currentUser.username).profilePic = currentUser.profilePic;
	}
}
