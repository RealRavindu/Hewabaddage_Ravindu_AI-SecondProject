using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections;

namespace NodeCanvas.Tasks.Actions {

	public class ConfusedAT : ActionTask {

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			Debug.Log("WHERE IS THE TRAAAAAAAAAAAAAAAAAAAAAAAAAAAAAASH?!?!??!");
			EndAction(true);
		}

		protected override void OnUpdate() {
			
		}

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}

		IEnumerator confusedCR()
		{
			float t = 0;
			while(t < 1)
			{
				t += Time.deltaTime;
				yield return null;
			}
		}
	}
}