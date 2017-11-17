using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GabrielGaspar
{
	public class Spawn : MonoBehaviour
	{

		public Pooling pooling;

		public void Start()
		{

		}

		public void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				GameObject pooledObject = pooling.GetPooledObject();
				pooledObject.SetActive(true);
			}
		}
	}
}
