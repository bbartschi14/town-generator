using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Building Generation/Stories/Shrinking")]
public class ShrinkingStoriesStrategy : StoriesStrategy
{
    public int WidthShrinkAmount = 1;
    public int HeightShrinkAmount = 1;
    public override Story[] GenerateStories(BuildingSettings settings, RectInt bounds, int numberOfStories)
    {
        Story[] stories = new Story[numberOfStories];
        for (int level = 0; level < numberOfStories; level++)
        {
            stories[level] = settings.storyStrategy != null ?
                settings.storyStrategy.GenerateStory(settings, bounds, level) :
                ((StoryStrategy)ScriptableObject.CreateInstance<DefaultStoryStrategy>()).GenerateStory(settings, bounds, level);

            if (bounds.width > WidthShrinkAmount)
            {
                bounds = new RectInt(bounds.x, bounds.y, bounds.width - WidthShrinkAmount, bounds.height);
            }
            if (bounds.height > HeightShrinkAmount)
            {
                bounds = new RectInt(bounds.x, bounds.y, bounds.width, bounds.height - HeightShrinkAmount);
            }
        }
        return stories;
    }
}
