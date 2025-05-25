namespace Minima.TikTokLive;

public struct User {
	public string UserId { get; set; }
	public string Nickname { get; set; }
	public UserProfilePicture? ProfilePicture { get; set; }
	public string UniqueId { get; set; }
	public string SecUid { get; set; }
	public UserBadgesAttributes[] Badges { get; set; }
	public string CreateTime { get; set; }
	public string BioDescription { get; set; }
	public UserFollowInfo? FollowInfo { get; set; }

	public struct UserProfilePicture {
		public string[] Urls { get; set; }
	}

	public struct UserBadgesAttributes {
		public int BadgeSceneType { get; set; }
		public UserImageBadge[] ImageBadges { get; set; }
		public UserBadge[] Badges { get; set; }
		public UserPrivilegeLogExtra? PrivilegeLogExtra { get; set; }

		public struct UserImageBadge {
			public int DisplayType { get; set; }
			public UserImageBadgeImage? Image { get; set; }

			public struct UserImageBadgeImage {
				public string Url { get; set; }
			}
		}

		public struct UserBadge {
			public string Type { get; set; }
			public string Name { get; set; }
		}

		public struct UserPrivilegeLogExtra {
			public string PrivilegeId { get; set; }
			public string Level { get; set; }
		}
	}

	public struct UserFollowInfo {
		public int FollowingCount { get; set; }
		public int FollowerCount { get; set; }
		public int FollowStatus { get; set; }
		public int PushStatus { get; set; }
	}
}
