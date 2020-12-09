using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Building Generation/Wings/LWings")]
public class LWingsStrategy : WingsStrategy
{
    public override Wing[] GenerateWings(BuildingSettings settings)
    {
        if (settings.Size.x > 1 && settings.Size.y > 1)
        {
            RectInt firstBounds = new RectInt(0, 0, settings.Size.x, 1);
            RectInt secondBounds = new RectInt(0, 1, 1, settings.Size.y-1);

            Wing[] wings = new Wing[2];
            if (settings.wingStrategy != null)
            {
                wings[0] = settings.wingStrategy.GenerateWing(settings, firstBounds, settings.Height());
                wings[1] = settings.wingStrategy.GenerateWing(settings, secondBounds, settings.Height());
            } else {
                wings[0] = ((WingStrategy)ScriptableObject.CreateInstance<DefaultWingStrategy>()).GenerateWing(settings, firstBounds, settings.Height());
                wings[1] = ((WingStrategy)ScriptableObject.CreateInstance<DefaultWingStrategy>()).GenerateWing(settings, secondBounds, settings.Height());
            }
            return wings;
        } else {
            return new Wing[]
            {

            settings.wingStrategy != null ?
                settings.wingStrategy.GenerateWing(settings, new RectInt(0, 0, settings.Size.x, settings.Size.y), settings.Height()):
                ((WingStrategy)ScriptableObject.CreateInstance<DefaultWingStrategy>()).GenerateWing(settings, new RectInt(0,0, settings.Size.x, settings.Size.y), settings.Height()),
            };
        }
        
    }
}
