using System;
using System.Linq;
using System.Text.Json;
using Sandbox;

namespace Minima.TikTokLive;

[Title( "TikTok Live Connector" )]
public partial class TikTokLiveConnector : Component {
	/// <summary>
	/// The singleton instance of <see cref="TikTokLiveConnector"/>.
	/// </summary>
	public static TikTokLiveConnector Instance { get; private set; }

	/// <summary>
	/// The WebSocket URI of the tiktok-live-connector instance
	/// <see href="https://www.eulerstream.com/docs/sign-server/websockets" />
	/// </summary>
	[ConVar( "ttl_uri", ConVarFlags.Server )]
	public static string ConnectionUri { get; private set; }

	/// <summary>
	/// Gets the active WebSocket connection used by the TikTok Live Connector.
	/// </summary>
	private WebSocket Socket { get; set; }

	public TikTokLiveConnector() =>
		Instance = this;

	protected override void OnStart() {
		if ( Networking.IsClient )
			return;

		if ( ConnectionUri == null ) {
			Log.Info( "ConnectionUri isn't set. Please set the 'ttl_uri' ConVar to enable the TikTok Live Connector." );
			return;
		}

		Socket = new WebSocket();
		Socket.OnMessageReceived += SocketMessageReceived;
		Socket.Connect( ConnectionUri );
	}

	protected override void OnDestroy() =>
		Socket?.Dispose();

	private void SocketMessageReceived( string jsonMessage ) {
		var socketMessage = JsonSerializer.Deserialize<SocketMessage>( jsonMessage, new JsonSerializerOptions { PropertyNameCaseInsensitive = true } );
		foreach ( var message in socketMessage.Messages ) {
			try {
				var messageType = TypeLibrary.GetTypes<BaseWebcastMessage>()
					.FirstOrDefault( t => t.Name.ToLower() == message.Type.ToLower() );

				if ( messageType == null ) {
					if ( Debug ) Log.Warning( new TikTokLiveConnectorUnknownMessage( message ) );
					continue;
				}

				var webcastMessage = (BaseWebcastMessage)message.Data.Deserialize( messageType.TargetType, new JsonSerializerOptions { PropertyNameCaseInsensitive = true } );
				webcastMessage?.Handle( this );
			} catch ( Exception e ) {
				Log.Error( new TikTokLiveConnectorError( message, e ) );
			}
		}
	}
}
