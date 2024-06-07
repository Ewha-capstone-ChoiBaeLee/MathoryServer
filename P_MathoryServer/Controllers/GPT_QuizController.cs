using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API.Completions;
using OpenAI_API;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Security.Principal;
using OpenAI_API.Chat;
using SharedData.Models;
using P_MathoryServer.Services;
using P_MathoryServer.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.Text.RegularExpressions;
using System;

namespace P_MathoryServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GPT_QuizController : ControllerBase
    {
        private readonly StoryProcessingService _storyProcessingService;
        private readonly ApplicationDbContext _context;

        public GPT_QuizController(StoryProcessingService storyProcessingService, ApplicationDbContext context)
        {
            _storyProcessingService = storyProcessingService;
            _context = context;
        }

        [HttpPost]
        [Route("QuizGPT")]
        public async Task<IActionResult> GetAIBasedResult()
        {
            string APIKey = "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";
            var openai = new OpenAIAPI(APIKey);
            var chat1 = openai.Chat.CreateConversation();
            var chat2 = openai.Chat.CreateConversation();
            var chat3 = openai.Chat.CreateConversation();
            //chat1.Model = "ft:gpt-3.5-turbo-0125:personal::98gDR6rL"; //old model
            //chat2.Model = "ft:gpt-3.5-turbo-0125:personal::98gDR6rL";
            //chat3.Model = "ft:gpt-3.5-turbo-0125:personal::98gDR6rL";

            chat1.Model = "ft:gpt-3.5-turbo-0125:personal::9WFCRWeC"; //new model
            chat2.Model = "ft:gpt-3.5-turbo-0125:personal::9WFCRWeC";
            chat3.Model = "ft:gpt-3.5-turbo-0125:personal::9WFCRWeC";


            var general_system = @"Given a snippet of children story and a mathematics equation,
you should create a mathematics question for elementary school student related to the story and the given equation.
The equation is given in the first line and the story follows behind it.

The question generated will be used in children story game.
The question should be cohesive with the snippet of the story given and utilizing the equation provided

You should create it in Korean. The question should be in 2-3 sentences long.";

            //read DB splitted story
            var intro = _context.Story
                                .Where(x => x.Part == 1)
                                .Select(x => x.Content)
                                .FirstOrDefault();
            var development = _context.Story
                                 .Where(x => x.Part == 2)
                                 .Select(x => x.Content)
                                 .FirstOrDefault();
            var crisis = _context.Story
                                .Where(x => x.Part == 3)
                                .Select(x => x.Content)
                                .FirstOrDefault();

            //generate equation
            (string equation1, string subject1, string answer1, int subjectID1) = QuizEquation.Generate();
            (string equation2, string subject2, string answer2, int subjectID2) = QuizEquation.Generate();
            (string equation3, string subject3, string answer3, int subjectID3) = QuizEquation.Generate();

            //first question
            var systemMessage1 = general_system + subject1;
            var prompt1 = equation1 + "\n\n" + intro;
            chat1.AppendSystemMessage(systemMessage1);
            chat1.AppendUserInput(prompt1);
            var response1 = await chat1.GetResponseFromChatbotAsync();

            //second question
            var systemMessage2 = general_system + subject2;
            var prompt2 = equation2 + "\n\n" + development;
            chat2.AppendSystemMessage(systemMessage2);
            chat2.AppendUserInput(prompt2);
            var response2 = await chat2.GetResponseFromChatbotAsync();

            //third question
            var systemMessage3 = general_system + subject3;
            var prompt3 = equation3 + "\n\n" + crisis;
            chat3.AppendSystemMessage(systemMessage3);
            chat3.AppendUserInput(prompt3);
            var response3 = await chat3.GetResponseFromChatbotAsync();

            //save to quiz DB
            //Part, Problem, Answer, Equation, Num1, Num2
            var problem1 = new Quiz
            {
                Part = 1,
                Problem = response1,
                Answer = answer1,
                Equation = equation1,
                SubjectId = subjectID1,
            };

            var problem2 = new Quiz
            {
                Part = 2,
                Problem = response2,
                Answer = answer2,
                Equation = equation2,
                SubjectId = subjectID2,
            };

            var problem3 = new Quiz
            {
                Part = 3,
                Problem = response3,
                Answer = answer3,
                Equation = equation3,
                SubjectId = subjectID3,
            };

            _context.Quiz.Add(problem1);
            _context.Quiz.Add(problem2);
            _context.Quiz.Add(problem3);
            _context.SaveChanges();

            return Ok(new { P1 = prompt1, R1 = response1, A1 = answer1, P2 = prompt2, R2 = response2, A2 = answer2, P3 = prompt3, R3 = response3, A3 = answer3 });

        }
    }
}
