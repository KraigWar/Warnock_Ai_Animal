using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Threading;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class PunchingTreeAT : ActionTask {

		public BBParameter<bool> hasAttacked; 
		public float attackTimer;
		private Vector3 startPos, endPos;
		public BBParameter<Transform> currentTree;
		public AnimationCurve animCurve;
		protected override string OnInit() {
			return null;
		}

		
		protected override void OnExecute() {
			hasAttacked.value = false;
			attackTimer = 0;
			startPos = agent.transform.position;
			endPos = currentTree.value.position;
			endPos.y = agent.transform.position.y;

        }

		protected override void OnUpdate() {

			attackTimer += Time.deltaTime;
			agent.transform.position = Vector3.Lerp(startPos, endPos, animCurve.Evaluate(attackTimer)) ;
			if (attackTimer > 0.5)
			{
				hasAttacked.value = true;
				EndAction();
			}
		}
	}
}