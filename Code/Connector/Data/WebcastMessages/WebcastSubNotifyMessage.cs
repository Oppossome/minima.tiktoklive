namespace Minima.TikTokLive;

/// Thanks to the awesome people at TikTok-Live-Connector
/// https://github.com/zerodytrash/TikTok-Live-Connector/blob/ecde03a3113b45c30e9d43b6a686ef6b40d297e2/.proto/tiktok-schema.ts

/// <summary>
/// New subscriber notification message.
/// </summary>
public class WebcastSubNotifyMessage : BaseWebcastMessage {
	public WebcastSubNotifyMessageEvent? Event { get; set; }
	public User? User { get; set; }
	public WebcastSubNotifyMessageSubInfo? SubInfo { get; set; }
	public string SubGoalText { get; set; }
	public int SubGoal { get; set; }
	public int SubTotal { get; set; }
	public int SubNewCount { get; set; }
	public int SubRenewCount { get; set; }
	public WebcastSubNotifyMessageSubGift? SubGift { get; set; }

	public override void Handle( TikTokLiveConnector tikTokLiveConnector ) =>
		ITikTokLiveEvents.Post( ttle => ttle.OnSubNotify( this ) );

	public struct WebcastSubNotifyMessageEvent {
		public string MsgId { get; set; }
		public string CreateTime { get; set; }
		public WebcastSubNotifyMessageEventDetails? EventDetails { get; set; }

		public struct WebcastSubNotifyMessageEventDetails {
			public string DisplayType { get; set; }
			public string Label { get; set; }
		}
	}

	public struct WebcastSubNotifyMessageSubInfo {
		public string SubMonth { get; set; }
		public string SubLevel { get; set; }
		public string SubTitle { get; set; }
	}

	public struct WebcastSubNotifyMessageSubGift {
		public string GiftName { get; set; }
		public int GiftType { get; set; }
		public int DiamondCount { get; set; }
	}
}
