using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;

namespace GabrielGaspar.BirthrightOfHumanity
{
	[RequireComponent(typeof(Animator))]
	[RequireComponent(typeof(NavMeshAgent))]
	public class Unit : MonoBehaviour, IDamageable<int>, IMoveable
	{
		private Animator animator;
		private NavMeshAgent agent;
		private bool selected;

		public Animator Animator
		{
			get
			{
				return animator;
			}

			set
			{
				animator = value;
			}
		}

		public NavMeshAgent Agent
		{
			get
			{
				return agent;
			}

			set
			{
				agent = value;
			}
		}

		public bool Selected
		{
			get
			{
				return selected;
			}

			set
			{
				selected = value;
			}
		}

		public void Start()
		{
			UnitController.AddUnit(this);
		}

		public void Damage(int amount)
		{
			throw new NotImplementedException();
		}

		public void Move(Vector3 position)
		{
		
		}
	}
}