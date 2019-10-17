using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IUserAction{
    void StartGame();
    void ReStart();
	ActionMode GetMode();
	void SwitchMode();
}

public class UserGUI : MonoBehaviour{
    
	private IUserAction action;

    void Start() {
		action = SSDirector.getInstance ().currentScenceController as IUserAction;
	}

    void OnGUI() {
		if (GUI.Button(new Rect(Screen.width/2-38, 60, 76, 30), "(RE)PLAY"))
            action.ReStart();
		if (action.GetMode () == ActionMode.KINEMATIC) {
			if(GUI.Button(new Rect(Screen.width/2-100, 25, 200, 30), "SWITCH TO PHYSIC"))
				action.SwitchMode();
		}
		if (action.GetMode () == ActionMode.PHYSIC) {
			if(GUI.Button(new Rect(Screen.width/2-100, 25, 200, 30), "SWITCH TO KINEMATIC"))
				action.SwitchMode();
		}
    }
}