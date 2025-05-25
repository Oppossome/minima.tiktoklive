using System.Text.Json;
using Sandbox;

namespace Minima.TikTokLive;

/// <summary>
/// Logging structure for unknown messages received from the TikTok Live Connector.
/// Improves the debugging experience by allowing the inspector to display the message type and data in a user-friendly way.
/// </summary>
struct TikTokLiveConnectorUnknownMessage( SocketMessage.Message message ) {
	[WideMode]
	string MessageType { get; } = message.Type;

	[WideMode, TextArea]
	private string? MessageData { get; } = message.Data?.ToJsonString( new JsonSerializerOptions { WriteIndented = true } );

	public override string ToString() =>
		$"Unknown message type '{MessageType}'";
}
