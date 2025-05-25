namespace Minima.TikTokLive;

/// Thanks to the awesome people at TikTok-Live-Connector
/// https://github.com/zerodytrash/TikTok-Live-Connector/blob/ecde03a3113b45c30e9d43b6a686ef6b40d297e2/.proto/tiktok-schema.ts

/// <summary>
/// Represents a gift given in a TikTok live webcast.
/// </summary>
public class WebcastGiftMessage : BaseWebcastMessage {
	public WebcastGiftMessageEvent? Event { get; set; }
	public int GiftId { get; set; }
	public int RepeatCount { get; set; }
	public User? User { get; set; }
	public int RepeatEnd { get; set; }
	public string GroupId { get; set; }
	public WebcastGiftMessageGiftDetails? GiftDetails { get; set; }
	public string MonitorExtra { get; set; }
	public WebcastGiftMessageGiftExtra? GiftExtra { get; set; }

	public override void Handle( TikTokLiveConnector tikTokLiveConnector ) =>
		ITikTokLiveEvents.Post( ttle => ttle.OnGift( this ) );

	public struct WebcastGiftMessageEvent {
		public string MsgId { get; set; }
		public string CreateTime { get; set; }
		public WebcastGiftMessageEventDetails? EventDetails { get; set; }

		public struct WebcastGiftMessageEventDetails {
			public string DisplayType { get; set; }
			public string Label { get; set; }
		}
	}

	public struct WebcastGiftMessageGiftDetails {
		public WebcastGiftMessageGiftImage? GiftImage { get; set; }
		public string GiftName { get; set; }
		public string Describe { get; set; }
		public int GiftType { get; set; }
		public int DiamondCount { get; set; }

		public struct WebcastGiftMessageGiftImage {
			public string GiftPictureUrl { get; set; }
		}
	}

	public struct WebcastGiftMessageGiftExtra {
		public string Timestamp { get; set; }
		public string ReceiverUserId { get; set; }
	}
}
