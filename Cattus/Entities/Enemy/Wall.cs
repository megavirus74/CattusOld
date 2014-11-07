namespace Cattus.Entities.Enemy
{
    internal class Wall : Entity
    {
        public Wall()
            : base(Resources.Wall)
        {
            Tag = Tags.Enemy;
        }
    }
}