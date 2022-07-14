public enum MonsterType
{
    None = 0,
    Slime = 1,
    Orc = 2,
    Skeleton = 3
}
class Monster : Creature
{
    protected MonsterType type;
    protected Monster(MonsterType type) : base(CreatureType.Monster)
    {
        this.type = type;
    }

    public MonsterType GetMonsterType() { return type; }
}
class Slime : Monster
{
    public Slime() : base(MonsterType.Slime)
    {
        SetInfo(10, 10);
    }
}
class Orc : Monster
{
    public Orc() : base(MonsterType.Orc)
    {
        SetInfo(20, 15);
    }
}
class Skeleton : Monster
{
    public Skeleton() : base(MonsterType.Skeleton)
    {
        SetInfo(15, 25);
    }
}
