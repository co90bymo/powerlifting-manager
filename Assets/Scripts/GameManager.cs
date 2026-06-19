using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Roster Roster { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            Roster = new Roster();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
