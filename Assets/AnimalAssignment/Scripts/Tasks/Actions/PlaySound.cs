using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class PlaySound : ActionTask
	{
		//get the audio source and clip to be changed
		private AudioSource m_Source;
		public AudioClip m_Clip;
		protected override string OnInit()
		{
			//make the source the animals component
			m_Source = agent.GetComponent<AudioSource>();

			return null;
		}

		protected override void OnExecute()
		{
			//play the audio clip but make sure to loop it for the walking one
			m_Source.clip = m_Clip;
			m_Source.Play();

			EndAction(true);
		}
	}
}