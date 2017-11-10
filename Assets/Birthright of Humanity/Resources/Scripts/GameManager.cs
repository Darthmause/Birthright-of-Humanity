using System.Collections.Generic;

namespace GabrielGaspar.BirthrightOfHumanity
{
	public class GameManager : Singleton<GameManager>
	{
		private List<IPlayerController> players;

		public void RegisterPlayer(IPlayerController player)
		{
			players.Add(player);
		}

		public void UnregisterPlayer()
		{

		}
	}
}