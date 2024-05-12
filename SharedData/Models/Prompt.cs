using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedData.Models
{
    public class Prompts
    {
        //주인공 = user name 
        //selected friends = unity input

        static Random random = new Random();
        public static List<int> selectFriends;

        static Tuple<string, List<string>, List<string>> SelectingFriends(List<string> friends)
        {
            //Console.WriteLine("원하는 친구를 고르세요: 루카스[0], 마크[1], 소피아[2], 리나[3], 제시카[4]");
            //List<int> selectFriends = Console.ReadLine().Split().Select(int.Parse).ToList();
            
            List<string> selectedFriends = new List<string>();

            foreach (int idx in selectFriends)
            {
                selectedFriends.Add(friends[idx]);
            }

            List<string> remainingFriends = friends.Where((friend, idx) => !selectFriends.Contains(idx)).ToList();

            string selectedFriendsString = "주인공과 " + string.Join("와 ", selectedFriends) + "가 ";

            //Console.WriteLine("고른 친구: " + string.Join(", ", selectedFriends));
            return Tuple.Create(selectedFriendsString, remainingFriends, selectedFriends);
        }

        public static Tuple<string, string, string, List<int>> MakingStoryPrompt()
        {
            List<string> friends = new List<string> { "루카스", "마크", "소피아", "리나", "제시카" };
            List<string> clocks = new List<string> { "저녁", "낮" };
            List<string> locations = new List<string> { "기숙사", "마법 교실", "학교 도서관", "학교 보건실", "학교 식당", "동아리 방", "학교 운동장", "마법의 숲", "마법 마을" };
            List<string> goals = new List<string> { "수업", "파티", "아이템", "선물을 구매", "동아리", "간식", "운동" };

            var selectedFriendsTuple = SelectingFriends(friends);
            string friend = selectedFriendsTuple.Item1;
            List<string> remainingFriends = selectedFriendsTuple.Item2;
            List<string> selectedFriends = selectedFriendsTuple.Item3;

            string clock = clocks[random.Next(clocks.Count)];
            string location = locations[random.Next(locations.Count)];
            string goal = goals[random.Next(goals.Count)];

            if (goal == "수업")
            {
                List<string> subjectWhy = new List<string> { "시험 성적을 잘 받기 위해", "떨어진 성적을 올리기 위해", "숙제를 풀기 위해", "어려워서 이해가 잘 안되는" };
                List<string> subject = new List<string> { "마법 기초", "식물학", "체육", "미술", "음악", "과학", "실험", "국어" };
                List<string> subjectHow = new List<string> { "공부하기", "실습하기", "글쓰기" };

                goal = $"{subjectWhy[random.Next(subjectWhy.Count)]} {subject[random.Next(subject.Count)]} {goal} {subjectHow[random.Next(subjectHow.Count)]}";
                location = locations[random.Next(0, 4)]; // 실내 학교 공간으로 제한
            }
            else if (goal == "파티")
            {
                List<string> party = new List<string> { "입학", "졸업", "생일", "개교기념일" };
                List<string> partyHow = new List<string> { "준비하기", "계획하기", "다녀오기" };

                goal = $"{party[random.Next(party.Count)]} {goal} {partyHow[random.Next(partyHow.Count)]}";
                location = locations[random.Next(0, 3)];
                // 실내 학교 공간으로 제한

            }
            else if (goal == "아이템")
            {
                List<string> item = new List<string> { "책을", "마법 반지를", "안경을" };
                List<string> itemHow = new List<string> { "찾기", "제작하기", "고치기" };

                goal = $"{remainingFriends[random.Next(remainingFriends.Count)]}의 {item[random.Next(item.Count)]} {itemHow[random.Next(itemHow.Count)]}";
                location = locations[random.Next(0, 5)];
            }
            else if (goal == "선물을 구매")
            {
                List<string> giftWhy = new List<string> { "의 생일", "와 화해하기 위해", "의 최근의 일을 위로하기 위해", "가 평소 좋아하는 물건을 발견해서", "가 좋아하는", "의 떨어진 성적을 위로하기 위해" };

                goal = $"{remainingFriends[random.Next(remainingFriends.Count)]}{giftWhy[random.Next(giftWhy.Count)]} {goal}";
                location = "마법 마을"; // 구매는 마을을 가야하니까 위치 제한
            }
            else if (goal == "동아리")
            {
                List<string> club = new List<string> { "영화", "학생회", "연극", "실험", "독서", "토론", "배드민턴", "수영", "베이킹", "농구", "댄스" };
                List<string> clubHow = new List<string> { "들어가기", "만들기", "운영하기" };

                goal = $"{club[random.Next(club.Count)]} {goal} {clubHow[random.Next(clubHow.Count)]}";
                location = locations[random.Next(0, 6)];
            }
            else if (goal == "간식")
            {
                List<string> snackHow = new List<string> { "먹기", "요리하기", "선물하기" };

                goal = $"{goal} {snackHow[random.Next(snackHow.Count)]}";
                location = locations[random.Next(0, 4)];
            }
            else if (goal == "운동")
            {
                List<string> sport = new List<string> { "축구", "농구", "배구", "야구", "피구", "배드민턴", "핸드볼" };
                List<string> sportHow = new List<string> { "하기", "배우기" };

                goal = $"{sport[random.Next(sport.Count)]}{sportHow[random.Next(sportHow.Count)]}";
                location = "학교 운동장";
                clock = "낮";
            }

            string userPrompt = $"{friend}{clock}에 {location}에서 {goal}";
            //Console.WriteLine(userPrompt);
            return Tuple.Create(userPrompt, location, clock, selectFriends);
        }

    }

}