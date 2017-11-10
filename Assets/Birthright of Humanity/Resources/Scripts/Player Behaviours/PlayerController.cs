using UnityEngine;

namespace GabrielGaspar.BirthrightOfHumanity
{
	public class PlayerController : MonoBehaviour, IPlayerController
	{
		public void Start()
		{
			GameManager.Instance.RegisterPlayer(this);
		}
	}
}