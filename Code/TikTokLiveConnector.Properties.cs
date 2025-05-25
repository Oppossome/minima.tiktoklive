using Sandbox;

namespace Minima.TikTokLive;

public partial class TikTokLiveConnector : ITikTokLiveEvents {
	/// <summary>
	/// Represents the amount of viewers in the room.
	/// </summary>
	[Sync]
	[Property, ReadOnly, Group("Details")]
	public int ViewerCount { get; private set; } = 0;

	/// <summary>
	/// Represents the top viewers in the room and their coins.
	/// </summary>
	[Sync]
	[Property, ReadOnly, Group( "Details" )]
	public NetList<WebcastRoomUserSeqMessage.TopViewer> TopViewers { get; private set; } = new();
	
	void ITikTokLiveEvents.OnRoomUserSeqMessage( WebcastRoomUserSeqMessage msg ) {
		ViewerCount = msg.ViewerCount;
		
		TopViewers.Clear();
		foreach( var topUser in msg.TopViewers ) 
			TopViewers.Add( topUser );
	}
}
