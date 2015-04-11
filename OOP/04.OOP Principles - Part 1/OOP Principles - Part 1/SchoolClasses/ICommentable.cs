namespace SchoolClasses
{
    public interface ICommentable
    {
        string Comments { get;}
        void AddComments(string inputComment);
        void RemoveComments();
    }
}
