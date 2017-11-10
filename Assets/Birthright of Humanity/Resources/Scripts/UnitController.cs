using System.Collections.Generic;
using UnityEngine;

namespace GabrielGaspar.BirthrightOfHumanity
{
	public class UnitController : MonoBehaviour
	{
		private Vector2 startSelectionPosition;

		private Vector2 releaseSelectionPosition;

		[SerializeField]
		public Texture2D selectionMarqueeTexture;

		[SerializeField]
		public static List<Unit> playerUnits = new List<Unit>();

		[SerializeField]
		public Unit[] selectedUnits;

		public static void AddUnit(Unit unit)
		{
			playerUnits.Add(unit);
		}

		private void OnGUI()
		{
			if (Input.GetButtonDown("Select"))
			{
				startSelectionPosition = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
			}

			if (Input.GetButton("Select"))
			{
				releaseSelectionPosition = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
				GUI.DrawTexture(new Rect(startSelectionPosition.x, startSelectionPosition.y, releaseSelectionPosition.x - startSelectionPosition.x, releaseSelectionPosition.y - startSelectionPosition.y), selectionMarqueeTexture);
			}

			if (Input.GetButtonUp("Select"))
			{
				foreach (Unit unit in selectedUnits)
				{
					unit.Selected = false;
				}

				Vector2 selectionRetanglePosition = new Vector2() { x = Mathf.Min(startSelectionPosition.x, releaseSelectionPosition.x), y = Mathf.Min(startSelectionPosition.y, releaseSelectionPosition.y) };
				Vector2 selectionRetangleSize = new Vector2() { x = Mathf.Abs(startSelectionPosition.x - releaseSelectionPosition.x), y = Mathf.Abs(startSelectionPosition.y - releaseSelectionPosition.y) };

				selectedUnits = GetUnitsInSelectionRectangle(new Rect(selectionRetanglePosition, selectionRetangleSize));

				foreach (Unit unit in selectedUnits)
				{
					unit.Selected = true;
				}
			}
		}

		public Unit[] GetUnitsInSelectionRectangle(Rect selectionRectangle)
		{
			List<Unit> selectedUnits = new List<Unit>();

			foreach (Unit unit in playerUnits)
			{
				Vector3 unitPositionInWorld = Camera.main.WorldToScreenPoint(unit.transform.position);
				Vector2 unitPositionInScreen = new Vector2(unitPositionInWorld.x, Screen.height - unitPositionInWorld.y);
				if (selectionRectangle.Contains(unitPositionInScreen))
				{
					selectedUnits.Add(unit);
				}
			}
			return selectedUnits.ToArray();
		}

		public void Update()
		{
			if (Input.GetButton("Action"))
			{
				Action();
			}
		}


		public void Action()
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, LayerMask.GetMask("Interactable")))
			{
				if (hit.collider.tag == "Terrain")
				{
					foreach (Unit unit in selectedUnits)
					{
						if (unit is IMoveable)
						{
							unit.Move(hit.point);
						}
					}
				}
			}
		}
	}
}