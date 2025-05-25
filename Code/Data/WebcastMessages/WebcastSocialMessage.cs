namespace Minima.TikTokLive;

/// Thanks to the awesome people at TikTok-Live-Connector
/// https://github.com/zerodytrash/TikTok-Live-Connector/blob/ecde03a3113b45c30e9d43b6a686ef6b40d297e2/.proto/tiktok-schema.ts

/// <summary>
/// Represents a social interaction in the room.
/// e.g. Following the streamer, sharing the stream
/// </summary>
public class WebcastSocialMessage : BaseWebcastMessage {
	public WebcastSocialMessageEvent? Event { get; set; }
	public User? User { get; set; }

	public override void Handle( TikTokLiveConnector tikTokLiveConnector ) =>
		ITikTokLiveEvents.Post( ttle => ttle.OnSocialMessage( this ) );

	public struct WebcastSocialMessageEvent {
		public string MsgId { get; set; }
		public string CreateTime { get; set; }
		public WebcastSocialMessageEventDetails? EventDetails { get; set; }

		public struct WebcastSocialMessageEventDetails {
			public string DisplayType { get; set; }
			public string Label { get; set; }
		}
	}
}
