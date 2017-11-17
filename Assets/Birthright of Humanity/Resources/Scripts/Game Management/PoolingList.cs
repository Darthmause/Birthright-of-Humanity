using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GabrielGaspar
{
	[Serializable]
	public class PoolingList
	{
		public GameObject prefab;
		public int amount;
		public List<GameObject> prefabInstances;
		public bool canGrow;

		public void GenerateInstances()
		{
			for (int index = 0; index < amount; index++)
			{
				GameObject gameObject = GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity);
				gameObject.SetActive(false);
				prefabInstances.Add(gameObject);
			}
		}

		public GameObject GetPooledInstance()
		{
			foreach(GameObject gameObject in prefabInstances)
			{
				if(gameObject.activeSelf == false)
				{
					return gameObject;
				}
			}
			return null;
		}
	}
}