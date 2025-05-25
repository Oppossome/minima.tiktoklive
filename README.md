# S&Box TikTok Live Connector

### To Get Started:
- Add the `TikTok Live Connector` component to your game
- Set the `ttl_uri` ConVar to a EulerStream WebSocket URI
  - It should roughly look like `wss://ws.eulerstream.com?uniqueId=tv_asahi_news&apiKey=API_KEY_HERE`
- Run the Game

### Example Component:
```cs
using Minima.TikTokLive;

public class TikTokExample: Component, ITikTokLiveEvents {
    void ITikTokLiveEvents.OnChat( WebcastChatMessage msg ) {
       if ( msg.User is not {} user )
          return;
       
       Log.Info($"[{user.Nickname}]: {msg.Comment}"  );
    }
    
    void ITikTokLiveEvents.OnGift( WebcastGiftMessage msg ) {
       if ( msg.User is not {} user || msg.GiftDetails is not {} giftDetails )
          return;
    
       Log.Info($"[{user.Nickname}] sent a gift {giftDetails.GiftName} worth {giftDetails.DiamondCount} diamonds"  );
    }
    
    void ITikTokLiveEvents.OnLike( WebcastLikeMessage msg ) {
       if ( msg.User is not {} user )
          return;
       
       Log.Info($"[{user.Nickname}] liked the stream {msg.LikeCount} times." );
    }
    
    void ITikTokLiveEvents.OnSubNotify( WebcastSubNotifyMessage msg ) {
       if ( msg.User is not {} user )
          return;
       
       Log.Info($"[{user.Nickname}] subscribed to the stream." );
    }
    
    void ITikTokLiveEvents.OnSocialMessage( WebcastSocialMessage msg ) {
       if ( msg.User is not {} user )
          return;
       
       if ( msg.SocialKind == WebcastSocialMessage.Kind.Follow )
          Log.Info($"[{user.Nickname}] followed the stream." );
       else if ( msg.SocialKind == WebcastSocialMessage.Kind.Share )
          Log.Info($"[{user.Nickname}] shared the stream." );
    }
}
```