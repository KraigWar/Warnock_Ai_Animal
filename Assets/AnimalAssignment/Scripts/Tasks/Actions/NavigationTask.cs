using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class NavigationTask : ActionTask {


		public BBParameter<Vector3> targetPositionBBP;
        public BBParameter<float> timeSinceLastSampleBBP;
		public BBParameter<bool> isMovingBBP;

		public float sampleRateInSeconds;
		public float sampleRadiusInUnits;

		private Vector3 lastTargetPosition;
		private NavMeshAgent navAgent;


        protected override string OnInit() {
			navAgent = agent.GetComponent<NavMeshAgent>();
			if (navAgent == null)
			return $"{agent.name} = NavigationTask: Unable to get NavMesh Agent Reference!!";
			else 
				return null;
		}

		protected override void OnUpdate()
		{
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
				//Debug.Log($"{navAgent.destination}, {agent.transform.position}, {Vector3.Distance(new Vector3(agent.transform.position.x, 0, agent.transform.position.z),new Vector3(navAgent.destination.x, 0, navAgent.destination.z))<0.1f}");
				isMovingBBP.value =
					navAgent.remainingDistance <= 0.1f  &&
					navAgent.remainingDistance != Mathf.Infinity ||
					navAgent.pathPending;
			}
		}
	}
}