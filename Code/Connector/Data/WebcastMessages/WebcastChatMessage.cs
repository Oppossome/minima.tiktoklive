namespace Minima.TikTokLive;

/// Thanks to the awesome people at TikTok-Live-Connector
/// https://github.com/zerodytrash/TikTok-Live-Connector/blob/ecde03a3113b45c30e9d43b6a686ef6b40d297e2/.proto/tiktok-schema.ts

/// <summary>
///	Represents a chat message in the room.
/// </summary>
public class WebcastChatMessage : BaseWebcastMessage {
	public WebcastChatMessageEvent? Event { get; set; }
	public User? User { get; set; }
	public string Comment { get; set; }
	public bool VisibleToSender { get; set; }
	public WebcastChatMessageImageModel? Background { get; set; }
	public string FullScreenTextColor { get; set; }
	public WebcastChatMessageImageModel? BackgroundImageV2 { get; set; }
	public WebcastChatMessageImageModel? GiftImage { get; set; }
	public int InputType { get; set; }
	public User? AtUser { get; set; }
	public WebcastSubEmote[] Emotes { get; set; }
	public string ContentLanguage { get; set; }
	public int QuickChatScene { get; set; }
	public int CommunityflaggedStatus { get; set; }
	public WebcastChatMessageCommentQualityScore[] CommentQualityScores { get; set; }
	public WebcastChatMessageUserIdentity? UserIdentity { get; set; }
	public WebcastChatMessageCommentTag[] CommentTag { get; set; }
	public string ScreenTime { get; set; }
	public string Signature { get; set; }
	public string SignatureVersion { get; set; }
	public string EcStreamerKey { get; set; }

	public override void Handle( TikTokLiveConnector tikTokLiveConnector ) =>
		ITikTokLiveEvents.Post( ttle => ttle.OnChat( this ) );

	public struct WebcastChatMessageEvent {
		public string MsgId { get; set; }
		public string CreateTime { get; set; }
		public WebcastChatMessageEventDetails? EventDetails { get; set; }

		public struct WebcastChatMessageEventDetails {
			public string DisplayType { get; set; }
			public string Label { get; set; }
		}
	}

	public struct WebcastChatMessageImageModel {
		public string[] MUrls { get; set; }
		public string MUri { get; set; }
		public int Height { get; set; }
		public int Width { get; set; }
		public string AvgColor { get; set; }
		public int ImageType { get; set; }
		public string Schema { get; set; }
		public WebcastChatMessageImageModelContent? Content { get; set; }
		public bool IsAnimated { get; set; }

		public struct WebcastChatMessageImageModelContent {
			public string Name { get; set; }
			public string FontColor { get; set; }
			public string Level { get; set; }
		}
	}

	public struct WebcastSubEmote {
		public int PlaceInComment { get; set; }
		public WebcastSubEmoteDetails? Emote { get; set; }

		public struct WebcastSubEmoteDetails {
			public string EmoteId { get; set; }
			public WebcastSubEmoteImage? Image { get; set; }

			public struct WebcastSubEmoteImage {
				public string ImageUrl { get; set; }
			}
		}
	}

	public struct WebcastChatMessageCommentQualityScore {
		public string Version { get; set; }
		public string Score { get; set; }
	}

	public struct WebcastChatMessageUserIdentity {
		public bool IsGiftGiverOfAnchor { get; set; }
		public bool IsSubscriberOfAnchor { get; set; }
		public bool IsMutualFollowingWithAnchor { get; set; }
		public bool IsFollowerOfAnchor { get; set; }
		public bool IsModeratorOfAnchor { get; set; }
		public bool IsAnchor { get; set; }
	}

	// Use enum for tags
	public enum WebcastChatMessageCommentTag {
		CommentTagNormal = 0,
		CommentTagCandidate = 1,
		CommentTagOverage = 2,
		Unrecognized = -1
	}
}
