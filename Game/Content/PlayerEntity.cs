using ReMUD.Game.Structures;

namespace ReMUD.Game.Content
{
    public struct PlayerEntity
    {
        public PlayerType Record;
        public bool Online;

        public PlayerEntity(string username)
        {
            Record = new PlayerType();
            Online = false;
        }
    }
}
