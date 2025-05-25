namespace Minima.TikTokLive;

/// Thanks to the awesome people at TikTok-Live-Connector
/// https://github.com/zerodytrash/TikTok-Live-Connector/blob/ecde03a3113b45c30e9d43b6a686ef6b40d297e2/.proto/tiktok-schema.ts

/// <summary>
/// Statistics about the top viewers and the total viewer count in the room.
/// </summary>
public class WebcastRoomUserSeqMessage : BaseWebcastMessage {
	public TopViewer[] TopViewers { get; set; }
	public int ViewerCount { get; set; }

	public override void Handle( TikTokLiveConnector tikTokLiveConnector ) =>
		ITikTokLiveEvents.Post( ttle => ttle.OnRoomUserSeqMessage( this ) );

	public struct TopViewer {
		public string CoinCount { get; set; }
		public User? User { get; set; }
	}
}
