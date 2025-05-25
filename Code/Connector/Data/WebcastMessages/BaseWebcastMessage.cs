namespace Minima.TikTokLive;

/// <summary>
/// All webcast messages inherit from this class, their name must match
/// the name of the message type provided by the TikTok Live API.
/// </summary>
public abstract class BaseWebcastMessage {
	public abstract void Handle( TikTokLiveConnector tikTokLiveConnector );
}
