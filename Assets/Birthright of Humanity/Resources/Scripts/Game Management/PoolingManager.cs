using System;
using System.Collections.Generic;
using UnityEngine;

namespace GabrielGaspar.BirthrightOfHumanity
{
	public class PoolingManager : MonoBehaviour
	{
		[SerializeField]
		public List<PoolingList> poolingLists;

		private void Start()
		{
			for (int index = 0; index < poolingLists.Count; index++)
			{
				poolingLists[index].GenerateInstances();
			}
		}
	}
}