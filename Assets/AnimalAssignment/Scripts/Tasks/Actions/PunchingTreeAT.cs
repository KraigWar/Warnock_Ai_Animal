using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Threading;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class PunchingTreeAT : ActionTask {

		//setting up the booling to check if the animal has attacked, the timer in which it will attack for
		//grab the animals stating position and end position
		//get the the tree the animal is at's location
		//create an animation curve to have the punching use it to look like a full animation
		public BBParameter<bool> hasAttacked; 
		public float attackTimer;
		private Vector3 startPos, endPos;
		public BBParameter<Transform> currentTree;
		public AnimationCurve animCurve;
		protected override string OnInit() {
			return null;
		}

		
		protected override void OnExecute() {
			//make sure it knows it hasn't attacked
			//reset the timer
			//get the start and end positon
			hasAttacked.value = false;
			attackTimer = 0;
			startPos = agent.transform.position;
			endPos = currentTree.value.position;
			endPos.y = agent.transform.position.y;

        }

		protected override void OnUpdate() {

			//begin the timer
			//make the animal lerp between the start and end position using the animation curve for the values
			//make sure the animal knows it has attacked
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