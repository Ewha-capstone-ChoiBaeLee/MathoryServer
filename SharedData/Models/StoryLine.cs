using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedData.Models
{
    public class StoryLine
    {

        public int Id { get; set; }
        public int Num { get; set; }
        public int Part { get; set; }
        public string Name { get; set; }
        public string Story {  get; set; }

        /*static void Main(string[] args)
        {
            // 발단
            var story1 = new Dictionary<string, string>();
            story1.Add("설명", "화창한 낮, 주인공과 친구들이 제시카와 리나는 동아리 방에서 함께 국어 수업을 공부하고 숙제를 풀기로 결심했다.");
            story1.Add("주인공", "제시카, 리나, 이번 국어 숙제가 어렵네. 같이 공부해보면 어때?");
            story1.Add("제시카", "좋아! 서로 도움이 되면서 빨리 끝낼 수 있을 거야.");
            story1.Add("리나", "그래, 함께 하면 더 재미있을 것 같아.");

            // 전개
            var story2 = new Dictionary<string, string>();
            story2.Add("설명", "동아리 방으로 모여 국어 수업 내용을 함께 공부하기로 한 주인공과 친구들은 책과 노트를 꺼내어 숙제를 시작한다.");
            story2.Add("주인공", "이 부분을 이해 못 하겠어.제시카, 너 좀 도와줄 수 있을까?");
            story2.Add("제시카", "물론이야! 여기 봐, 이 부분은 이렇게 푸는 거야.");
            story2.Add("리나", "오, 그렇게 하면 되는 거구나! 고마워, 제시카.");

            // 위기
            var story3 = new Dictionary<string, string>();
            story3.Add("설명", "어려운 문제에 부딪히기도 했지만, 주인공과 친구들은 서로 도와가며 어려움을 극복한다.");
            story3.Add("주인공", "이제 좀 더 풀어보자. 이 부분은 어떻게 푸는 거지?");
            story3.Add("제시카", "음, 여기서는 이렇게 접근하면 돼. 이해되니?");
            story3.Add("리나", "어, 그렇게 하면 될 것 같아! 너무 고마워, 제시카.");

            // 결말
            var story4 = new Dictionary<string, string>();
            story4.Add("설명", "서로 도와가며 국어 숙제를 공부하고 푸는 과정에서 주인공과 친구들은 서로의 지식을 나누며 성장한다.");
            story4.Add("설명", "함께 어려운 문제를 푸는 것이 더 즐거운 순간으로 이어지며, 동아리 방은 웃음과 공부의 장소로 가득하게 된다.");
        }*/
    }
}
