using BusinessObject;
using System.Collections.Generic;

namespace MyCarService.Models
{
    public class MainModel
    {
        public MainModel()
        {
            Login = new Login();
            LoginList = new List<Login>();

            UserRole = new UserRole();
            UserRoleList = new List<UserRole>();

            FeedBack = new FeedBack();
            FeedBackList = new List<FeedBack>();

            Answer = new Answer();
            AnswerList = new List<Answer>();

            Location = new Location();
            LocationList = new List<Location>();

            State = new StateMaster();
            StateList = new List<StateMaster>();

            City = new CityMaster();
            CityList = new List<CityMaster>();

            Package = new Package();
            PackageList = new List<Package>();

            Subcribes = new Subcribes();
            SubcribesList = new List<Subcribes>();

            Enquiry = new Enquiry();
            EnquiryList = new List<Enquiry>();

            ApplyUser = new ApplyUser();
            ApplyUserList = new List<ApplyUser>();

            Payment = new Payment();
            PaymentList = new List<Payment>();

            PImage = new PImage();
            PImageList = new List<PImage>();

            Comment = new Comment();
            CommentList = new List<Comment>();

            CommentReply = new CommentReply();
            CommentReplyList = new List<CommentReply>();
        }
        public UserRole UserRole { get; set; }
        public List<UserRole> UserRoleList { get; set; }

        public Comment Comment { get; set; }
        public List<Comment> CommentList { get; set; }

        public CommentReply CommentReply { get; set; }
        public List<CommentReply> CommentReplyList { get; set; }

        public PImage PImage { get; set; }
        public List<PImage> PImageList { get; set; }

        public Payment Payment { get; set; }
        public List<Payment> PaymentList { get; set; }

        public ApplyUser ApplyUser { get; set; }
        public List<ApplyUser> ApplyUserList { get; set; }

        public Enquiry Enquiry { get; set; }
        public List<Enquiry> EnquiryList { get; set; }

        public Subcribes Subcribes { get; set; }
        public List<Subcribes> SubcribesList { get; set; }

        public Package Package { get; set; }
        public List<Package> PackageList { get; set; }

        public Location Location { get; set; }
        public List<Location> LocationList { get; set; }

        public FeedBack FeedBack { get; set; }
        public List<FeedBack> FeedBackList { get; set; }

        public Answer Answer { get; set; }
        public List<Answer> AnswerList { get; set; }

        public Login Login { get; set; }
        public List<Login> LoginList { get; set; }

        public StateMaster State { get; set; }
        public List<StateMaster> StateList { get; set; }

        public CityMaster City { get; set; }
        public List<CityMaster> CityList { get; set; }
    }
}