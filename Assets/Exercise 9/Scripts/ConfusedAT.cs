using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections;
using ParadoxNotion.Serialization.FullSerializer;

namespace NodeCanvas.Tasks.Actions {

	public class ConfusedAT : ActionTask {

		public Transform garbageMan;
		public Transform questionMark;
		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			Debug.Log("WHERE IS THE TRAAAAAAAAAAAAAAAAAAAAAAAAAAAAAASH?!?!??!");
			StartCoroutine(confusedCR());
			EndAction(true);
		}

		protected override void OnUpdate() {
			
		}

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}

		private IEnumerator confusedCR()
		{
			float t = 0;
			//Vector3 directionToCam = (Camera.main.transform.position - garbageMan.position).normalized;
			Vector3 position = Camera.main.WorldToScreenPoint(garbageMan.position);
			questionMark.position = position;
			questionMark.gameObject.SetActive(true);
			Debug.Log("Courotuine runing: " + t);
			while(t < 1)
			{
				t += Time.deltaTime;

				yield return null;
			}
            questionMark.gameObject.SetActive(false);
        }
	}
}