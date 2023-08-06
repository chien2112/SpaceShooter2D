
public class Constants
{

}
#region Sound enum
public enum MusicType
{
    MusicMenu,
    MusicGame,
    ButtonClick,
}
public enum MusicPlayer
{
    Hurt,
    Die,
    Cannon,
    Rockets,
    Zapper,
    BigSpaceGun,
}
public enum MusicGame
{
    Win,
    Lose,
}
#endregion

public enum EnemyState
{
    Moving,
    Attacking,
}
public enum GameState
{
    Lose,
    Win,
    Pausing,
    Playing,
    Upgrade,
    HomeMenu,
    LevelSelecting
}
public enum ShopPageName
{
    PageShip,
    PageWeapon,
    PageShield,
    PageEngine
}