using Sandbox;

namespace Minima.TikTokLive;

public interface ITikTokLiveEvents: ISceneEvent<ITikTokLiveEvents> {
	/// <summary>
	/// Called when a user sends a chat message in the TikTok Live chat.
	/// </summary>
	void OnChat( WebcastChatMessage chatMessage ) { }
	
	/// <summary>
	/// Called when a user sends a gift in the TikTok Live chat.
	/// </summary>
	void OnGift( WebcastGiftMessage giftMessage ) { }
	
	/// <summary>
	/// Called when a user likes the TikTok Live stream.
	/// This is called occasionally, not every time a user likes.
	/// </summary>
	void OnLike( WebcastLikeMessage likeMessage ) { }
	
	/// <summary>
	/// Called when a user performs an action in the TikTok Live chat.
	/// e.g. Joining
	/// </summary>
	void OnMemberMessage( WebcastMemberMessage memberMessage ) { }
	
	/// <summary>
	/// Invoked when updated statistics about the room's top viewers and total viewer count are received.
	/// Used internally to synchronize <see cref="TikTokLiveConnector.TopViewers" /> and <see cref="TikTokLiveConnector.ViewerCount" />.
	/// </summary>
	void OnRoomUserSeqMessage( WebcastRoomUserSeqMessage roomUserSeqMessage ) { }
	
	/// <summary>
	/// Called when a user follows or shares the TikTok Live stream.
	/// </summary>
	void OnSocialMessage( WebcastSocialMessage socialMessage ) { }
	
	/// <summary>
	/// Called when a user subscribes to the TikTok Live stream.
	/// </summary>
	void OnSubNotify( WebcastSubNotifyMessage subNotifyMessage ) { }
}
