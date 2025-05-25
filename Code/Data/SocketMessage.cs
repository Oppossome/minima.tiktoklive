using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace Minima.TikTokLive;

public struct SocketMessage {
	public List<Message> Messages { get; set; }

	public struct Message {
		public string Type { get; set; }
		public JsonObject? Data { get; set; }
	}
}
