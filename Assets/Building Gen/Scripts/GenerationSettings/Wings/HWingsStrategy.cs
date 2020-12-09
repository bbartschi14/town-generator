using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Building Generation/Wings/HWings")]
public class HWingsStrategy : WingsStrategy
{
    public override Wing[] GenerateWings(BuildingSettings settings)
    {
        if (settings.Size.x > 2 && settings.Size.y > 2)
        {
            RectInt firstBounds = new RectInt(0, 0, 1, settings.Size.y);
            RectInt secondBounds = new RectInt(1, settings.Size.y/2, settings.Size.x - 2, 1);
            RectInt thirdBounds = new RectInt(settings.Size.x - 1, 0, 1, settings.Size.y);

            Wing[] wings = new Wing[3];
            if (settings.wingStrategy != null)
            {
                wings[0] = settings.wingStrategy.GenerateWing(settings, firstBounds, settings.Height());
                wings[1] = settings.wingStrategy.GenerateWing(settings, secondBounds, settings.Height());
                wings[2] = settings.wingStrategy.GenerateWing(settings, thirdBounds, settings.Height());
            }
            else
            {
                wings[0] = ((WingStrategy)ScriptableObject.CreateInstance<DefaultWingStrategy>()).GenerateWing(settings, firstBounds, settings.Height());
                wings[1] = ((WingStrategy)ScriptableObject.CreateInstance<DefaultWingStrategy>()).GenerateWing(settings, secondBounds, settings.Height());
                wings[2] = ((WingStrategy)ScriptableObject.CreateInstance<DefaultWingStrategy>()).GenerateWing(settings, thirdBounds, settings.Height());
            }
            return wings;
        }
        else
        {
            return new Wing[]
            {

            settings.wingStrategy != null ?
                settings.wingStrategy.GenerateWing(settings, new RectInt(0, 0, settings.Size.x, settings.Size.y), settings.Height()):
                ((WingStrategy)ScriptableObject.CreateInstance<DefaultWingStrategy>()).GenerateWing(settings, new RectInt(0,0, settings.Size.x, settings.Size.y), settings.Height()),
            };
        }

    }
}
