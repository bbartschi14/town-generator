using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultStoriesStrategy : StoriesStrategy
{
   public override Story[] GenerateStories(BuildingSettings settings, RectInt bounds, int numberOfStories)
    {
        Story[] stories = new Story[numberOfStories];
        for (int level = 0; level < numberOfStories; level++)
        {
            stories[level] = settings.storyStrategy != null ?
                settings.storyStrategy.GenerateStory(settings, bounds, level) :
                ((StoryStrategy)ScriptableObject.CreateInstance<DefaultStoryStrategy>()).GenerateStory(settings, bounds, level);
        }
        return stories;
    }
}
