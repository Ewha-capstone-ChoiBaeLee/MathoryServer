using P_MathoryServer.Data;
using SharedData.Models;
using System.Text;

namespace P_MathoryServer.Services
{
    public class StoryLineProcessingService
    {
        private readonly ApplicationDbContext _context;
        public StoryLineProcessingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void ProcessStoryLine() //read from story DB 4x,  store to StoryLine DB,  will be called from GPT_StoryController
        {
            int num = 0;
            string intro = GetStoryContent(1);
            string development = GetStoryContent(2);
            string crisis = GetStoryContent(3);
            string ending = GetStoryContent(4);

            (int intLen, List<(string, string)> intList) = SplitLines(intro);
            (int devLen, List<(string, string)> devList) = SplitLines(development);
            (int criLen, List<(string, string)> criList) = SplitLines(crisis);
            (int endLen, List<(string, string)> endList) = SplitLines(ending);

            StoreDatabase(num, 1, intList);
            StoreDatabase(num += intLen, 2, devList);
            StoreDatabase(num += devLen, 3, criList);
            StoreDatabase(num + criLen, 4, endList);
        }
        private string GetStoryContent(int part)
        {
            var storyPart = _context.Story.FirstOrDefault(s => s.Part == part);

            return storyPart.Content;
        }
        private (int length, List<(string, string)>) SplitLines(string story)
        {
            //split the story into lines
            string[] lines = story.Trim().Split('\n', StringSplitOptions.RemoveEmptyEntries);

            //store dialogues as a list of tuples (name, content)
            List<(string, string)> dialogues = new List<(string, string)>();

            //add "설명: " to the beginning of the first line
            string firstLine = lines[0].Trim();
            dialogues.Add(("설명", firstLine));
            Console.WriteLine(firstLine);

            //process the rest of the lines
            for (int i = 1; i < lines.Length; i++)
            {
                //split each line into name and content
                string[] parts = lines[i].Split(':');
                if (parts.Length == 2)
                {
                    string name = parts[0].Trim();
                    string content = parts[1].Trim();
                    dialogues.Add((name, content));
                }
            }
            int length = dialogues.Count;

            return (length, dialogues);
        }
        private void StoreDatabase(int num, int part, List<(string, string)> dialogues) // store to DB: Num - Part - Name - Story
        {
            foreach (var dialogue in dialogues)
            {
                num += 1;
                var add = new StoryLine
                {
                    Num = num,
                    Part = part,
                    Name = dialogue.Item1,
                    Story = dialogue.Item2
                };

                _context.StoryLine.Add(add);
            }

            _context.SaveChanges();
        }
    }
}