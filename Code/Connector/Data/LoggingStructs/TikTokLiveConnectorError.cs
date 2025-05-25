using System;
using System.Text.Json;
using Sandbox;

namespace Minima.TikTokLive;

/// <summary>
/// Logging structure for errors that occur while processing messages from the TikTok Live Connector.
/// Improves the debugging experience by allowing the inspector to display the error message, type, and data in a user-friendly way.
/// </summary>
struct TikTokLiveConnectorError( SocketMessage.Message message, Exception e ) {
	[WideMode]
	string MessageType { get; } = message.Type;

	[WideMode, TextArea]
	string? MessageData { get; } = message.Data?.ToJsonString( new JsonSerializerOptions { WriteIndented = true } );

	[WideMode, TextArea]
	string Error { get; } = e.ToString();

	public override string ToString() =>
		$"Error occured while processing message of type '{MessageType}'";
}
