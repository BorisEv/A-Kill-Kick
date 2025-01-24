using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum DamageType
{
    Physical,
    Fire
}

public enum StatusType
{
    OnFire,
    Slow
}

[Serializable]
public class Status
{
    public StatusType type;
    public float duration;
    public float power;
}

[Serializable]
public class Damage
{
    public DamageType type;
    public float power;
}

[Serializable]
public class Attack
{
    public List<Damage> damage;
    public List<Status> status;
}