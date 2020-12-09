using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Building Generation/Wings/UWings")]
public class UWingsStrategy : WingsStrategy
{
    public bool scaleWings;
    public override Wing[] GenerateWings(BuildingSettings settings)
    {
        if (settings.Size.x > 2 && settings.Size.y > 1)
        {
            RectInt firstBounds = new RectInt(0, 0, settings.Size.x, 1);
            RectInt secondBounds;
            RectInt thirdBounds;
            if (scaleWings && settings.Size.x > 4)
            {
                int size = settings.Size.x / 2;
                if (size % 2 == 0)
                {
                    size -= 1;
                }
                secondBounds = new RectInt(0, 1, size, settings.Size.y - 1);
                thirdBounds = new RectInt(settings.Size.x - size, 1, size, settings.Size.y - 1);
            } else
            {
                secondBounds = new RectInt(0, 1, 1, settings.Size.y - 1);
                thirdBounds = new RectInt(settings.Size.x - 1, 1, 1, settings.Size.y - 1);
            }

            

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
