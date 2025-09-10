using UnityEngine;

public class InitGlobalGame : MonoBehaviour
{
    public static InitGlobalGame Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        GlobalGame.Load();
        // Debug.Log(GlobalGame.Settings.MaxFPS);
        // GlobalGame.Save();
        GlobalGame.Profiles.Load();
        // GlobalGame.Profiles.Save();

        ScenesManager.Instance.LoadScene(GameScenes.MainMenu);
    }

    void FixedUpdate()
    {
        GlobalGame.UpdateInterval.FixedUpdate();
    }

    void Update()
    {
        GlobalGame.Time.Update(Time.deltaTime);
    }

    void LateUpdate()
    {

    }
}
