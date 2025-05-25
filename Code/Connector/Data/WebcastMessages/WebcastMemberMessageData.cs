namespace Minima.TikTokLive;

/// Thanks to the awesome people at TikTok-Live-Connector
/// https://github.com/zerodytrash/TikTok-Live-Connector/blob/ecde03a3113b45c30e9d43b6a686ef6b40d297e2/.proto/tiktok-schema.ts

/// <summary>
/// Event data for a user performing an action in the room.
/// e.g. Joining
/// </summary>
public class WebcastMemberMessage : BaseWebcastMessage {
	public WebcastMemberMessageEvent? Event { get; set; }
	public User? User { get; set; }
	public int ActionId { get; set; }

	public override void Handle( TikTokLiveConnector tikTokLiveConnector ) =>
		ITikTokLiveEvents.Post( ttle => ttle.OnMemberMessage( this ) );

	public struct WebcastMemberMessageEvent {
		public string MsgId { get; set; }
		public string CreateTime { get; set; }
		public WebcastMemberMessageEventDetails? EventDetails { get; set; }

		public struct WebcastMemberMessageEventDetails {
			public string DisplayType { get; set; }
			public string Label { get; set; }
		}
	}
}
