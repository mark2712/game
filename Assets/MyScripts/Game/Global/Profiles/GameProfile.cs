using System;
using UniRx;

public enum ProfileTypes
{
    User,   // обычный для основных игры
    System  // системный (например для экрана загрузки)
}

public class GameProfile
{
    public readonly ReactiveProperty<string> ProfileId = new("");
    public readonly ReactiveProperty<string> Name = new("");
    public readonly ReactiveProperty<string> VisibleName = new("");
    public readonly ReactiveProperty<ProfileTypes> ProfileType = new(ProfileTypes.System);
    public readonly ReactiveProperty<DifficultyGame> Difficulty = new(DifficultyGame.Normal);

    public GameProfile(string name)
    {
        ProfileId.Value  = $"{DateTime.Now:yyyyMMdd_HHmmss}";
        Name.Value = name;
        VisibleName.Value = name;
        // ProfileType.Value = ProfileType.System;
        // Difficulty.Value = Difficulty.Normal;
    }

    public GameProfile ChangeProfileType(ProfileTypes type)
    {
        ProfileType.Value = type;
        return this;
    }

    public GameProfileData Save()
    {
        return new GameProfileData()
        {
            ProfileId = ProfileId.Value,
            Name = Name.Value,
            VisibleName = VisibleName.Value,
            ProfileType = ProfileType.Value,
            Difficulty = Difficulty.Value,
        };
    }

    public void Load(GameProfileData gameProfileData)
    {
        ProfileId.Value = gameProfileData.ProfileId;
        Name.Value = gameProfileData.Name;
        VisibleName.Value = gameProfileData.VisibleName;
        ProfileType.Value = gameProfileData.ProfileType;
        Difficulty.Value = gameProfileData.Difficulty;
    }
}

[Serializable]
public class GameProfileData
{
    public string ProfileId;
    public string Name;
    public string VisibleName;
    public ProfileTypes ProfileType = ProfileTypes.System;
    public DifficultyGame Difficulty = DifficultyGame.Normal;
}