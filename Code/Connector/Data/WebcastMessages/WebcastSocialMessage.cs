using Sandbox;

namespace Minima.TikTokLive;

/// Thanks to the awesome people at TikTok-Live-Connector
/// https://github.com/zerodytrash/TikTok-Live-Connector/blob/ecde03a3113b45c30e9d43b6a686ef6b40d297e2/.proto/tiktok-schema.ts

/// <summary>
/// Represents a social interaction in the room.
/// e.g. Following the streamer, sharing the stream
/// </summary>
public class WebcastSocialMessage : BaseWebcastMessage {
	public User? User { get; set; }
	public WebcastSocialMessageEvent? Event { get; set; }
	
	/// <summary>
	/// A field written by the S&Box TikTok Live Connector to simplify the process of decoding the message.
	/// </summary>
	public Kind SocialKind { get; private set; }
	
	public override void Handle( TikTokLiveConnector tikTokLiveConnector ) {
		// TODO: Determine the kind in the getter whilst also logging unknown kinds when debug is enabled.
		if ( Event is { EventDetails: { } details } ) {
			switch ( details.Label ) {
				case "{0:user} followed the LIVE creator":
					SocialKind = Kind.Follow;
					break;
				case "{0:user} shared the LIVE":
					SocialKind = Kind.Share;
					break;
				default:
					if( tikTokLiveConnector.Debug ) Log.Warning( $"Unknown WebcastSocialMessage Label '{details.Label}'" );
					break;
			}
		}
		
		ITikTokLiveEvents.Post( ttle => ttle.OnSocialMessage( this ) );
	}

	public struct WebcastSocialMessageEvent {
		public string MsgId { get; set; }
		public string CreateTime { get; set; }
		public WebcastSocialMessageEventDetails? EventDetails { get; set; }

		public struct WebcastSocialMessageEventDetails {
			public string DisplayType { get; set; }
			public string Label { get; set; }
		}
	}

	public enum Kind {
		Unknown = 0,
		Follow = 1,
		Share = 2,
	}
}
