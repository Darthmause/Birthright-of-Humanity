using UnityEngine;

namespace GabrielGaspar.BirthrightOfHumanity
{
	public class GameManager : Singleton<GameManager>
	{
		[SerializeField]
		private PoolingManager poolingManager;

		private void Awake()
		{

		}

		public void CreateUnits()
		{
			GameObject gameObject = poolingManager.poolingLists[0].GetPooledInstance();
			gameObject.SetActive(true);
		}
	}
}