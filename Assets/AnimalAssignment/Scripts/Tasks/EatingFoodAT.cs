using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class EatingFoodAT : ActionTask {

		public GameObject fruitPrefab;
		private float destroyTimer;
		private GameObject spawnedFruit;

		public BBParameter<float> fruitsEaten;

		public BBParameter<bool> hasEaten;
		public BBParameter<bool> evolving;

		protected override string OnInit() {
            evolving.value = false;
			return null;
		}

		
		protected override void OnExecute() {

            fruitsEaten.value++;
			

			destroyTimer = 0;
			hasEaten.value = false;
			spawnedFruit = GameObject.Instantiate(fruitPrefab);
			spawnedFruit.transform.position = new Vector3(agent.transform.position.x, agent.transform.position.y + 2.75f, agent.transform.position.z);

            
		}


		protected override void OnUpdate()
		{
            
            destroyTimer += Time.deltaTime;
			if (destroyTimer > 5)
			{
				GameObject.Destroy(spawnedFruit);
                hasEaten.value = true;
                
            }
		}
        protected override void OnStop()
        {
            if (fruitsEaten.value == 3)
            {
                evolving.value = true;
            }
        }
	}
}