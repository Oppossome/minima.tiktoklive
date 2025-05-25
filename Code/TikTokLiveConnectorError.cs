using Sandbox;
namespace Minima.TikTokLive;

/// <summary>
/// Logged to the console when an error occurs while processing a message.
/// </summary>
struct TikTokLiveConnectorError(string messageType, string error, string data) {
	[WideMode]
	string MessageType { get; } = messageType;
	
	[WideMode, TextArea]
	string Error { get; } = error;
	
	[WideMode, TextArea]
	string Data { get; } = data;
	
	public override string ToString() => 
		$"Error occured while processing message of type '{MessageType}'";
}
