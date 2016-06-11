using UnityEngine;
using System.Collections;
/// <summary>
/// I played too much CarWars as a kid.  This is just off the top of my head!
/// My idea is that the cars can be customized, right now, I have more customization than I expect to need.
/// 
/// Challenges: How do I create...
/// A monster scaling function
/// A way to procedurally generate vehicles (mobs)
/// A way to save data for the players vechicle
/// 
/// A way to control the cars (AI)
/// A way to instantiate/object pool the weapons being fired.
/// 
/// </summary>
public class CarBaseClass : MonoBehaviour {
    Vehicle vehicle;
    WeaponMount[] weapons;
    ArmorValues armor;          
    TiresValues tires;                    
    GameObject car;
    Texture texture;
    CarAudioClips audiofiles;
}

public class TiresValues {
    //tires can take damage too.  (think critical hits)
    Tires frontRight;
    Tires frontLeft;
    Tires backRight;
    Tires backleft;
}
public class ArmorValues {
    //armor by type, armor by location Front,Left, Right, Back, Top, Bottom
    Armor front;
    Armor right;
    Armor left;
    Armor back;
    Armor top;
    Armor bottom;
}
public class CarAudioClips {
    //these will probably need to be in the resources folder and loaded at run time.
    AudioClip[] RandomSounds;
    AudioClip[] Barks;
    AudioClip[] Accelleration;
    AudioClip[] Braking;
}

public class Vehicle {
    [SerializeField]
    float topSpeed;
    [SerializeField]
    float acceleration;
    [SerializeField]
    float breaking;
    [SerializeField]
    float handling;         //usused.  How responsive is the car
    [SerializeField]
    float DamageResistance; //does the car's structure reduce the damage recieved (is it well built?)
    [SerializeField]
    float size;         //compact, sub-compact, midsize, luxury, sedan, cross-over, van, tractor -trailer, motorcycle, trike,
    [SerializeField]
    int occupants;  //how many people fit int the car  - simple calculation #of weapons, also tied to the vehicle size
    float maximumFuel;
    float currentFuel;
}
public class WeaponMount {
    public Weapons weapon;
    public WeaponPosition weaponPosition;
}

public enum Tires {
    Regular, Offroad, Runflat, Studded, Solid
}
public enum VechicleType {
    SubCompact, Compact, Midsize, Luxury, Sedan, CrossOver, Van, TractorTrailer, Motorcycle, Trike
        //could reasonably be tied to the type of graphics selected
}
public enum WeaponType {
    Contact,    //ramplates, bumper triggered weapons rockets
    Ranged,     //flamethrowers, miniguns, lasers, junk cannons, tasers
    Guided,     //rockets, heat seaking rockets, wire guided rockets
    Dropped     //oil, smoke, junk, spikes, flaming smoke
}

public enum WeaponPosition {
    Front, FrontRight, FrontLeft, Right, Left, BackRight, BackLeft, Back, Top, Underbody
}

public enum WeaponEffect {
    Direct,         //bullets, ramplates
    ArmorPiercing,  //bypass % of armor
    Explosion,      //rockets, explosive rounds
    Fire,           //flamethrowers
    Smoke,          //smokescreens - obscures visibility
}

public enum Armor {
    Plastic,
    Metal,
    Ceramic,
}

public class Ammunition {
    WeaponEffect effect;
    float baseDamage;
    float chanceToCritical;
    float clipSize;
    float projectileRange;   //contact = 0, guided = medium, ranged = very high, dropped = 0;
    float projectileSpeed;   //dropped = 0, ranged = guided = high, ranged = very high
    float projectileDuration;    //spikes should last forever, rockets could last a few seconds, guns should be very short
    float projectiledamage;
}

public class Weapons {
    public string name;
    public WeaponType type;
    
    public int maximumAmmunition;
    public int currentAmmunition;
    // Other ideas...
    //    public bool doesDamageDecreaseWithDistance;
    //damage drops off with range  
    //lasers> linear decay
    //flamethrowers, smoke > exponential decay

    //    public float weaponAngle;   //rotation angle of the gun
    //    public float weaponAngleRange;  // side to side range of the weapon (assume player can "aim" their guns a little bit)
    // variable mounts, could change the angle (intelligently aim at vechicles not on axis)
}