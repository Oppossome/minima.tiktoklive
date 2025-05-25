using System.Linq;

namespace Minima.TikTokLive;

/// Thanks to the awesome people at TikTok-Live-Connector
/// https://github.com/zerodytrash/TikTok-Live-Connector/blob/ecde03a3113b45c30e9d43b6a686ef6b40d297e2/.proto/tiktok-schema.ts

// Custom Functionality Provided:
//   - User.ProfilePicture.Jpeg

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

		/// <summary>
		/// A library provided convenience method
		/// </summary>
		public string? Jpeg => Urls.FirstOrDefault( url => url.Contains( ".jpeg" ) );
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
