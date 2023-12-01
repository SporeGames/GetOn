using Godot;

namespace GetOn.scenes.Management {
	public class NoteContent : Resource {
		[Export] public string ID { get; set; } = "none";
		[Export] public string Content { get; set; } = "test";
		[Export] public Color Color { get; set; } = Colors.White;
		
		public NoteContent() : this("none", null, Colors.White) {}

		public NoteContent(string id, string content, Color color) {
			ID = id;
			Content = content;
			Color = color;
		}
	}
}
