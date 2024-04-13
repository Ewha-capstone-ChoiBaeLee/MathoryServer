using System;
using System.Reflection;
namespace P_MathoryServer.Services
{
    public class StoryProcessingService
    {
        public (string, string, string, string) ProcessStory(string story)
        {
            string intro, development, crisis, ending;
            SplitStory(story, out intro, out development, out crisis, out ending);
            //Console.WriteLine("intro= " +intro);
            //Console.WriteLine("development= " + development);
            //Console.WriteLine("crisis= " + crisis);
            //Console.WriteLine("ending= " + ending);
            return (intro, development, crisis, ending);
        }
        private void SplitStory(string story, out string intro, out string development, out string crisis, out string ending)
        {
            intro = GetSection(story, "발단:", "전개:");
            development = GetSection(story, "전개:", "위기:");
            crisis = GetSection(story, "위기:", "결말:");
            ending = GetSection(story, "결말:", null);

        }
        private string GetSection(string story, string startTag, string endTag)
        {
            int startIndex = story.IndexOf(startTag);
            if (startIndex == -1)
                return null;

            startIndex += startTag.Length;
            int endIndex = endTag != null ? story.IndexOf(endTag, startIndex) : story.Length;

            if (endIndex == -1)
                return null;

            return story.Substring(startIndex, endIndex - startIndex).Trim();
        }

    }
}