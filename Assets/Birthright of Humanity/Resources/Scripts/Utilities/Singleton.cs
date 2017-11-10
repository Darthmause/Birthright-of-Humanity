using UnityEngine;

public class Singleton<TYPE> : MonoBehaviour where TYPE : MonoBehaviour
{
	private static TYPE instance;

	private static object lockObject = new object();

	private static bool applicationIsQuitting;

	private void Awake()
	{
		if (!instance)
		{
			instance = this as TYPE;

			DontDestroyOnLoad(this.gameObject);
		}
		else
		{
			Destroy(this);
		}
	}

	public void OnDestroy()
	{
		applicationIsQuitting = true;
	}
	public static TYPE Instance
	{
		get
		{
			if (applicationIsQuitting)
			{
				Debug.Log("Instance of " + typeof(TYPE) + " already destroyed on application quit, returning null");
				return null;
			}
			lock (lockObject)
			{
				instance = FindObjectOfType<TYPE>();

				if (FindObjectsOfType<TYPE>().Length > 1)
				{
					Debug.LogError("Singleton design of " + typeof(TYPE) + "has been broken, the scene has more than one instance");

					return instance;
				}
				if (!instance)
				{
					GameObject gameObject = new GameObject(typeof(TYPE).ToString() + "(Singleton)", typeof(TYPE));
					DontDestroyOnLoad(gameObject);
					Debug.Log("Singleton instance of " + typeof(TYPE).ToString() + "was created with DontDestoyOnLoad option enabled.");
				}
				else
				{
					Debug.Log("Returning the already created instance of " + typeof(TYPE).ToString() + ".");
				}
				return instance;
			}
		}
	}
}

