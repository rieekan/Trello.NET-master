using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TrelloNet;

namespace ConsoleApplication1
{
    public class Program
    {

        public static void Main(string[] args)
        {
            //Setup();

            //// Let's see if this works
            //Search_WithTestQuery_ReturnsCorrectBoard();

            string urlTrelloBryansCards = "https://trello.com/1/boards/XxQn08CF/members/56d46bd33bf2522671eb5861/cards";
        }


        protected static ITrello _trelloReadOnly;
        protected static ITrello _trelloReadWrite;

        public static void Setup()
        {
            _trelloReadOnly = new Trello(ConfigurationManager.AppSettings["ApplicationKey"]);
            _trelloReadOnly.Authorize(ConfigurationManager.AppSettings["MemberReadToken"]);

            _trelloReadWrite = new Trello(ConfigurationManager.AppSettings["ApplicationKey"]);
            _trelloReadWrite.Authorize(ConfigurationManager.AppSettings["MemberWriteToken"]);
        }

        public static class Constants
        {
            public const string AClosedBoardId = "4f2b95f19cd939a41f512c6a";
            public const string AnUnpinnedBoard = AClosedBoardId;
            public const string ABoardWithInvitationPermissionSetToOwnerId = AClosedBoardId;
            //public const string WelcomeBoardId = "4f2b8b4d4f2cb9d16d3684c9";
            public const string WelcomeBoardId = "XyJtSz94/welcome-board";
            public const string TestOrganizationId = "4f2b94c0c1c87fcb65422344";
            public const string WelcomeBoardBasicsListId = "4f2b8b4d4f2cb9d16d3684c1";
            public const string WelcomeCardOfTheWelcomeBoardId = "4f2b8b4d4f2cb9d16d3684e6";
            public const string MeId = "4f2b8b464f2cb9d16d368326";
            public const string WritableListId = "4f41e4803374646b5c74bd61";
        }

        public static void Search_WithTestQuery_ReturnsCorrectBoard()
        {
            var expected = new Board
            {
                Closed = false,
                Name = "Welcome Board",
                Desc = "A test description",
                IdOrganization = Constants.TestOrganizationId,
                Pinned = true,
                Url = "https://trello.com/b/XxQn08CF/welcome-board",
                Id = Constants.WelcomeBoardId,
                Prefs = new BoardPreferences
                {
                    Comments = CommentPermission.Members,
                    Invitations = InvitationPermission.Members,
                    PermissionLevel = PermissionLevel.Private,
                    Voting = VotingPermission.Members
                },
                LabelNames = new Dictionary<Color, string>
                {
                    { Color.Yellow, "" },
                    { Color.Red, "" },
                    { Color.Purple, "" },
                    { Color.Orange, "" },
                    { Color.Green, "label name" },
                    { Color.Blue, "" },
                }
            };

            var actual = _trelloReadOnly.Search("Welcome Board").Boards.First();

            int t = 0;
            t++;

            //expected.ShouldEqual(actual);
        }
    }
}
