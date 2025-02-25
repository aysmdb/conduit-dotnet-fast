namespace RealDotnetFast.Models.Entities;

public class UserFollowing
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int FollowingUserId { get; set; }
}

public class UserFollower
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int FollowerUserId { get; set; }
}