﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour{
	//发布与订阅模式
	public delegate void ScoreKeep();
	public static event ScoreKeep scoreKeep;

	public SceneController sceneController;

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		sceneController = (SceneController)SSDirector.getInstance ().currentSceneController;
	}

	// Update is called once per frame
	void FixedUpdate() {
		//记分
		if (scoreKeep != null) {
			scoreKeep ();
			
			// 获取控制的方向， 上下左右，
			float KeyVertical = Input.GetAxis ("Vertical");
			float KeyHorizontal = Input.GetAxis ("Horizontal");
			// Debug.Log("keyVertical" + KeyVertical);
			// Debug.Log("keyHorizontal" + KeyHorizontal);
			if (KeyVertical == -1) {
				sceneController.actionManager.MoveRunAction (gameObject, 2); // 下
			} else if (KeyVertical == 1) {
				sceneController.actionManager.MoveRunAction (gameObject, 0); // 上
			}
			if (KeyHorizontal == 1) {
				sceneController.actionManager.MoveRunAction (gameObject, 1); // 右
			} else if (KeyHorizontal == -1) {
				sceneController.actionManager.MoveRunAction (gameObject, 3); // 左
			}
			if (KeyVertical == 0 && KeyHorizontal == 0) {
				animator.SetBool ("run", false);
			} else {
				animator.SetBool ("run", true);
			}
		}
	}
}