using System;

public enum ProfileType
{
    User,   // обычный для основных игры
    System  // системный (например для экрана загрузки)
}

public class GameProfile
{
    public string ProfileId;
    public string Name;
    public string VisibleName;
    public ProfileType Type = ProfileType.System;
    public Difficulty Difficulty = Difficulty.Normal;

    public GameProfile(string name)
    {
        ProfileId = $"{DateTime.Now:yyyyMMdd_HHmmss}";
        Name = name;
        VisibleName = name;
        // Difficulty = GlobalGame.Settings.DefaultDifficulty;
    }

    public GameProfileData Save()
    {
        return new GameProfileData()
        {
            ProfileId = ProfileId,
            Name = Name,
            VisibleName = VisibleName,
            Type = Type,
            Difficulty = Difficulty,
        };
    }

    public void Load(GameProfileData gameProfileData)
    {
        ProfileId = gameProfileData.ProfileId;
        Name = gameProfileData.Name;
        VisibleName = gameProfileData.VisibleName;
        Type = gameProfileData.Type;
        Difficulty = gameProfileData.Difficulty;
    }
}

[Serializable]
public class GameProfileData
{
    public string ProfileId;
    public string Name;
    public string VisibleName;
    public ProfileType Type = ProfileType.System;
    public Difficulty Difficulty = Difficulty.Normal;
}