using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class NavigationTask : ActionTask {

		//setting up the position where the animal will go, tracking the time since its scanned, and to check if its moving
		public BBParameter<Vector3> targetPositionBBP;
        public BBParameter<float> timeSinceLastSampleBBP;
		public BBParameter<bool> isMovingBBP;


		public float sampleRateInSeconds;
		public float sampleRadiusInUnits;

		private Vector3 lastTargetPosition;
		private NavMeshAgent navAgent;

		//get the nav mesh for the animal to walk on
        protected override string OnInit() {
			navAgent = agent.GetComponent<NavMeshAgent>();
			if (navAgent == null)
			return $"{agent.name} = NavigationTask: Unable to get NavMesh Agent Reference!!";
			else 
				return null;
		}

		protected override void OnUpdate()
		{
			//start the sample can and check if the target position is not equal to the last one, to then set the destination for the animal to walk to
			timeSinceLastSampleBBP.value += Time.deltaTime;
			if (timeSinceLastSampleBBP.value > sampleRateInSeconds)
			{
				timeSinceLastSampleBBP.value = 0;

				if (lastTargetPosition != targetPositionBBP.value)
				{
					lastTargetPosition = targetPositionBBP.value;
					if (NavMesh.SamplePosition(targetPositionBBP.value, out NavMeshHit hitInfo, sampleRadiusInUnits, NavMesh.AllAreas))
					{
						navAgent.SetDestination(hitInfo.position);
					}
				}
				isMovingBBP.value =
					navAgent.remainingDistance <= 0.1f  &&
					navAgent.remainingDistance != Mathf.Infinity ||
					navAgent.pathPending;
				/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			}
		}
	}
}