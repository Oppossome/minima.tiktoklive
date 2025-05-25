namespace Minima.TikTokLive;

/// Thanks to the awesome people at TikTok-Live-Connector
/// https://github.com/zerodytrash/TikTok-Live-Connector/blob/ecde03a3113b45c30e9d43b6a686ef6b40d297e2/.proto/tiktok-schema.ts

/// <summary>
///	Represents a like event in the room.
/// This is sent occasionally, not every time a user likes.
/// </summary>
public class WebcastLikeMessage : BaseWebcastMessage {
	public WebcastLikeMessageEvent? Event { get; set; }
	public User? User { get; set; }
	public int LikeCount { get; set; }
	public int TotalLikeCount { get; set; }

	public override void Handle( TikTokLiveConnector tikTokLiveConnector ) =>
		ITikTokLiveEvents.Post( ttle => ttle.OnLike( this ) );

	public struct WebcastLikeMessageEvent {
		public string MsgId { get; set; }
		public string CreateTime { get; set; }
		public WebcastLikeMessageEventDetails? EventDetails { get; set; }

		public struct WebcastLikeMessageEventDetails {
			public string DisplayType { get; set; }
			public string Label { get; set; }
		}
	}
}
