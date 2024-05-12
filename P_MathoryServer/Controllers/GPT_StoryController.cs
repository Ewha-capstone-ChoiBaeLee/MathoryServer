using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API.Completions;
using OpenAI_API;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Security.Principal;
using OpenAI_API.Chat;
using P_MathoryServer.Data;
using P_MathoryServer.Services;
using SharedData.Models;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography.X509Certificates;
using System.Net.Http;


namespace P_MathoryServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GPT_StoryController : ControllerBase
    {
        private readonly StoryProcessingService _storyProcessingService;
        private readonly StoryLineProcessingService _storyLineProcessingService;
        private readonly ApplicationDbContext _context;
        private readonly IHttpClientFactory _clientFactory;

        public GPT_StoryController(StoryProcessingService storyProcessingService, StoryLineProcessingService storyLineProcessingService, ApplicationDbContext context, IHttpClientFactory clientFactory)
        {
            _storyProcessingService = storyProcessingService;
            _storyLineProcessingService = storyLineProcessingService;
            _context = context;
            _clientFactory = clientFactory;
        }

        [HttpPost]
        public IActionResult ExecuteController()
        {
            var result = GetStory().Result;
            return Ok(result);
        }


        [HttpPost]
        [Route("StoryGPT")]
        public async Task<IActionResult> GetStory()
        {
            string APIKey = "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";
            var openai = new OpenAIAPI(APIKey);
            var chat = openai.Chat.CreateConversation();
            chat.Model = "ft:gpt-3.5-turbo-0125:personal::93cPhwFT";

            var general_system = @"You are a movie screenwriter. The fantasy scenario you are writing is set in a magical school for children in a fantasy world. The story will be used for child game under 12 years old,
								so it should not contain explicit contents and do not create another characters other than the user inserted.The story should use informal Korean for the dialogues
You should write your scenario in Korean.You need to write a scenario that fits the plot that the user enters.
You should write the story in the form of 발단 - 전개 - 위기 - 결말, where each has a description and dialogues between characters in Korean.
It should be in the form of {character}: {character's dialog} and when writing descriptions, you should write in the form of  {설명}: {content of the description}";

            var character_system = @"주인공 is neutral.
마크 is outgoing and likes to take charge.
리나 is introverted and kind.
You need to write the story taking into account the character's personality.";

            string charSyst = "주인공 is neutral\n";
            var (prompt, location, clock, friendsID) = Prompts.MakingStoryPrompt();
            //friendsID = {0,1,2}
            //DB characterID starts from 1
            for (var i = 0; i < friendsID.Count; i++)
            {
                var friend = _context.CharacterInformation.FirstOrDefault(s => s.CharacterId == friendsID[i] + 1);
                charSyst += (friend.CharacterPersonality + ". ");

            }
            charSyst += "You need to write the story taking into account the character's personality.";

            var systemMessage = general_system + character_system;
            chat.AppendSystemMessage(systemMessage);
            chat.AppendUserInput(prompt);
            var response = await chat.GetResponseFromChatbotAsync();

            (string intro, string development, string crisis, string ending) = _storyProcessingService.ProcessStory(response);

            //save splitted story to DB
            var introStory = new Story
            {
                Part = 1,
                Content = intro,
                Time = clock,
                Location = location,
            };
            var developmentStory = new Story
            {
                Part = 2,
                Content = development,
                Time = clock,
                Location = location,
            };
            var crisisStory = new Story
            {
                Part = 3,
                Content = crisis,
                Time = clock,
                Location = location,
            };
            var endingStory = new Story
            {
                Part = 4,
                Content = ending,
                Time = clock,
                Location = location,
            };

            _context.Story.Add(introStory);
            _context.Story.Add(developmentStory);
            _context.Story.Add(crisisStory);
            _context.Story.Add(endingStory);
            _context.SaveChanges();

            _storyLineProcessingService.ProcessStoryLine();

            await ExecuteGPTQuizController();

            return Ok(new { Prompt = prompt, Location = location, Clock = clock, Intro = intro, Development = development, Crisis = crisis, Ending = ending });
        }

        [HttpPost("QuizGPT")]
        public async Task ExecuteGPTQuizController()
        {
            var url = "https://localhost:7039/api/GPT_Quiz/QuizGPT";

            using (var client = _clientFactory.CreateClient())
            {
                var response = await client.PostAsync(url, null);
            }
        }
    }
} 