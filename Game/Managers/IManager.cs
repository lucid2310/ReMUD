
namespace ReMUD.Game.Managers
{
    public interface IManager
    {
        ushort Initialize(string path);
        ushort Close();
    }
}
