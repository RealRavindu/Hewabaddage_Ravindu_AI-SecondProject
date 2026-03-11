using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace NodeCanvas.Tasks.Conditions {

	public class KeyDownCT : ConditionTask {

		public KeyCode keyToPress;
		protected override string OnInit(){
			return null;
		}

		protected override void OnEnable() {
			
		}


		protected override void OnDisable() {
			
		}

        protected override bool OnCheck() {
			return Input.GetKeyDown(keyToPress);
			//return Keyboard.current.tKey.wasPressedThisFrame;
		}

	}
}