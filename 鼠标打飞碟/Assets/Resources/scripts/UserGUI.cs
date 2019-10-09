using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public interface IUserAction{
    void StartGame();
    void ReStart();
}

public class UserGUI : MonoBehaviour{
    
	private IUserAction action;

    void Start() {
		action = SSDirector.getInstance ().currentScenceController as IUserAction;
	}

    void OnGUI() {
		if (GUI.Button(new Rect(Screen.width/2-38, 40, 76, 30), "(RE)PLAY"))
            action.ReStart();
    }
}