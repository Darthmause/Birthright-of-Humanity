using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GabrielGaspar
{
	public class Pooling : MonoBehaviour
	{
		public GameObject prefab;
		public int amount;
		public List<GameObject> poolingList;
		public bool canGrow;


		void Start()
		{
			for (int index = 0; index < amount; index++)
			{
				GameObject gameObject = Instantiate(prefab, Vector3.zero, Quaternion.identity);
				gameObject.SetActive(false);
				poolingList.Add(gameObject);
			}
		}

		public GameObject GetPooledObject()
		{
			GameObject pooledObject = null;
			for (int index = 0; index < amount; index++)
			{
				if (poolingList[index].activeSelf == false)
				{
					pooledObject = poolingList[index];
					break;
				}
			}

			pooledObject.SetActive(true);
			return pooledObject;
		}
	}
}